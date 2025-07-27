using FinanceManager.Application.Models.Requests.Account.Commands;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Application.Services.Accounts;

public interface IAccountService
{
    public Task<IResult> UpdateAccountAsync(UpdateAccountRequest request);

    public Task<IResult> ChangePasswordAsync(ChangeUserPasswordRequest request);
}
