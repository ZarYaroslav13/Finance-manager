using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Web.Components.Pages.Authentication;
using FinanceManager.Web.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using MudBlazor;

namespace FinanceManager.Web.ViewModels.Components.Pages.Authorization;
public class LoginViewModel : BaseViewModel<Login>
{
    public GetTokenCommand LoginModel { get; set; } = new();

    public EditContext EditContext { get; set; }
    public bool IsLoginModelValid => EditContext.Validate();

    public bool PasswordVisibility { get; private set; } = false;
    public InputType PasswordInput { get; private set; } = InputType.Password;
    public string PasswordInputIcon { get; private set; } = Icons.Material.Filled.VisibilityOff;

    private readonly IJSRuntime _jSRuntime;
    public LoginViewModel(IJSRuntime jSRuntime, ViewModelServicesLocator locator, IStringLocalizer<Login> localizer) : base(locator, localizer)
    {
        _jSRuntime = jSRuntime ?? throw new ArgumentNullException(nameof(jSRuntime));
        EditContext = new(LoginModel);
    }

    public async Task SubmitAsync()
    {
        await _jSRuntime.InvokeVoidAsync("loginUser", LoginModel.Email, LoginModel.Password);
    }

    public void FillUserAsync()
    {
        LoginModel.Email = "john.doe@example.com";
        LoginModel.Password = "protectedPassword123";
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

