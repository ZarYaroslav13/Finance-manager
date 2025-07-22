using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.IAccountManager;
using FinanceManager.Web.Shared.Dialogs.Accounts;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace FinanceManager.Web.ViewModels.Dialogs.Accounts;

public class UpdateAccountDialogViewModel : BaseViewModel<UpdateAccountDialog>
{
    private UpdateAccountCommand _updateModel = new();
    public UpdateAccountCommand UpdateModel
    {
        get => _updateModel;
        set { _updateModel = value; EditContext = new(_updateModel); }
    }

    public EditContext EditContext { get; set; }

    public bool IsModelValid => EditContext.Validate();

    public bool Updating { get; set; } = false;

    private readonly IAccountManager _accountManager;

    public UpdateAccountDialogViewModel(IAccountManager accountManager,
        ViewModelServicesLocator locator, IStringLocalizer<UpdateAccountDialog> localizer) : base(locator, localizer)
    {
        _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));

        EditContext = new(_updateModel);
    }

    public async Task TryToUpdate(Action navigateIsSuccess)
    {
        Updating = true;

        var result = await _accountManager.UpdateProfileAsync(UpdateModel);


        Updating = false;

        if (result.Succeeded)
        {
            var user = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;

            user.SetUserInformatiom(UpdateModel);

            await _stateProvider.StateChangedAsync();

            navigateIsSuccess();
        }
    }
}
