using Blazored.LocalStorage;
using FinanceManager.Web.Shared.Constants.Storage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Linq;

namespace FinanceManager.Web.Services.Autorization;

public class FinanceManagerStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public FinanceManagerStateProvider(
        HttpClient httpClient,
        ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        throw new NotImplementedException();
    }
}
