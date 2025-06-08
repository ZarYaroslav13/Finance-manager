using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Application.UseCases.Wallets.Commands.UpdateWalletCommand;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;
using static FinanceManager.Domain.API.APIEndpoints;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinanceManager.Web.Services.APIServices.Managers.WalletManager;

public class WalletManager : BaseManager, IWalletManager
{
    public WalletManager(IFinanceManagerApiHttpClient httpClient) : base(httpClient)
    {
    }
    public async Task<Result<List<WalletDTO>>> GetWalletsAsync(Guid userId)
    {
        var result = await _httpClient.GetWalletsAsync(userId);

        return result;
    }

    public async Task<Result<WalletDTO>> GetWalletAsync(Guid id)
    {
        var result = await _httpClient.GetWalletAsync(id);

        return result;
    }

    public async Task<Result<WalletDTO>> AddWallet(CreateWalletCommand command)
    {
        var result = await _httpClient.CreateWallet(command);

        return result;
    }

    public async Task<Result<WalletDTO>> UpdateWallet(UpdateWalletCommand command)
    {
        var result = await _httpClient.UpdateWallet(command);

        return result;
    }

    public async Task<Result> DeleteWalletAsync(Guid id)
    {
        var result = await _httpClient.DeleteWallet(id);

        return result;
    }
}
