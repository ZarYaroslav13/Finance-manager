using System.Security.Claims;

namespace FinanceManager.Web.Services.Autorization.AuthenticationService;

public interface IAuthenticationService
{
    Task<Domain.Wrapper.IResult> LoginAsync(SignInCommand model);

    Task<Domain.Wrapper.IResult> LoginAdminAsync(SignInAdminCommand model);

    Task<string> RefreshTokenAsync();

    Task<string> TryRefreshTokenAsync();

    Task<ClaimsPrincipal> CurrentUserAsync();

    Task<Domain.Wrapper.IResult> LogoutAsync();
}
