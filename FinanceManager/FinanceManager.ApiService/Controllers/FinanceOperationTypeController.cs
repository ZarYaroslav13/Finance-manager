using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.Models.Requests.FinanceOperationTypes.Commands;
using FinanceManager.Application.Services.Finances;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class FinanceOperationTypeController : BaseController
{
    private readonly IFinanceService _financeService;

    public FinanceOperationTypeController(IFinanceService financeService, IMediator mediator) : base(mediator)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }
    [HttpGet("users/{userId}")]
    public async Task<IActionResult> GetAllTypesOfUserAsync(Guid userId)
    {
        return await ExecuteRequet(async () => await _financeService.GetAllUserFinanceOperationTypesAsync(userId));
    }

    [HttpGet("wallet/{walletId}")]
    public async Task<IActionResult> GetAllAsync(Guid walletId)
    {
        return await ExecuteRequet(async () => await _financeService.GetAllFinanceOperationTypesOfWalletAsync(walletId));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        return await ExecuteRequet(async () => await _financeService.GetFinanceOperationType(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddFinanceOperationTypeRequest request)
    {
        return await ExecuteRequet(async () => await _financeService.AddFinanceOperationTypeAsync(request));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateFinanceOperationTypeRequest request)
    {
        return await ExecuteRequet(async () => await _financeService.UpdateFinanceOperationTypeAsync(request));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return await ExecuteRequet(async () => await _financeService.DeleteFinanceOperationTypeAsync(id));
    }
}
