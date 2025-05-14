using System.Security.Claims;

namespace FinanceManager.Application.Security.Token;

public interface ITokenManager
{
    public string CreateToken(ClaimsIdentity identity);

    public Task<ClaimsIdentity> GetIdentityAsync(string email, string password);

    public Task<ClaimsIdentity> GetAdminIdentityAsync(string email, string password);
}
