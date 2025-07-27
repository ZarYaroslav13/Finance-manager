using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.Wallets.Commands;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Application.Services.Wallets;

public interface IWalletService
{
    public Task<Result<List<WalletDTO>>> GetAllWalletsOfAccountAsync(Guid accountId);

    public Task<Result<WalletDTO>> FindWalletAsync(Guid id);

    public Task<Result<WalletDTO>> AddWalletAsync(CreateWalletRequest request);

    public Task<Result<WalletDTO>> UpdateWalletAsync(UpdateWalletRequest request);

    public Task<IResult> DeleteWalletByIdAsync(Guid id);

    public Task<IResult<bool>> IsCallerWalletOwnerAsync(Guid walletId);
}
