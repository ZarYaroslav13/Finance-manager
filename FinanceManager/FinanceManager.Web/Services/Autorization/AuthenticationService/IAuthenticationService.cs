using System.Security.Claims;
using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;

namespace FinanceManager.Web.Services.Autorization.AuthenticationService;

public interface IAuthenticationService
{
    Task<Domain.Wrapper.IResult> LoginAsync(GetTokenCommand model);

    Task<Domain.Wrapper.IResult> LoginAdminAsync(GetTokenCommand model);

    Task<string> RefreshTokenAsync();

    Task<string> TryRefreshTokenAsync();

    Task<ClaimsPrincipal> CurrentUserAsync();

    Task<Domain.Wrapper.IResult> LogoutAsync();
}
