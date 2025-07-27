using FinanceManager.Application.Models.Base;
using FinanceManager.Domain.UseCases.Commons.Accounts.Commands.UpdateAccountCommand;
using FinanceManager.Web.Components.Pages.Personal;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services;
using FinanceManager.Web.Shared.Dialogs.Accounts;
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

        var dialog = (DialogReference)await _dialogService.ShowAsync<UpdateAccountDialog>("Update", parameters);

        var result = await dialog.Result;

        if (!result.Canceled)
        {
            _snackBar.Add(string.Format(Localizer["Information updated successfully!"]), Severity.Success);
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
    }

    public async Task ChangeUserPassword()
    {
        var parameters = new DialogParameters<ChangePasswordDialog>() { { x => x.UserId, AccountModel.Id } };
        await _dialogService.ShowAsync<ChangePasswordDialog>("Update", parameters);
    }
}
