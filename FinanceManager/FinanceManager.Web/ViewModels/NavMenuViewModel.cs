using FinanceManager.Domain.Authorization;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.Autorization;
using FinanceManager.Web.Shared.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels;

public class NavMenuViewModel : BaseViewModel<NavMenu>
{
    private readonly FinanceManagerStateProvider _stateProvider;
    public bool CanViewAdminMenu { get; private set; } = false;

    public NavMenuViewModel(FinanceManagerStateProvider stateProvider, ViewModelServicesLocator locator, IStringLocalizer<NavMenu> localizer) : base(locator, localizer)
    {
        _stateProvider = stateProvider ?? throw new ArgumentNullException(nameof(stateProvider));
    }

    public async Task InitializationAsync()
    {
        var user = (await _stateProvider.GetAuthenticationStateProviderUserAsync());

        CanViewAdminMenu = user.GetUserRoles().Any(r => r == PolicyManager.AdminRole);
    }

    public async Task Logout()
    {
        var parameters = new DialogParameters
        {
                {nameof(Shared.Dialogs.Logout.Logout.ContentText), $"{Localizer["Logout Confirmation"]}"},
                {nameof(Shared.Dialogs.Logout.Logout.ButtonText), $"{Localizer["Logout"]}"},
                {nameof(Shared.Dialogs.Logout.Logout.Color), Color.Error}
            };

        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };

        await _dialogService.ShowAsync<Shared.Dialogs.Logout.Logout>(Localizer["Logout"], parameters, options);
    }
}
