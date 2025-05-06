using FinanceManager.Application.Security;
using FinanceManager.Application.UseCases.Login.Commands.SignInCommand;

namespace FinanceManager.Web.Services.UserService;

public interface IUserService
{
    public Task<User?> SendAuthenticateRequestAsync(SignInCommand command);
}
