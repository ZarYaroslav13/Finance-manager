using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIServices.TokenManager;

public interface ITokenManager
{
    public Task<Result<TokenDTO>> GetToken(GetTokenCommand command);
}
