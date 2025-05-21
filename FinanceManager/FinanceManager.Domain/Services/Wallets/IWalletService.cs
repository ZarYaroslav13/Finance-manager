using FinanceManager.Domain.Models;

namespace FinanceManager.Domain.Services.Wallets;

public interface IWalletService
{
    public Task<List<WalletModel>> GetAllWalletsOfAccountAsync(Guid accountId);

    public Task<WalletModel> AddWalletAsync(WalletModel wallet);

    public Task<WalletModel> UpdateWalletAsync(WalletModel updatedWallet);

    public Task DeleteWalletByIdAsync(Guid id);

    public Task<WalletModel> FindWalletAsync(Guid id);

    public Task<bool> IsCallerWalletOwner(Guid walletId);
}
