using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.Roles.Commands.CreateRoleCommand;
using FinanceManager.Application.UseCases.Roles.Commands.DeleteRoleCommand;
using FinanceManager.Application.UseCases.Roles.Commands.UpdateRoleCommand;
using FinanceManager.Application.UseCases.Roles.Queries.GetAllRolesQuery;
using FinanceManager.Domain.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

[Authorize(Policy = PolicyManager.AdminPolicy)]
public class RoleController : BaseController
{
    public RoleController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Get All Roles (basic, admin etc.)
    /// </summary>
    /// <returns>Status 200 OK</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return await SendRequestAsync(new GetAllRolesQuery());
    }

    /// <summary>
    /// Add a Role
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Status 200 OK</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoleCommand command)
    {
        return await SendRequestAsync(command);
    }

    /// <summary>
    /// Add a Role
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Status 200 OK</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRoleCommand command)
    {
        return await SendRequestAsync(command);
    }

    /// <summary>
    /// Delete a Role
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Status 200 OK</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return await SendRequestAsync(new DeleteRoleCommand() { Id = id });
    }
}
