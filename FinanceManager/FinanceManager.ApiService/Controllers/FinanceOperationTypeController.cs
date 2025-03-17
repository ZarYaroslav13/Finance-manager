using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.FinanceOperationType.Commands.AddFinanceOperationTypeCommand;
using FinanceManager.Application.UseCases.FinanceOperationType.Commands.DeleteFinanceOperationTypeCommand;
using FinanceManager.Application.UseCases.FinanceOperationType.Commands.UpdateFinanceOperationTypeCommand;
using FinanceManager.Application.UseCases.FinanceOperationType.Queries.GetAllFinanceOperationTypesQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class FinanceOperationTypeController : BaseController
{
    public FinanceOperationTypeController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("wallet/{walletId}")]
    public async Task<IActionResult> GetAllAsync(int walletId)
    {
        return await SendRequestAsync(new GetAllFinanceOperationTypesQuery() { WalletId = walletId });
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddFinanceOperationTypeCommand command)
    {
        return await SendRequestAsync(command);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateFinanceOperationTypeCommand command)
    {
        return await SendRequestAsync(command);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return await SendRequestAsync(new DeleteFinanceOperationTypeCommand() { Id = id });
    }
}
