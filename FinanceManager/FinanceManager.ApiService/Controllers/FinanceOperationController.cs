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
    public async Task<IActionResult> GetAllOfWalletAsync(Guid walletId, [FromQuery] int index, [FromQuery] int count)
    {
        return await SendRequestAsync(new GetAllOperationsOfWalletQuery
        {
            WalletId = walletId,
            Index = index,
            Count = count
        });
    }

    [HttpGet("type/{query.TypeId}")]
    public async Task<IActionResult> GetAllOfTypeAsync(Guid typeId, [FromQuery] int index, [FromQuery] int count)
    {
        return await SendRequestAsync(new GetAllOperationsOfTypeQuery
        {
            TypeId = typeId,
            Index = index,
            Count = count
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOperationAsync(Guid id)
    {
        return await SendRequestAsync(new GetOperationQuery() { Id = id });
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
