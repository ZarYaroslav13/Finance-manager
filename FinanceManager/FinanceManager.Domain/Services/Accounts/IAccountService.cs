using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Domain.Services.Accounts;

public interface IAccountService
{
    public Task<IResult> UpdateAccountAsync(AccountModel updatedAccount);

    public Task<IResult> UpdatePasswordAsync(Guid id, string oldPassword, string newPassword);
}
