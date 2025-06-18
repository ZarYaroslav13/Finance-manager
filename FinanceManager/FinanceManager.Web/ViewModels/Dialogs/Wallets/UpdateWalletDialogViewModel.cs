using FinanceManager.Application.UseCases.Wallets.Commands.UpdateWalletCommand;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.WalletManager;
using FinanceManager.Web.Shared.Dialogs.Wallets;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.ViewModels.Dialogs.Wallets;

public class UpdateWalletDialogViewModel : BaseViewModel<UpdateWalletDialog>
{
    private UpdateWalletCommand _updateModel = new();
    public UpdateWalletCommand UpdateModel
    {
        get => _updateModel;
        set { _updateModel = value; EditContext = new(_updateModel); }
    }

    public EditContext EditContext { get; set; }

    public bool IsModelValid => EditContext.Validate();

    public bool Updating { get; set; } = false;

    private readonly IWalletManager _walletManager;

    public UpdateWalletDialogViewModel(IWalletManager walletManager,
        ViewModelServicesLocator locator, IStringLocalizer<UpdateWalletDialog> localizer) : base(locator, localizer)
    {
        _walletManager = walletManager ?? throw new ArgumentNullException(nameof(walletManager));

        EditContext = new(_updateModel);
    }

    public async Task TryToUpdate()
    {
        Updating = true;

        var result = await _walletManager.UpdateWallet(UpdateModel);

        Updating = false;

        if (result.Succeeded)
            _snackBar.Add(Localizer["Wallet updated successfully!"], MudBlazor.Severity.Success);
    }
}