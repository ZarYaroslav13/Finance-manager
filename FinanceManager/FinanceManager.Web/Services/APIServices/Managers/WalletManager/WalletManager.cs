using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.Wallets.Commands;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.Managers.WalletManager;

public class WalletManager : BaseManager, IWalletManager
{
    public WalletManager(
        IFinanceManagerApiHttpClient httpClient, ILogger<WalletManager> logger) : base(httpClient, logger)
    {
    }
    public async Task<Result<List<WalletDTO>>> GetWalletsAsync(Guid userId)
    {
        return await SendRequest(async () => await _apiHttpClient.GetWalletsAsync(userId));
    }

    public async Task<Result<WalletDTO>> GetWalletAsync(Guid id)
    {
        return await SendRequest(async () => await _apiHttpClient.GetWalletAsync(id));
    }

    public async Task<Result<WalletDTO>> AddWallet(CreateWalletRequest request)
    {
        return await SendRequest(async () => await _apiHttpClient.CreateWallet(request));
    }

    public async Task<Result<WalletDTO>> UpdateWallet(UpdateWalletRequest request)
    {
        return await SendRequest(async () => await _apiHttpClient.UpdateWallet(request));
    }

    public async Task<Domain.Wrapper.IResult> DeleteWalletAsync(Guid id)
    {
        return await SendRequest(async () => await _apiHttpClient.DeleteWallet(id));
    }
}
