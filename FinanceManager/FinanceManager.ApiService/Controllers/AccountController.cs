using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.Users.Commands.DeleteAccountByIdCommand;
using FinanceManager.Application.UseCases.Users.Commands.UpdateCommand;
using FinanceManager.Application.UseCases.Users.Commands.UpdatePasswordAccountCommand;
using FinanceManager.Application.UseCases.Users.Queries.GetAllCustomersQuery;
using FinanceManager.Application.UseCases.Users.Queries.GetCustomerQuery;
using FinanceManager.Domain.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class AccountController : BaseController
{
    public AccountController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize(Policy = PolicyManager.AdminPolicy)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(int skip, int take)
    {
        return await SendRequestAsync(new GetAllCustomersQuery()
        {
            skip = skip,
            take = take
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccount(int id)
    {
        return await SendRequestAsync(new GetCustomerQuery()
        {
            UserId = GetUserId(),
            UserRole = GetUserRole(),
            Id = id
        });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountCommand command)
    {
        return await SendRequestAsync(command);
    }

    [HttpPatch]
    [Route("change-password")]
    public async Task<IActionResult> UpdatePasswordAsync([FromBody] UpdatePasswordAccountCommand command)
    {
        return await SendRequestAsync(command);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserById(int id)
    {
        return await SendRequestAsync(new DeleteAccountByIdCommand()
        {
            UserId = GetUserId(),
            UserRole = GetUserRole(),
            Id = id
        });
    }
}
