using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Base;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Web.Shared.Constants.Identity;
using System.Globalization;
using System.Security.Claims;

namespace FinanceManager.Web.Extentions;

public static class IdentityExtention
{
    internal static string GetEmail(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.FindFirstValue(ClaimTypes.Email);

    internal static string GetFirstName(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirstValue(ClaimTypes.Name);

    internal static string GetLastName(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirstValue(ClaimTypes.Surname);

    internal static string GetUserId(this ClaimsPrincipal claimsPrincipal)
       => claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

    internal static List<string> GetUserRoles(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();

    internal static string GetExpireToken(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirstValue(IdentityConstants.AuthToken);

    internal static string GetRefreshToken(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirstValue(IdentityConstants.RefreshToken);

    internal static string GetExpireTime(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal.FindFirstValue(IdentityConstants.ExpireTime);

    internal static void SetUserInformatiom(this ClaimsIdentity claimsIdentity, UserDTO user)
    {
        claimsIdentity.RemoveUserInformation();

        claimsIdentity.AddClaim(new(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claimsIdentity.AddClaim(new(ClaimTypes.Name, user.FirstName));
        claimsIdentity.AddClaim(new(ClaimTypes.Surname, user.LastName));
        claimsIdentity.AddClaim(new(ClaimTypes.Email, user.Email));
    }

    internal static void SetUserInformatiom(this ClaimsIdentity claimsIdentity, UpdateAccountCommand command)
    {
        claimsIdentity.RemoveUserInformation();

        claimsIdentity.AddClaim(new(ClaimTypes.NameIdentifier, command.Id.ToString()));
        claimsIdentity.AddClaim(new(ClaimTypes.Name, command.FirstName));
        claimsIdentity.AddClaim(new(ClaimTypes.Surname, command.LastName));
        claimsIdentity.AddClaim(new(ClaimTypes.Email, command.Email));
    }

    internal static void SetExpireToken(this ClaimsIdentity claimsIdentity, string token)
        => claimsIdentity.AddClaim(new(IdentityConstants.AuthToken, token));

    internal static void SetRefreshToken(this ClaimsIdentity claimsIdentity, string token)
        => claimsIdentity.AddClaim(new(IdentityConstants.RefreshToken, token));

    internal static void SetExpireTime(this ClaimsIdentity claimsIdentity, string time)
        => claimsIdentity.AddClaim(new(IdentityConstants.ExpireTime, time));

    internal static void AddToken(this ClaimsIdentity claimsIdentity, TokenDTO token)
        => claimsIdentity.AddClaims(new List<Claim>
        {
            new(IdentityConstants.AuthToken, token.Token),
            new(IdentityConstants.RefreshToken, token.RefreshToken),
            new(IdentityConstants.ExpireTime, token.RefreshTokenExpiryTime.ToString("o", CultureInfo.InvariantCulture))
        });

    internal static void DeleteToken(this ClaimsIdentity claimsIdentity)
    {
        claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(IdentityConstants.ExpireTime));
        claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(IdentityConstants.RefreshToken));
        claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(IdentityConstants.ExpireTime));
    }

    private static void RemoveUserInformation(this ClaimsIdentity claimsIdentity)
    {
        claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(ClaimTypes.Email));
        claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier));
        claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(ClaimTypes.Name));
        claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(ClaimTypes.Surname));
    }
}
