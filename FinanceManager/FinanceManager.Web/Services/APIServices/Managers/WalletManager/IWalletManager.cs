using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.Wallets.Commands;
using FinanceManager.Domain.UseCases.Commons.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIServices.Managers.WalletManager;

public interface IWalletManager : IManager
{
    public Task<Result<List<WalletDTO>>> GetWalletsAsync(Guid userId);

    public Task<Result<WalletDTO>> GetWalletAsync(Guid id);

    public Task<Result<WalletDTO>> AddWallet(CreateWalletRequest request);

    public Task<Result<WalletDTO>> UpdateWallet(UpdateWalletRequest request);

    public Task<Domain.Wrapper.IResult> DeleteWalletAsync(Guid id);
}
