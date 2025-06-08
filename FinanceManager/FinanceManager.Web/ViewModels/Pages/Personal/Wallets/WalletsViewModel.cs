using FinanceManager.Web.Pages.Personal.WalletsPages;
using FinanceManager.Web.Services;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.ViewModels.Pages.Personal.WalletsPages;

public class WalletsViewModel : BaseViewModel<Wallets>
{
    public WalletsViewModel(ViewModelServicesLocator locator, IStringLocalizer<Wallets> localizer) : base(locator, localizer)
    {
    }
}
