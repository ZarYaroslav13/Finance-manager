using Blazored.LocalStorage;
using FinanceManager.Web.Services.APIServices.Managers.TokenManager;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace FinanceManager.Web.Services;

public class ViewModelServicesLocator
{
    public IHttpContextAccessor HttpContextAccessor;
    public HttpClient HttpClient { get; }

    public NavigationManager NavigationManager { get; }

    public ISnackbar SnackBar { get; }

    public ITokenManager TokenManager { get; }

    public IDialogService DialogService { get; }

    public ILocalStorageService LocalStorageService { get; }

    public ViewModelServicesLocator(
        IHttpContextAccessor httpContextAccessor,
        HttpClient httpClient,
        NavigationManager navigationManager,
        ISnackbar snackBar,
        ITokenManager tokenManager,
        IDialogService dialogService,
        ILocalStorageService localStorageService)
    {
        HttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        NavigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
        SnackBar = snackBar ?? throw new ArgumentNullException(nameof(snackBar));
        TokenManager = tokenManager ?? throw new ArgumentNullException(nameof(tokenManager));
        DialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        LocalStorageService = localStorageService ?? throw new ArgumentNullException(nameof(localStorageService));
    }
}
