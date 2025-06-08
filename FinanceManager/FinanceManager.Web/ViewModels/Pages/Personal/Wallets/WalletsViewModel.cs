using FinanceManager.Application.Models;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Pages.Personal.WalletsPages;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.WalletManager;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.ViewModels.Pages.Personal.WalletsPages;

public class WalletsViewModel : BaseViewModel<Wallets>
{
    private List<WalletDTO> _wallets = new();
    public List<WalletDTO> Wallets
    {
        get => _wallets;
        set => _wallets = value;
    }

    private readonly IWalletManager _walletManager;
    public WalletsViewModel(IWalletManager walletManager,
        ViewModelServicesLocator locator, IStringLocalizer<Wallets> localizer) : base(locator, localizer)
    {
        _walletManager = walletManager ?? throw new ArgumentNullException(nameof(walletManager));
    }

    public async Task OnIntinalAsync()
    {
        var result = await _walletManager.GetWalletsAsync(new(_httpContextAccessor.HttpContext.User.GetUserId()));

        if (result.Succeeded)
        {
            _wallets = result.Data;
            return;
        }

        _wallets = new()
        {
            new() { Name = "Error, wallets not retrived", Balance = -1000}
        };
    }
}
