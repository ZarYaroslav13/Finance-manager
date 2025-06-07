using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Application.UseCases.Tokens.Commands.RefreshTokenCommand;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services.APIServices.APIHttpClient;
using FinanceManager.Web.Services.Autorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace FinanceManager.Web.Services.APIServices.Managers.TokenManager;

public class TokenManager : ITokenManager
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IFinanceManagerApiHttpClient _apiHttpClient;
    private readonly FinanceManagerStateProvider _authenticationStateProvider;
    private readonly IStringLocalizer<TokenManager> _localizer;
    public TokenManager(
            HttpClient httpClient,
            IHttpContextAccessor httpContextAccessor,
            IFinanceManagerApiHttpClient apiHttpClient,
            FinanceManagerStateProvider authenticationStateProvider,
            IStringLocalizer<TokenManager> localizer)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _apiHttpClient = apiHttpClient ?? throw new ArgumentNullException(nameof(apiHttpClient));
        _authenticationStateProvider = authenticationStateProvider ?? throw new ArgumentNullException(nameof(authenticationStateProvider));
        _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
    }

    public async Task<ClaimsPrincipal> CurrentUserAsync()
    {
        return (await _authenticationStateProvider.GetAuthenticationStateAsync()).User;
    }

    public async Task<Result<TokenDTO>> LoginAsync(GetTokenCommand model)
    {
        var response = await _apiHttpClient.GetTokenAsync(model);
        return response;
    }

    public async Task<string> TryRefreshTokenAsync()
    {
        var refreshToken = _httpContextAccessor.HttpContext?.User.GetRefreshToken();

        if (string.IsNullOrEmpty(refreshToken)) return string.Empty;

        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        var expTime = DateTime.Parse(user.GetExpireTime());
        var timeUTC = DateTime.UtcNow;
        var diff = expTime - timeUTC;

        if (diff.TotalMinutes <= 1)
            return await RefreshTokenAsync();

        return refreshToken;
    }
    public async Task<string> RefreshTokenAsync()
    {
        var user = _httpContextAccessor.HttpContext?.User;
        ArgumentNullException.ThrowIfNull(user);

        var token = user.GetExpireToken();
        var refreshToken = user.GetRefreshToken();
        ArgumentNullException.ThrowIfNullOrWhiteSpace(token);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(refreshToken);

        var response = await _apiHttpClient.RefreshTokenAsync(new RefreshTokenCommand()
        {
            Token = token,
            RefreshToken = refreshToken
        });

        if (!response.Succeeded)
        {
            await LogoutAsync();
            throw new ApplicationException(_localizer["Something went wrong during the refresh token action"]);
        }

        var identity = (ClaimsIdentity)user.Identity;

        identity.DeleteToken();
        identity.AddToken(response.Data);

        await _httpContextAccessor.HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity),
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = response.Data.RefreshTokenExpiryTime
            });


        return response.Data.Token;
    }

    public async Task<Domain.Wrapper.IResult> LogoutAsync()
    {
        await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        _authenticationStateProvider.MarkUserAsLoggedOut();

        _httpClient.DefaultRequestHeaders.Authorization = null;

        return Result.Success();
    }
}
