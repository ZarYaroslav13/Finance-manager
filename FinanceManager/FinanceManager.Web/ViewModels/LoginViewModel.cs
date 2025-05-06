using FinanceManager.Application.UseCases.Login.Commands.SignInCommand;
using FinanceManager.Web.Pages.Authentication;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.UserService;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels;

public class LoginViewModel : BaseViewModel<Login>
{
    public SignInCommand LoginModel { get; set; } = new();

    public bool PasswordVisibility { get; private set; } = false;
    public InputType PasswordInput { get; private set; } = InputType.Password;
    public string PasswordInputIcon { get; private set; } = Icons.Material.Filled.VisibilityOff;

    private IUserService _userService;

    public LoginViewModel(ViewModelServicesLocator locator, IStringLocalizer<Login> localizer, IUserService userService) : base(locator, localizer)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task SubmitAsync()
    {
        _userService.SendAuthenticateRequestAsync(LoginModel);
        _snackBar.Add(string.Format(Localizer["Welcome {0}"], LoginModel.Email), Severity.Success);
        _navigationManager.NavigateTo("/");
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
