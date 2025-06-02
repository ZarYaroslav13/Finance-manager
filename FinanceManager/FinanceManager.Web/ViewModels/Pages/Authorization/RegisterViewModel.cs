using FinanceManager.Application.UseCases.Users.Commands.RegisterCommand;
using FinanceManager.Web.Pages.Authentication;
using FinanceManager.Web.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels.Pages.Authorization;

public class RegisterViewModel : BaseViewModel<Register>
{
    public RegisterCommand RegistrationModel { get; set; } = new();

    public EditContext EditContext { get; set; }

    public bool IsRegistrationModelValid => EditContext.Validate();
    public bool PasswordVisibility { get; private set; } = false;
    public InputType PasswordInput { get; private set; } = InputType.Password;
    public string PasswordInputIcon { get; private set; } = Icons.Material.Filled.VisibilityOff;

    public RegisterViewModel(ViewModelServicesLocator locator, IStringLocalizer<Register> localizer) : base(locator, localizer)
    {
        EditContext = new(RegistrationModel);
    }

    public async Task SubmitAsync()
    {
        _snackBar.Add(string.Format(Localizer["Welcome {0}"], RegistrationModel.Email), Severity.Success);

        _navigationManager.NavigateTo("/login");
    }

    public void TogglePasswordVisibility()
    {
        if (PasswordVisibility)
        {
            PasswordVisibility = false;
            PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
            PasswordInput = InputType.Password;
        }
        else
        {
            PasswordVisibility = true;
            PasswordInputIcon = Icons.Material.Filled.Visibility;
            PasswordInput = InputType.Text;
        }
    }
}
