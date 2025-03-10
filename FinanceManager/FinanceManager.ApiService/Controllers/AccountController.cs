using FinanceManager.Application.UseCases.Accounts.Commands.DeleteAccountByIdCommand;
using FinanceManager.Application.UseCases.Accounts.Commands.UpdateCommand;
using FinanceManager.Application.UseCases.Accounts.Commands.UpdatePasswordAccountCommand;
using FinanceManager.Application.UseCases.Accounts.Queries.GetAllCustomersQuery;
using FinanceManager.Domain.Services.Admins;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanceManager.ApiService.Controllers;

[Authorize]
[Route("finance-manager/[controller]s")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [Authorize(Policy = AdminService.AdminPolicy)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(int skip, int take)
    {
        var response = await _mediator.Send(new GetAllCustomersQuery()
        {
            Identity = HttpContext.User.Identity as ClaimsIdentity,
            skip = skip,
            take = take
        });

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountCommand command)
    {
        command.Identity = HttpContext.User.Identity as ClaimsIdentity;

        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpPut]
    [Route("change-password")]
    public async Task<IActionResult> UpdatePasswordAsync([FromBody] UpdatePasswordAccountCommand command)
    {
        command.Identity = HttpContext.User.Identity as ClaimsIdentity;

        var response = await _mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserById(int id)
    {
        await _mediator.Send(new DeleteAccountByIdCommand()
        {
            Identity = HttpContext.User.Identity as ClaimsIdentity,
            Id = id
        });

        return Ok();
    }
}
