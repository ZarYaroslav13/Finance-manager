using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.FinanceOperation.Commands.AddFinanceOperationCommand;
using FinanceManager.Application.UseCases.FinanceOperation.Commands.DeleteFinanceOperationCommand;
using FinanceManager.Application.UseCases.FinanceOperation.Commands.UpdateFinanceOperationCommand;
using FinanceManager.Application.UseCases.FinanceOperation.Queries.GetAllOperationsOfTypeQuery;
using FinanceManager.Application.UseCases.FinanceOperation.Queries.GetAllOperationsOfWalletQuery;
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
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return await SendRequestAsync(new DeleteFinanceOperationCommand() { Id = id });
    }
}
