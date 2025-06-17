using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Application.UseCases.Wallets.Commands.UpdateWalletCommand;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;
using static FinanceManager.Domain.API.APIEndpoints;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

    public async Task<Result<WalletDTO>> AddWallet(CreateWalletCommand command)
    {
        return await SendRequest(async () => await _apiHttpClient.CreateWallet(command));
    }

    public async Task<Result<WalletDTO>> UpdateWallet(UpdateWalletCommand command)
    {
        return await SendRequest(async () => await _apiHttpClient.UpdateWallet(command));
    }

    public async Task<Domain.Wrapper.IResult> DeleteWalletAsync(Guid id)
    {
        return await SendRequest(async () => await _apiHttpClient.DeleteWallet(id));
    }
}
