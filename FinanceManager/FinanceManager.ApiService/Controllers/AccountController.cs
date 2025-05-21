using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class AccountController : BaseController
{
    public AccountController(IMediator mediator) : base(mediator)
    {
    }



    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountCommand command)
    {
        return await SendRequestAsync(command);
    }

    [HttpPatch]
    [Route("change-password")]
    public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangeUserPasswordCommand command)
    {
        return await SendRequestAsync(command);
    }
}
