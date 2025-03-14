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
        var response = await _mediator.Send(
            new GetWalletsQuery() { UserId = GetUserId(), UserRole = GetUserRole(), AccountId = accountId });

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var response = await _mediator.Send(
            new GetByIdWalletQuery() { UserId = GetUserId(), UserRole = GetUserRole(), WalletId = id });

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateWalletCommand command)
    {
        command.UserId = GetUserId();
        command.UserRole = GetUserRole();

        var response = await _mediator.Send(command);

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateWalletCommand command)
    {
        command.UserId = GetUserId();
        command.UserRole = GetUserRole();

        var response = await _mediator.Send(command);

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var command = new DeleteWalletCommand() { WalletId = id };
        command.UserId = GetUserId();
        command.UserRole = GetUserRole();

        var response = await _mediator.Send(command);

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }
}
