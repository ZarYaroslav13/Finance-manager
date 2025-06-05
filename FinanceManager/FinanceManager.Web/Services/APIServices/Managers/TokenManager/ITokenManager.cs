using System.Security.Claims;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIServices.Managers.TokenManager;

public interface ITokenManager : IManager
{
    Task<Result<TokenDTO>> LoginAsync(GetTokenCommand model);

    Task<string> RefreshTokenAsync();

    Task<string> TryRefreshTokenAsync();

    Task<ClaimsPrincipal> CurrentUserAsync();

    Task<Domain.Wrapper.IResult> LogoutAsync();
}
