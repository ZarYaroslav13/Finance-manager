using FinanceManager.Application.Models.Requests.Account.Commands;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Application.Services.Accounts;

public interface IAccountService
{
    public Task<IResult> UpdateAccountAsync(UpdateAccountRequest request);

    public Task<IResult> ChangePasswordAsync(ChangeUserPasswordRequest request);
}
