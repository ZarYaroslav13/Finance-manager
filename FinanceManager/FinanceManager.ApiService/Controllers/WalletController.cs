using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Application.UseCases.Wallets.Commands.DeleteWalletCommand;
using FinanceManager.Application.UseCases.Wallets.Commands.UpdateWalletCommand;
using FinanceManager.Application.UseCases.Wallets.Queries.GetByIdWalletQuery;
using FinanceManager.Application.UseCases.Wallets.Queries.GetWalletsQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class WalletController : BaseController
{
    public WalletController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("~/finance-manager/accounts/{accountId:guid}/wallets")]
    public async Task<IActionResult> GetWalletsAsync(Guid accountId)
    {
        return await SendRequestAsync(new GetWalletsQuery() { AccountId = accountId });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
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
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return await SendRequestAsync(new DeleteWalletCommand() { WalletId = id });
    }
}
