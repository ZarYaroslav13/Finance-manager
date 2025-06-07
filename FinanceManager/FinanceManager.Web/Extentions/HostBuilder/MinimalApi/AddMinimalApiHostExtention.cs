using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Domain.Services.Token;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.Managers.TokenManager;
using FinanceManager.Web.Services.Autorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace FinanceManager.Web.Extentions.HostBuilder.MinimalApi;

public static class AddMinimalApiHostExtention
{

    public static void AddMinimalApi(this WebApplication? app)
    {
        app.MapPost(MinimalApiEndpoints.Authentication.Login,
            async (GetTokenCommand model,
                FinanceManagerStateProvider stateProvider,
                ITokenManager tokenManager,
                HttpContext context,
                ILogger<Program> logger) =>
        {
            try
            {
                var response = await tokenManager.LoginAsync(model);

                if (response.Succeeded)
                {
                    var jwtToken = response.Data.Token;
                    var refreshToken = response.Data.RefreshToken;

                    var claimIdentity = TokenService.GetIdentityFromJwtToken(response.Data.Token);
                    claimIdentity.AddToken(response.Data);

                    var claimPrincipal = new ClaimsPrincipal(claimIdentity);

                    var authProperities = new AuthenticationProperties()
                    {
                        IsPersistent = true,
                        ExpiresUtc = response.Data.RefreshTokenExpiryTime,
                        AllowRefresh = true,
                    };

                    await context.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        claimPrincipal,
                        authProperities);

                    return Results.Ok(Result.Success());
                }

                return Results.BadRequest(Result.Fail());
            }
            catch (Exception e)
            {
                return Results.BadRequest(Result.Fail(e.Message));
            }
        }).AllowAnonymous();
    }
}
