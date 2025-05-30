using System.Security.Claims;
using Blazored.LocalStorage;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Shared.Constants.Storage;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.Services.Autorization.AuthenticationService;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly FinanceManagerStateProvider _authenticationStateProvider;
    private readonly IStringLocalizer<AuthenticationService> _localizer;
    public AuthenticationService(
            HttpClient httpClient,
            ILocalStorageService localStorage,
            FinanceManagerStateProvider authenticationStateProvider,
            IStringLocalizer<AuthenticationService> localizer)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
        _authenticationStateProvider = authenticationStateProvider ?? throw new ArgumentNullException(nameof(authenticationStateProvider));
        _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
    }

    public async Task<ClaimsPrincipal> CurrentUserAsync()
    {
        return (await _authenticationStateProvider.GetAuthenticationStateAsync()).User;
    }

    public async Task<Domain.Wrapper.IResult> LoginAsync(GetTokenCommand model)
    {
        //var response = await _httpClient.PostAsJsonAsync(APIEndpoints.Token.Get, model);
        var result = Result<TokenDTO>.Success();//await response.ToResultAsync<TokenDTO>()

        if (result.Succeeded)
        {
            var jwtToken = result.Data.Token;
            var refreshToken = result.Data.RefreshToken;


            await RewriteTokens(jwtToken, refreshToken);

            await _authenticationStateProvider.StateChangedAsync();

            return Result.Success();
        }

        return Result.Fail();
    }

    public async Task<string> RefreshTokenAsync()
    {
        var token = await _localStorage.GetItemAsync<string>(StorageConstants.AuthToken);
        var refreshToken = await _localStorage.GetItemAsync<string>(StorageConstants.RefreshToken);

        // var response = await _httpClient.PostAsJsonAsync(APIEndpoints.Token.Refresh, new RefreshTokenCommand() { Token = token, RefreshToken = refreshToken });
        var result = Result<TokenDTO>.Success();// await response.ToResultAsync<TokenDTO>();

        if (!result.Succeeded)
        {
            throw new ApplicationException(_localizer["Something went wrong during the refresh token action"]);
        }

        token = result.Data.Token;
        refreshToken = result.Data.RefreshToken;

        await RewriteTokens(token, refreshToken);

        return token;
    }

    public async Task<string> TryRefreshTokenAsync()
    {
        var refreshToken = await _localStorage.GetItemAsync<string>(StorageConstants.RefreshToken);

        if (String.IsNullOrEmpty(refreshToken)) return String.Empty;

        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        var exp = user.FindFirst(c => c.Type.Equals("exp"))?.Value;
        var expTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));
        var timeUTC = DateTime.UtcNow;
        var diff = expTime - timeUTC;
        if (diff.TotalMinutes <= 1)
            return await RefreshTokenAsync();
        return string.Empty;
    }

    public async Task<Domain.Wrapper.IResult> LogoutAsync()
    {
        await _localStorage.RemoveItemAsync(StorageConstants.AuthToken);
        await _localStorage.RemoveItemAsync(StorageConstants.RefreshToken);

        _authenticationStateProvider.MarkUserAsLoggedOut();

        _httpClient.DefaultRequestHeaders.Authorization = null;

        return Result.Success();
    }

    private async Task RewriteTokens(string token, string refreshToken)
    {
        await _localStorage.SetItemAsync(StorageConstants.AuthToken, token);
        await _localStorage.SetItemAsync(StorageConstants.RefreshToken, refreshToken);

        _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", token);
    }

}
