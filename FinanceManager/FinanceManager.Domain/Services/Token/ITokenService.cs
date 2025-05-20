using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Domain.Services.Token;

public interface ITokenService
{
    public Task<Result<TokenModel>> LoginAsync(string email, string password);

    public Task<Result<TokenModel>> GetRefreshTokenAsync(string token, string refreshToken);

}
