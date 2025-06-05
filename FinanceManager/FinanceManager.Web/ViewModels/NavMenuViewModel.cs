using FinanceManager.Domain.Authorization;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services;
using FinanceManager.Web.Shared.Components;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.ViewModels;

public class NavMenuViewModel : BaseViewModel<NavMenu>
{
    public bool CanViewAdminMenu { get; } = false;

    public NavMenuViewModel(ViewModelServicesLocator locator, IStringLocalizer<NavMenu> localizer) : base(locator, localizer)
    {
        CanViewAdminMenu = _httpContextAccessor.HttpContext.User.GetUserRoles().Any(r => r == PolicyManager.AdminRole);
    }
}
