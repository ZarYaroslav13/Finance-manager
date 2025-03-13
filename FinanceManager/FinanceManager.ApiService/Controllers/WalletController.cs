using AutoMapper;
using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.Wallet.Commands.CreateWalletCommand;
using FinanceManager.Application.UseCases.Wallet.Commands.UpdateWalletCommand;
using FinanceManager.Application.UseCases.Wallet.Queries.GetByIdWalletQuery;
using FinanceManager.Application.UseCases.Wallet.Queries.GetWalletsQuery;
using FinanceManager.Domain.Services.Admins;
using FinanceManager.Domain.Services.Wallets;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class WalletController : BaseController
{
    private readonly IWalletService _service;

    public WalletController(IWalletService service, IMapper mapper, ILogger<WalletController> logger) : base(mapper, logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
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
        int userId = GetUserId();
        string userRole = GetUserRole();

        _logger.LogInformation("DeleteAsync called to remove wallet Id: {WalletId} for user Id: {UserId} and role: {UserRole}", id, userId, userRole);

        if (userRole != AdminService.AdminRole && !await _service.IsAccountOwnerWalletAsync(userId, id))
        {
            _logger.LogWarning($"Unauthorized access attempt to delete wallet Id: {id} by user Id: {userId} and role: {userRole}");
            throw new UnauthorizedAccessException($"Access to this wallet is denied");
        }

        await _service.DeleteWalletByIdAsync(id);

        _logger.LogInformation("Wallet Id: {WalletId} deleted successfully for user Id: {UserId} and role: {UserRole}", id, userId, userRole);

        return Ok();
    }
}
