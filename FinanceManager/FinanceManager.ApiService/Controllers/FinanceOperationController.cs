using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.Models.Requests.FinanceOperations.Commands;
using FinanceManager.Application.Models.Requests.FinanceOperations.Queries;
using FinanceManager.Application.Services.Finances;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class FinanceOperationController : BaseController
{
    private readonly IFinanceService _financeService;

    public FinanceOperationController(IFinanceService financeService)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    [HttpGet("wallets/{request.WalletId}")]
    public async Task<IActionResult> GetAllOfWalletAsync(GetAllOperationsOfWalletRequest request)
    {
        return await ExecuteRequet(async () => await _financeService.GetAllFinanceOperationOfWalletAsync(request));
    }

    [HttpGet("types/{TypeId}")]
    public async Task<IActionResult> GetAllOfTypeAsync(GetAllOperationsOfTypeRequest request)
    {
        return await ExecuteRequet(async () => await _financeService.GetAllFinanceOperationOfTypeAsync(request));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOperationAsync(Guid id)
    {
        return await ExecuteRequet(async () => await _financeService.GetFinanceOperation(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddFinanceOperationRequest request)
    {
        return await ExecuteRequet(async () => await _financeService.AddFinanceOperationAsync(request));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateFinanceOperationRequest request)
    {
        return await ExecuteRequet(async () => await _financeService.UpdateFinanceOperationAsync(request));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return await ExecuteRequet(async () => await _financeService.DeleteFinanceOperationAsync(id));
    }
}
