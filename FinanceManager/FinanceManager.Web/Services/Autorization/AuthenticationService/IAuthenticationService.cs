using System.Security.Claims;
using FinanceManager.Application.UseCases.Login.Commands.SignInAdminCommand;
using FinanceManager.Application.UseCases.Login.Commands.SignInCommand;

namespace FinanceManager.Web.Services.Autorization.AuthenticationService;

public interface IAuthenticationService
{
    Task<Shared.Wrapper.IResult> LoginAsync(SignInCommand model);

    Task<Shared.Wrapper.IResult> LoginAdminAsync(SignInAdminCommand model);

    Task<string> RefreshTokenAsync();

    Task<string> TryRefreshTokenAsync();

    Task<ClaimsPrincipal> CurrentUserAsync();

    Task<Shared.Wrapper.IResult> LogoutAsync();
}
