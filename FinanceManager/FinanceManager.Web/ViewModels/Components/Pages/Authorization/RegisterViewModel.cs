using FinanceManager.Application.UseCases.Users.Commands.RegisterCommand;
using FinanceManager.Web.Pages;
using FinanceManager.Web.Components.Pages.Authentication;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.Managers.IUserManager;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels.Components.Pages.Authorization;

public class RegisterViewModel : BaseViewModel<Register>
{
    public RegisterCommand RegistrationModel { get; set; } = new();

    public EditContext EditContext { get; set; }

    public bool IsRegistrationModelValid => EditContext.Validate();
    public bool PasswordVisibility { get; private set; } = false;
    public InputType PasswordInput { get; private set; } = InputType.Password;
    public string PasswordInputIcon { get; private set; } = Icons.Material.Filled.VisibilityOff;

    private readonly IUserManager _userManager;

    public RegisterViewModel(IUserManager userManager, ViewModelServicesLocator locator, IStringLocalizer<Register> localizer) : base(locator, localizer)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));

        EditContext = new(RegistrationModel);
    }

    public async Task SubmitAsync()
    {
        var response = await _userManager.RegisterUserAsync(RegistrationModel);
        if (response.Succeeded)
        {
            _snackBar.Add(response.Messages[0], Severity.Success);
            _navigationManager.NavigateTo(PagesHref.Authentication.Login);
            RegistrationModel = new();
        }
        else
        {
            foreach (var message in response.Messages)
            {
                _snackBar.Add(message, Severity.Error);
            }
        }
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
