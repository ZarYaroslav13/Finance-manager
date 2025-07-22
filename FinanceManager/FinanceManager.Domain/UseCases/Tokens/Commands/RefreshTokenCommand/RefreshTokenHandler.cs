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

namespace FinanceManager.Domain.UseCases.Tokens.Commands.RefreshTokenCommand;

public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, Result<TokenModel>>
{
    private readonly UserManager<FinanceManagerUser> _userManager;
    private readonly RoleManager<FinanceManagerRole> _roleManager;
    private readonly AuthConfiguration _authConfigs;

    public RefreshTokenHandler(UserManager<FinanceManagerUser> userManager,
        RoleManager<FinanceManagerRole> roleManager,
        IOptions<AuthConfiguration> authConfig)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        _authConfigs = authConfig.Value ?? throw new ArgumentNullException(nameof(authConfig.Value));
    }

    public async Task<Result<TokenModel>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(request.Token) || String.IsNullOrWhiteSpace(request.RefreshToken))
        {
            return await Result<TokenModel>.FailAsync("Invalid Client Token.");
        }
        var userPrincipal = GetPrincipalFromExpiredToken(request.Token);
        var userEmail = userPrincipal.FindFirstValue(ClaimTypes.Email);
        var user = await _userManager.FindByEmailAsync(userEmail);
        if (user == null)
            return await Result<TokenModel>.FailAsync("User Not Found.");
        if (user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            return await Result<TokenModel>.FailAsync("Invalid Client Token.");
        var newToken = GenerateEncryptedToken(GetSigningCredentials(), await GetClaimsAsync(user));
        user.RefreshToken = GenerateRefreshToken();
        await _userManager.UpdateAsync(user);

        var response = new TokenModel { Token = request.Token, RefreshToken = user.RefreshToken, RefreshTokenExpiryTime = user.RefreshTokenExpiryTime };
        return await Result<TokenModel>.SuccessAsync(response);
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

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
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

    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = _authConfigs.GetSymmetricSecurityKey(),
            ValidateIssuer = false,
            ValidateAudience = false,
            RoleClaimType = ClaimTypes.Role,
            ClockSkew = TimeSpan.Zero,
            ValidateLifetime = false
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
            StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }

    private SigningCredentials GetSigningCredentials()
    {
        return new(_authConfigs.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
    }
}
