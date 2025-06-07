using FinanceManager.Application.Models.Base;
using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Pages.Personal;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.IAccountManager;
using FinanceManager.Web.Services.APIServices.Managers.IUserManager;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels.Pages.Personal;

public class AccountViewModel : BaseViewModel<Account>
{
    public UpdateAccountCommand AccountModel { get; set; } = new();

    #region Switch
    private bool _editMode;
    public bool EditMode { get => _editMode;
                    set => ChangeEditMode(value); }

    public string SwitchThumbIcon { get; set; }

    public Color SwitchThumbIconColor { get; set; }

    public string SwitchLabel { get; set; }

    public string SwitchLabelStyle { get; set; }

    public void ChangeEditMode(bool newMode)
    {
        _editMode = newMode;

        SwitchThumbIcon = _editMode ?
            Icons.Material.Rounded.Edit : Icons.Material.Rounded.EditOff;
        SwitchThumbIconColor = _editMode ?
            Color.Success : Color.Error;
        SwitchLabel = _editMode ?
            Localizer["EditMode is enabled!"] : Localizer["EditMode is disabled!"];
        SwitchLabelStyle = _editMode ?
            "color:green" : "color:red";
    }
    #endregion

    public EditContext EditContext { get; set; }

    public bool IsAccountModelValid => EditContext.Validate();

    private readonly IAccountManager _accountManager;
    private readonly IUserManager _userManager;

    public AccountViewModel(IUserManager userManager, IAccountManager accountManager,
        ViewModelServicesLocator locator, IStringLocalizer<Account> localizer) : base(locator, localizer)
    {
        _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));

        EditContext = new(AccountModel);
    }

    public void OnInitialized()
    {
        var user = _httpContextAccessor.HttpContext.User;
        AccountModel = new()
        {
            Id = new(user.GetUserId()),
            FirstName = user.GetFirstName(),
            LastName = user.GetLastName(),
            Email = user.GetEmail(),
            //Roles = user.GetUserRoles()
        };

        ChangeEditMode(false);
    }

    public async Task SubmitAsync()
    {

    }
}
