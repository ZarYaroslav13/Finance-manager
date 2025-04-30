using FinanceManager.Domain.Models;

namespace FinanceManager.Domain.Services.Accounts;

public interface IAccountService
{
    public Task<List<AccountModel>> GetAccountsAsync(string userRole, int skip = 0, int take = 0);

    public Task<AccountModel> AddAccountAsync(AccountModel account);

    public Task<AccountModel> UpdateAccountAsync(AccountModel updatedAccount);

    public Task<AccountModel> UpdateAccountPasswordAsync(int id, string oldPassword, string newPassword);

    public void DeleteAccountWithId(int id);

    public Task<AccountModel> TrySignInAsync(string email, string password);

    public bool IsItEmail(string emailAddress);

    public Task<bool> CanTakeThisEmailAsync(int id, string emailAddress);
}
