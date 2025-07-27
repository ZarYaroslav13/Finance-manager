using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.Tokens.Commands;
using FinanceManager.Domain.Wrapper;
using System.Security.Claims;

namespace FinanceManager.Web.Services.APIServices.Managers.TokenManager;

public interface ITokenManager : IManager
{
    Task<Result<TokenDTO>> LoginAsync(GetTokenRequest model);

    Task<string> RefreshTokenAsync();

    Task<string> TryRefreshTokenAsync();

    Task<ClaimsPrincipal> CurrentUserAsync();

    Task<Domain.Wrapper.IResult> LogoutAsync();
}
