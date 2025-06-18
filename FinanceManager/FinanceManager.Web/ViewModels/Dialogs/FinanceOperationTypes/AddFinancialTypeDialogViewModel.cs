using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.FinanceOperationType;
using FinanceManager.Web.Services.APIServices.Managers.WalletManager;
using FinanceManager.Web.Shared.Dialogs.FinancialOperationTypes;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.ViewModels.Dialogs.FinanceOperationTypes;

public class AddFinancialTypeDialogViewModel : BaseViewModel<AddFinancialTypeDialog>
{
    private AddFinanceOperationTypeCommand _createModel = new();
    public AddFinanceOperationTypeCommand CreationModel
    {
        get => _createModel;
        set { _createModel = value; EditContext = new(_createModel); }
    }

    public EditContext EditContext { get; set; }

    public bool IsModelValid => EditContext.Validate();

    public bool Adding { get; set; } = false;

    public List<WalletDTO> Wallets { get; set; } = new();

    private readonly IWalletManager _walletManager;
    private readonly IFinanceOperationTypeManager _typeManager;

    public AddFinancialTypeDialogViewModel(IWalletManager walletManager, IFinanceOperationTypeManager typeManager,
        ViewModelServicesLocator locator, IStringLocalizer<AddFinancialTypeDialog> localizer) : base(locator, localizer)
    {
        _walletManager = walletManager ?? throw new ArgumentNullException(nameof(walletManager));
        _typeManager = typeManager ?? throw new ArgumentNullException(nameof(typeManager));

        EditContext = new(_createModel);
    }

    public async Task OnInitializedAsync()
    {
        var result = await _walletManager.GetWalletsAsync(new(_httpContextAccessor.HttpContext.User.GetUserId()));
        Wallets = result.Data;
    }

    public async Task TryToCreate()
    {
        Adding = true;

        var result = await _typeManager.AddTypeAsync(CreationModel);

        Adding = false;

        if (result.Succeeded)
            _snackBar.Add(Localizer["Financial type added successfully!"], MudBlazor.Severity.Success);
    }
}