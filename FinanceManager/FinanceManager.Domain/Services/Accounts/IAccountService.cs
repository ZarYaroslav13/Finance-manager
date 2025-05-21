using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Domain.Services.Accounts;

public interface IAccountService
{
    public Task<IResult> UpdateAccountAsync(UserModel updatedAccount);

    public Task<IResult> ChangePasswordAsync(Guid id, string oldPassword, string newPassword);
}
