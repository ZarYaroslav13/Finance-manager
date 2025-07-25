using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.Models;
using FinanceManager.Application.Services.Wallets;
using FinanceManager.Domain.UseCases.Wallets.Commands.CreateWalletCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class WalletController : BaseController
{
    private readonly IWalletService _walletService;

    public WalletController(IWalletService walletService, IMediator mediator) : base(mediator)
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
    public async Task<IActionResult> CreateAsync([FromBody] CreateWalletCommand command)
    {
        return await ExecuteRequet(async () => await _walletService.AddWalletAsync(command));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] WalletDTO wallet)
    {
        return await ExecuteRequet(async () => await _walletService.UpdateWalletAsync(wallet));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return await ExecuteRequet(async () => await _walletService.DeleteWalletByIdAsync(id));
    }
}
