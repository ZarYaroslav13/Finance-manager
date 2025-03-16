using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.Accounts.Commands.DeleteAccountByIdCommand;
using FinanceManager.Application.UseCases.Accounts.Commands.UpdateCommand;
using FinanceManager.Application.UseCases.Accounts.Commands.UpdatePasswordAccountCommand;
using FinanceManager.Application.UseCases.Accounts.Queries.GetAllCustomersQuery;
using FinanceManager.Domain.Services.Admins;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class AccountController : BaseController
{
    public AccountController(IMediator mediator) : base(mediator)
    {
    }

    [Authorize(Policy = AdminService.AdminPolicy)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(int skip, int take)
    {
        var response = await _mediator.Send(new GetAllCustomersQuery()
        {
            UserRole = GetUserRole(),
            skip = skip,
            take = take
        });

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountCommand command)
    {
        command.UserId = GetUserId();
        command.UserRole = GetUserRole();

        var response = await _mediator.Send(command);

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }

    [HttpPatch]
    [Route("change-password")]
    public async Task<IActionResult> UpdatePasswordAsync([FromBody] UpdatePasswordAccountCommand command)
    {
        command.UserId = GetUserId();
        command.UserRole = GetUserRole();

        var response = await _mediator.Send(command);

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserById(int id)
    {
        var response = await _mediator.Send(new DeleteAccountByIdCommand()
        {
            UserId = GetUserId(),
            UserRole = GetUserRole(),
            Id = id
        });

        if (response.Success) return Ok(response);

        return BadRequest(response);
    }
}
