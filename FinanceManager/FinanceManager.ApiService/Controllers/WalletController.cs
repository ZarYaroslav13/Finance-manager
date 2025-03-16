using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.Wallet.Commands.CreateWalletCommand;
using FinanceManager.Application.UseCases.Wallet.Commands.DeleteWalletCommand;
using FinanceManager.Application.UseCases.Wallet.Commands.UpdateWalletCommand;
using FinanceManager.Application.UseCases.Wallet.Queries.GetByIdWalletQuery;
using FinanceManager.Application.UseCases.Wallet.Queries.GetWalletsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class WalletController : BaseController
{
    public WalletController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("~/finance-manager/accounts/{accountId:int}/wallets")]
    public async Task<IActionResult> GetWalletsAsync(int accountId)
    {
        return await SendRequestAsync(new GetWalletsQuery() { AccountId = accountId });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return await SendRequestAsync(new GetByIdWalletQuery() { WalletId = id });
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateWalletCommand command)
    {
        return await SendRequestAsync(command);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateWalletCommand command)
    {
        return await SendRequestAsync(command);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return await SendRequestAsync(new DeleteWalletCommand() { WalletId = id });
    }
}
