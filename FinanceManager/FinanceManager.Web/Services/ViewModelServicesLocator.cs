using Blazored.LocalStorage;
using FinanceManager.Web.Services.Autorization.AuthenticationService;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace FinanceManager.Web.Services;

public class ViewModelServicesLocator
{
    //public HttpClient HttpClient { get; }

    public NavigationManager NavigationManager { get; }

    public ISnackbar SnackBar { get; }

    public IAuthenticationService AuthenticationService { get; }

    public IDialogService DialogService { get; }

    public ILocalStorageService LocalStorageService { get; }

    public ViewModelServicesLocator(
        //HttpClient httpClient,
        NavigationManager navigationManager,
        ISnackbar snackBar,
        IAuthenticationService authenticationService,
        IDialogService dialogService,
        ILocalStorageService localStorageService)
    {
        //HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        NavigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));
        SnackBar = snackBar ?? throw new ArgumentNullException(nameof(snackBar));
        AuthenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        DialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        LocalStorageService = localStorageService ?? throw new ArgumentNullException(nameof(localStorageService));
    }
}
