using FinanceManager.ApiService.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class FinanceOperationTypeController : BaseController
{
    public FinanceOperationTypeController(IMediator mediator) : base(mediator)
    {
    }
    [HttpGet("users/{userId}")]
    public async Task<IActionResult> GetAllTypesOfUserAsync(Guid userId)
    {
        return await SendRequestAsync(new GetAllUserFinanceOperationTypesQuery() { userId = userId });
    }

    [HttpGet("wallet/{walletId}")]
    public async Task<IActionResult> GetAllAsync(Guid walletId)
    {
        return await SendRequestAsync(new GetAllFinanceOperationTypesQuery() { WalletId = walletId });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid Id)
    {
        return await SendRequestAsync(new GetFinanceOperationTypeQuery() { Id = Id });
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
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return await SendRequestAsync(new DeleteFinanceOperationTypeCommand() { Id = id });
    }
}
