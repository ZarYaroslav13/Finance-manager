using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Extentions.HostBuilder.MinimalApi;
using FinanceManager.Web.Pages.Authentication;
using FinanceManager.Web.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels.Pages.Authorization;

public class LoginViewModel : BaseViewModel<Login>
{
    public GetTokenCommand LoginModel { get; set; } = new();

    public EditContext EditContext { get; set; }

    public bool IsLoginModelValid => EditContext.Validate();

    public bool PasswordVisibility { get; private set; } = false;
    public InputType PasswordInput { get; private set; } = InputType.Password;
    public string PasswordInputIcon { get; private set; } = Icons.Material.Filled.VisibilityOff;

    public LoginViewModel(ViewModelServicesLocator locator, IStringLocalizer<Login> localizer) : base(locator, localizer)
    {
        EditContext = new(LoginModel);
    }

    public async Task SubmitAsync()
    {
        var result = await (await _httpClient.PostAsJsonAsync(
                                MinimalApiEndpoints.BaseUrl + MinimalApiEndpoints.Authentication.Login,
                                LoginModel))
                                .ToResultAsync();

        if (result.Succeeded)
        {
            _snackBar.Add(string.Format(Localizer["Welcome {0}"], LoginModel.Email), Severity.Success);
            var t = _httpContextAccessor.HttpContext.User.GetEmail();
        }
        else
            _snackBar.Add(string.Format(Localizer["Sorry {0}, I don`t recognize you!"], LoginModel.Email), Severity.Error);

        _navigationManager.NavigateTo("/home", forceLoad: true);
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
