using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Application.Services.Accounts;

public interface IAccountService
{
    public Task<IResult> UpdateAccountAsync(UpdateAccountCommand command);

    public Task<IResult> ChangePasswordAsync(ChangeUserPasswordCommand command);
}
