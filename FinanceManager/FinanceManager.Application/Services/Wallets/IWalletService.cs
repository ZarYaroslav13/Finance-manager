using FinanceManager.Application.Models;
using FinanceManager.Domain.UseCases.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Application.Services.Wallets;

public interface IWalletService
{
    public Task<Result<List<WalletDTO>>> GetAllWalletsOfAccountAsync(Guid accountId);

    public Task<Result<WalletDTO>> FindWalletAsync(Guid id);

    public Task<Result<WalletDTO>> AddWalletAsync(CreateWalletCommand command);

    public Task<Result<WalletDTO>> UpdateWalletAsync(WalletDTO updatedWallet);

    public Task<IResult> DeleteWalletByIdAsync(Guid id);
}
