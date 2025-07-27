using FinanceManager.Application.Services.Token;
using FinanceManager.Domain.UseCases.Commons.Tokens.Commands.GetTokenCommand;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.Managers.TokenManager;
using FinanceManager.Web.Services.Autorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanceManager.Web.Extentions.HostBuilder.MinimalApi;

public static class AddMinimalApiHostExtention
{

    public static void AddMinimalApi(this WebApplication? app)
    {
        app.MapGet(MinimalApiEndpoints.Downloads.Report, async (
            HttpContext context,
            string name,
            IWebHostEnvironment env) =>
        {
            var reportDirectory = Path.Combine(env.WebRootPath, "reports");
            var fullPath = Path.Combine(reportDirectory, name);

            if (!File.Exists(fullPath))
            {
                return Results.NotFound();
            }

            var provider = new Microsoft.AspNetCore.StaticFiles.FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fullPath, out var contentType))
                contentType = "application/octet-stream";

            var fileName = Path.GetFileName(fullPath);
            var fileStream = File.OpenRead(fullPath);

            return Results.File(fileStream, contentType, fileName);
        });

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

        app.MapPost(MinimalApiEndpoints.Authentication.Logout, async (HttpContext context) =>
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            context.Response.Cookies.Delete("FMAuthCookie");
            context.Response.Redirect("/authentication/login");
        });

        app.MapPost(MinimalApiEndpoints.Localization.ChangeCulture, (HttpContext context, [FromBody] string cultureCode) =>
        {
            var culture = new RequestCulture(cultureCode);
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(culture);

            context.Response.Cookies.Append(
              CookieRequestCultureProvider.DefaultCookieName,
              cookieValue,
              new CookieOptions
              {
                  Expires = DateTimeOffset.UtcNow.AddYears(1),
                  HttpOnly = true,
                  IsEssential = true,
                  Secure = true,
                  SameSite = SameSiteMode.Lax
              });

            return Results.Ok();
        }).AllowAnonymous();

    }
}
