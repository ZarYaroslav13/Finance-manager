using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.Models.Requests.Wallets.Commands;
using FinanceManager.Application.Services.Wallets;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class WalletController : BaseController
{
    private readonly IWalletService _walletService;

    public WalletController(IWalletService walletService)
    {
        _walletService = walletService ?? throw new ArgumentNullException(nameof(walletService));
    }

    [HttpGet("~/finance-manager/accounts/{accountId:guid}/wallets")]
    public async Task<IActionResult> GetWalletsAsync(Guid accountId)
    {
        return await ExecuteRequet(async () => await _walletService.GetAllWalletsOfAccountAsync(accountId));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        return await ExecuteRequet(async () => await _walletService.FindWalletAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateWalletRequest request)
    {
        return await ExecuteRequet(async () => await _walletService.AddWalletAsync(request));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateWalletRequest request)
    {
        return await ExecuteRequet(async () => await _walletService.UpdateWalletAsync(request));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return await ExecuteRequet(async () => await _walletService.DeleteWalletByIdAsync(id));
    }
}
