using FinanceManager.Application.UseCases.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.WalletManager;
using FinanceManager.Web.Shared.Dialogs.Wallets;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.ViewModels.Dialogs.Wallets;

public class AddWalletDialogViewModel : BaseViewModel<AddWalletDialog>
{
    private CreateWalletCommand _createModel = new();
    public CreateWalletCommand CreationModel
    {
        get => _createModel;
        set { _createModel = value; EditContext = new(_createModel); }
    }

    public EditContext EditContext { get; set; }

    public bool IsModelValid => EditContext.Validate();

    public bool Adding { get; set; } = false;

    private readonly IWalletManager _walletManager;

    public AddWalletDialogViewModel(IWalletManager walletManager,
        ViewModelServicesLocator locator, IStringLocalizer<AddWalletDialog> localizer) : base(locator, localizer)
    {
        _walletManager = walletManager ?? throw new ArgumentNullException(nameof(walletManager));

        _createModel.UserId = new(_httpContextAccessor.HttpContext.User.GetUserId());

        EditContext = new(_createModel);
    }

    public async Task TryToCreate()
    {
        Adding = true;

        var result = await _walletManager.AddWallet(CreationModel);

        Adding = false;

        if (result.Succeeded)
            _snackBar.Add(Localizer["Wallet added successfully!"], MudBlazor.Severity.Success);
    }
}
