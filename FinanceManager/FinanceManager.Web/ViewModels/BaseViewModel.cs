using Blazored.LocalStorage;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.Autorization.AuthenticationService;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels;

public abstract class BaseViewModel<T> : IViewModel where T : class
{
    public IStringLocalizer<T> Localizer { get; }

    protected readonly NavigationManager _navigationManager;
    protected readonly ISnackbar _snackBar;
    protected readonly IAuthenticationService _authenticationService;
    protected readonly IDialogService _dialogService;
    protected readonly ILocalStorageService _localStorage;

    protected BaseViewModel(ViewModelServicesLocator locator, IStringLocalizer<T> localizer)
    {
        ArgumentNullException.ThrowIfNull(locator);
        Localizer = localizer ?? throw new ArgumentNullException(nameof(locator));

        //_httpClient = locator.HttpClient;
        _navigationManager = locator.NavigationManager;
        _snackBar = locator.SnackBar;
        _authenticationService = locator.AuthenticationService;
        _dialogService = locator.DialogService;
        _localStorage = locator.LocalStorageService;
    }
}
