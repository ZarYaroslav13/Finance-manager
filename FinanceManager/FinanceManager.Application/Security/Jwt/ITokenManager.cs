using System.Security.Claims;

namespace FinanceManager.Application.Security.Jwt;

public interface ITokenManager
{
    public string CreateToken(ClaimsIdentity identity);

    public Task<ClaimsIdentity> GetIdentityAsync(string email, string password);

    public Task<ClaimsIdentity> GetAdminIdentityAsync(string email, string password);

    public ClaimsIdentity GetIdentityFromJwtToken(string jwt);
}
