using FinanceManager.Application.Models.Base;
using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Web.Components.Pages.Personal;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services;
using FinanceManager.Web.Shared.Dialogs.Account;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels.Components.Pages.Personal;

public class AccountViewModel : BaseViewModel<Account>
{
    public UserDTO AccountModel { get; set; } = new();

    public AccountViewModel(ViewModelServicesLocator locator, IStringLocalizer<Account> localizer) : base(locator, localizer)
    {
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
            Roles = user.GetUserRoles()
        };
    }

    public async Task UpdateAccount()
    {
        var parameters = new DialogParameters<UpdateAccountDialog>() { { x => x.CurrentInfo, _mapper.Map<UpdateAccountCommand>(AccountModel) } };

        await _dialogService.ShowAsync<UpdateAccountDialog>("Update", parameters);
    }

    public async Task ChangeUserPassword()
    {
        var parameters = new DialogParameters<ChangePasswordDialog>() { { x => x.UserId, AccountModel.Id } };
        await _dialogService.ShowAsync<ChangePasswordDialog>("Update", parameters);
    }
}
