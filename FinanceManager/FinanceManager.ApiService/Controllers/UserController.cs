using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.Users.Commands.DeleteAccountByIdCommand;
using FinanceManager.Application.UseCases.Users.Queries.GetAllUsersQuery;
using FinanceManager.Application.UseCases.Users.Queries.GetUserQuery;
using FinanceManager.Domain.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class UserController : BaseController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize(Policy = PolicyManager.AdminPolicy)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromBody] GetAllUsersQuery query)
    {
        return await SendRequestAsync(query);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccount(Guid id)
    {
        return await SendRequestAsync(new GetUserQuery()
        {
            Id = id
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserById(Guid id)
    {
        return await SendRequestAsync(new DeleteUserCommand()
        {
            Id = id
        });
    }
}
