using System.Security.Claims;
using Blazored.LocalStorage;
using FinanceManager.Application.Security.Token;
using FinanceManager.Web.Shared.Constants.Storage;
using Microsoft.AspNetCore.Components.Authorization;

namespace FinanceManager.Web.Services.Autorization;

public class FinanceManagerStateProvider : AuthenticationStateProvider
{
    public ClaimsPrincipal AuthenticationStateUser { get; private set; }

    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly ITokenManager _tokenManager;

    public FinanceManagerStateProvider(
        HttpClient httpClient,
        ILocalStorageService localStorage)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
    }

    public async Task StateChangedAsync()
    {
        var authState = Task.FromResult(await GetAuthenticationStateAsync());

        NotifyAuthenticationStateChanged(authState);
    }

    public void MarkUserAsLoggedOut()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonymousUser));

        NotifyAuthenticationStateChanged(authState);
    }

    public async Task<ClaimsPrincipal> GetAuthenticationStateProviderUserAsync()
    {
        var state = await GetAuthenticationStateAsync();
        var authenticationStateProviderUser = state.User;
        return authenticationStateProviderUser;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var savedToken = await _localStorage.GetItemAsync<string>(StorageConstants.AuthToken);
        if (string.IsNullOrWhiteSpace(savedToken))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        _httpClient.DefaultRequestHeaders.Authorization = new("Bearer", savedToken);
        var state = new AuthenticationState(new(TokenManager.GetIdentityFromJwtToken(savedToken)));
        AuthenticationStateUser = state.User;
        return state;
    }
}
