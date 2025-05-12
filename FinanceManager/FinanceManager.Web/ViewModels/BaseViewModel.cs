using FinanceManager.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels;

public abstract class BaseViewModel<T> where T : class
{
    public IStringLocalizer<T> Localizer { get; }

    protected readonly HttpClient _httpClient;
    protected readonly NavigationManager _navigationManager;
    protected readonly ISnackbar _snackBar;

    protected BaseViewModel(ViewModelServicesLocator locator, IStringLocalizer<T> localizer)
    {
        ArgumentNullException.ThrowIfNull(locator);
        Localizer = localizer ?? throw new ArgumentNullException(nameof(locator));

        _httpClient = locator.HttpClient;
        _navigationManager = locator.NavigationManager;
        _snackBar = locator.SnackBar;
    }
}
