using FinanceManager.Application.UseCases.Login.Commands.SignInCommand;

namespace FinanceManager.Web.ViewModels;

public class LoginViewModel
{
    public SignInCommand LoginModel { get; set; }

    public async Task SubmitAsync()
    {

    }
}
