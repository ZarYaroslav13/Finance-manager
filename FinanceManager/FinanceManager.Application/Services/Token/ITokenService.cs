using FinanceManager.Application.Models;
using FinanceManager.Domain.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Domain.UseCases.Tokens.Commands.RefreshTokenCommand;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Application.Services.Token;

public interface ITokenService
{
    public Task<Result<TokenDTO>> LoginAsync(GetTokenCommand command);

    public Task<Result<TokenDTO>> GetRefreshTokenAsync(RefreshTokenCommand command);

}
