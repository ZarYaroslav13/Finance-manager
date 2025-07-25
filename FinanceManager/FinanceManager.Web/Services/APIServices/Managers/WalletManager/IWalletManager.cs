using FinanceManager.Application.Models;
using FinanceManager.Domain.UseCases.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIServices.Managers.WalletManager;

public interface IWalletManager : IManager
{
    public Task<Result<List<WalletDTO>>> GetWalletsAsync(Guid userId);

    public Task<Result<WalletDTO>> GetWalletAsync(Guid id);

    public Task<Result<WalletDTO>> AddWallet(CreateWalletCommand command);

    public Task<Result<WalletDTO>> UpdateWallet(WalletDTO wallet);

    public Task<Domain.Wrapper.IResult> DeleteWalletAsync(Guid id);
}
