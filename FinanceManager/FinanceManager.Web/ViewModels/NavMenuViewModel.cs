using System.Threading.Tasks;
using FinanceManager.Domain.Authorization;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.Autorization;
using FinanceManager.Web.Shared.Components;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.ViewModels;

public class NavMenuViewModel : BaseViewModel<NavMenu>
{
    private readonly FinanceManagerStateProvider _stateProvider;
    public bool CanViewAdminMenu { get; private set; } = false;

    public NavMenuViewModel(FinanceManagerStateProvider stateProvider, ViewModelServicesLocator locator, IStringLocalizer<NavMenu> localizer) : base(locator, localizer)
    {
        stateProvider = stateProvider ?? throw new ArgumentNullException(nameof(stateProvider));
    }

    public async Task InitializationAsync()
    {
        var user = (await _stateProvider.GetAuthenticationStateProviderUserAsync());

        CanViewAdminMenu = user.GetUserRoles().Any(r => r == PolicyManager.AdminRole);
    }
}
