using AutoMapper;
using Blazored.LocalStorage;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.TokenManager;
using FinanceManager.Web.Services.Autorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels;

public abstract class BaseViewModel<T> : IViewModel where T : class
{
    public IStringLocalizer<T> Localizer { get; }
    protected readonly FinanceManagerStateProvider _stateProvider;
    protected readonly IHttpContextAccessor _httpContextAccessor;
    protected readonly HttpClient _httpClient;
    protected readonly NavigationManager _navigationManager;
    protected readonly ISnackbar _snackBar;
    protected readonly ITokenManager _tokenManager;
    protected readonly IDialogService _dialogService;
    protected readonly ILocalStorageService _localStorage;
    protected readonly IMapper _mapper;

    protected BaseViewModel(ViewModelServicesLocator locator, IStringLocalizer<T> localizer)
    {
        ArgumentNullException.ThrowIfNull(locator);
        Localizer = localizer ?? throw new ArgumentNullException(nameof(locator));
        _stateProvider = locator.StateProvider;
        _httpContextAccessor = locator.HttpContextAccessor;
        _httpClient = locator.HttpClient;
        _navigationManager = locator.NavigationManager;
        _snackBar = locator.SnackBar;
        _tokenManager = locator.TokenManager;
        _dialogService = locator.DialogService;
        _localStorage = locator.LocalStorageService;
        _mapper = locator.Mapper;
    }
}
