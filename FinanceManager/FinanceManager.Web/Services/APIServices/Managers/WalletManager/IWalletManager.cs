using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Application.UseCases.Wallets.Commands.UpdateWalletCommand;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIServices.Managers.WalletManager;

public interface IWalletManager : IManager
{
    public Task<Result<List<WalletDTO>>> GetWalletsAsync(Guid userId);

    public Task<Result<WalletDTO>> GetWalletAsync(Guid id);

    public Task<Result<WalletDTO>> AddWallet(CreateWalletCommand command);

    public Task<Result<WalletDTO>> UpdateWallet(UpdateWalletCommand command);

    public Task<Result> DeleteWalletAsync(Guid id);
}
