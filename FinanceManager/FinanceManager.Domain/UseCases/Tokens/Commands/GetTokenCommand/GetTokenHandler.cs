using FinanceManager.Domain.Configurations;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace FinanceManager.Domain.UseCases.Tokens.Commands.GetTokenCommand;

public class GetTokenHandler : IRequestHandler<GetTokenCommand, Result<TokenModel>>
{
    private readonly UserManager<FinanceManagerUser> _userManager;
    private readonly RoleManager<FinanceManagerRole> _roleManager;
    private readonly AuthConfiguration _authConfigs;

    public GetTokenHandler(UserManager<FinanceManagerUser> userManager,
        RoleManager<FinanceManagerRole> roleManager,
        IOptions<AuthConfiguration> authConfig)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        _authConfigs = authConfig.Value ?? throw new ArgumentNullException(nameof(authConfig.Value));
    }

    public async Task<Result<TokenModel>> Handle(GetTokenCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            throw new ArgumentNullException(nameof(request.Email) + "or" + nameof(request.Password));

        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return await Result<TokenModel>.FailAsync("User Not Found.");
        }
        if (!user.EmailConfirmed)
        {
            return await Result<TokenModel>.FailAsync("E-Mail not confirmed.");
        }

        var passwordValid = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!passwordValid)
        {
            return await Result<TokenModel>.FailAsync("Invalid Credentials.");
        }

        user.RefreshToken = GenerateRefreshToken();
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
        await _userManager.UpdateAsync(user);

        var token = await GenerateJwtAsync(user);
        var response = new TokenModel { Token = token, RefreshToken = user.RefreshToken, RefreshTokenExpiryTime = user.RefreshTokenExpiryTime };
        return await Result<TokenModel>.SuccessAsync(response);
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private async Task<string> GenerateJwtAsync(FinanceManagerUser user)
    {
        var token = GenerateEncryptedToken(GetSigningCredentials(), await GetClaimsAsync(user));
        return token;
    }

    private string GenerateEncryptedToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
    {
        var token = new JwtSecurityToken(
           claims: claims,
           issuer: _authConfigs.ISSUER,
           audience: _authConfigs.AUDIENCE,
           expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(_authConfigs.LIFETIME_IN_MINETS)),
           signingCredentials: signingCredentials);
        var tokenHandler = new JwtSecurityTokenHandler();
        var encryptedToken = tokenHandler.WriteToken(token);
        return encryptedToken;
    }

    private SigningCredentials GetSigningCredentials()
    {
        return new(_authConfigs.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
    }

    private async Task<IEnumerable<Claim>> GetClaimsAsync(FinanceManagerUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, role));
            var thisRole = await _roleManager.FindByNameAsync(role);
            var allPermissionsForThisRoles = await _roleManager.GetClaimsAsync(thisRole);
        }

        var claims = new List<Claim>
           {
               new(ClaimTypes.NameIdentifier, user.Id.ToString()),
               new(ClaimTypes.Email, user.Email),
               new(ClaimTypes.Name, user.FirstName),
               new(ClaimTypes.Surname, user.LastName),
           }
        .Union(userClaims)
        .Union(roleClaims);

        return claims;
    }
}
