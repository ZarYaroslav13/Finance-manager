using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.IAccountManager;
using FinanceManager.Web.Shared.Dialogs.Account;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels.Dialogs.Account;

public class ChangePasswordDialogViewModel : BaseViewModel<ChangePasswordDialog>
{
    private ChangeUserPasswordCommand _updateModel = new();
    public ChangeUserPasswordCommand UpdateModel { 
        get => _updateModel;
        set { _updateModel = value; EditContext = new(_updateModel); } }

    public EditContext EditContext { get; set; }

    public bool IsModelValid => EditContext.Validate();

    private readonly IAccountManager _accountManager;

    public ChangePasswordDialogViewModel(IAccountManager accountManager,
        ViewModelServicesLocator locator, IStringLocalizer<ChangePasswordDialog> localizer) : base(locator, localizer)
    {
        _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));

        EditContext = new(_updateModel);
    }

    public async Task TryToUpdate(Action navigateIsSuccess)
    {
        var result = await _accountManager.ChangePasswordAsync(UpdateModel);

        if(result.Succeeded)
            navigateIsSuccess();
    }
}
