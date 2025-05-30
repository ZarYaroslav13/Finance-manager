using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Web.Pages.Authentication;
using FinanceManager.Web.Services;
using FinanceManager.Web.Services.APIServices.TokenManager;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.ViewModels.Pages;

public class LoginViewModel : BaseViewModel<Login>
{
    public GetTokenCommand LoginModel { get; set; } = new();

    public bool PasswordVisibility { get; private set; } = false;
    public InputType PasswordInput { get; private set; } = InputType.Password;
    public string PasswordInputIcon { get; private set; } = Icons.Material.Filled.VisibilityOff;

    private readonly ITokenManager _tokenManager;

    public LoginViewModel(ViewModelServicesLocator locator, ITokenManager tokenManager, IStringLocalizer<Login> localizer) : base(locator, localizer)
    {
        _tokenManager = tokenManager ?? throw new ArgumentNullException(nameof(tokenManager));
    }

    public async Task SubmitAsync()
    {
        //var result = await _apiClient.GetTokenAsync(LoginModel);
        //if(result.Succeeded)
        //    _snackBar.Add(string.Format(Localizer["Welcome {0}"], LoginModel.Email), Severity.Success);
        //else
        //    _snackBar.Add(string.Format(Localizer["Sorry {0}, I don`t recognize you!"], LoginModel.Email), Severity.Error);

        //_navigationManager.NavigateTo("/");
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
