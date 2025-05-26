using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.FinanceOperations.Commands.AddFinanceOperationCommand;
using FinanceManager.Application.UseCases.FinanceOperations.Commands.DeleteFinanceOperationCommand;
using FinanceManager.Application.UseCases.FinanceOperations.Commands.UpdateFinanceOperationCommand;
using FinanceManager.Application.UseCases.FinanceOperations.Queries.GetAllOperationsOfTypeQuery;
using FinanceManager.Application.UseCases.FinanceOperations.Queries.GetAllOperationsOfWalletQuery;
using FinanceManager.Application.UseCases.FinanceOperations.Queries.GetOperationQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class FinanceOperationController : BaseController
{
    public FinanceOperationController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("wallet/{walletId}")]
    public async Task<IActionResult> GetAllOfWalletAsync([FromBody] GetAllOperationsOfWalletQuery query)
    {
        return await SendRequestAsync(query);
    }

    [HttpGet("type/{typeId}")]
    public async Task<IActionResult> GetAllOfTypeAsync([FromBody] GetAllOperationsOfTypeQuery query)
    {
        return await SendRequestAsync(query);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllOfTypeAsync(Guid id)
    {
        return await SendRequestAsync(new GetOperationQuery() { Id = id});
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddFinanceOperationCommand command)
    {
        return await SendRequestAsync(command);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateFinanceOperationCommand command)
    {
        return await SendRequestAsync(command);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return await SendRequestAsync(new DeleteFinanceOperationCommand() { Id = id });
    }
}
