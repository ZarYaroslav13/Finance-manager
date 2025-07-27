using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.Wallets.Commands;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Pages;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.WalletManager;
using FinanceManager.Web.Shared.Dialogs.Wallets;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels.Components.Pages.Personal.Wallets;

public class WalletsViewModel : BaseViewModel<Web.Components.Pages.Personal.WalletsPages.Wallets>
{
    private List<WalletDTO> _wallets = new();
    public List<WalletDTO> Wallets
    {
        get => _wallets;
        set => _wallets = value;
    }

    private readonly IWalletManager _walletManager;
    public WalletsViewModel(IWalletManager walletManager,
        ViewModelServicesLocator locator, IStringLocalizer<Web.Components.Pages.Personal.WalletsPages.Wallets> localizer) : base(locator, localizer)
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

    public void ShowWalletTypes(WalletDTO wallet)
    {
        _navigationManager.NavigateTo(PagesHref.Personal.FinanceOperationType.FinanceOperationTypes + '/' + wallet.Id);
    }
    public async Task CreateWallet()
    {
        var dialog = (DialogReference)await _dialogService.ShowAsync<AddWalletDialog>("Create");

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            _snackBar.Add(string.Format(Localizer["Wallet added successfully!"]), Severity.Success);
            var user = _httpContextAccessor.HttpContext.User;

            _wallets = (await _walletManager.GetWalletsAsync(new(user.GetUserId()))).Data;
        }
    }

    public async Task UpdateWallet(WalletDTO wallet)
    {
        var parameters = new DialogParameters<UpdateWalletDialog>() { { x => x.CurrentInfo, _mapper.Map<UpdateWalletRequest>(wallet) } };

        var dialog = (DialogReference)await _dialogService.ShowAsync<UpdateWalletDialog>(Localizer["Update"], parameters);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            _snackBar.Add(string.Format(Localizer["Wallet updated successfully!"]), Severity.Success);
            var updatedWallet = _mapper.Map<WalletDTO>((UpdateWalletRequest)result.Data);

            var index = _wallets.IndexOf(wallet);
            _wallets[index] = updatedWallet;
        }
    }

    public async Task DeleteWallet(Guid id)
    {
        bool confirm = await _dialogService.ShowMessageBox(
            Localizer["Warning"],
            Localizer["Are you realy want to delete this wallet?"],
            yesText: Localizer["Delete!"], cancelText: Localizer["Cancel"]) ?? false;

        if (!confirm)
            return;

        var result = await _walletManager.DeleteWalletAsync(id);

        if (!result.Succeeded)
        {
            _snackBar.Add(Localizer["Deleting failed"], Severity.Error);
            return;
        }

        _wallets.Remove(_wallets.First(w => w.Id == id));

        _snackBar.Add(Localizer["Deleting successfully"], Severity.Success);
    }
}
