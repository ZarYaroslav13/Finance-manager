using FinanceManager.Application.Models;
using FinanceManager.Web.Shared.Constants.Identity;
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

    internal static void SetExpireToken(this ClaimsIdentity claimsIdentity, string token)
        => claimsIdentity.AddClaim(new(IdentityConstants.AuthToken, token));

    internal static void SetRefreshToken(this ClaimsIdentity claimsIdentity, string token)
        => claimsIdentity.AddClaim(new(IdentityConstants.RefreshToken, token));

    internal static void SetExpireTime(this ClaimsIdentity claimsIdentity, string time)
        => claimsIdentity.AddClaim(new(IdentityConstants.ExpireTime, time));

    internal static void AddToken(this ClaimsIdentity claimsIdentity, TokenDTO token)
        => claimsIdentity.AddClaims(new List<Claim>
        {
            new(IdentityConstants.ExpireTime, token.Token),
            new(IdentityConstants.RefreshToken, token.RefreshToken),
            new(IdentityConstants.ExpireTime, token.RefreshTokenExpiryTime.ToString())
        });

    internal static void DeleteToken(this ClaimsIdentity claimsIdentity)
    {
        claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(IdentityConstants.ExpireTime));
        claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(IdentityConstants.RefreshToken));
        claimsIdentity.RemoveClaim(claimsIdentity.FindFirst(IdentityConstants.ExpireTime));
    }
}
