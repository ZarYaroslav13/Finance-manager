using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.Login.Commands.CreateAccountCommand;
using FinanceManager.Application.UseCases.Login.Commands.SignInAdminCommand;
using FinanceManager.Application.UseCases.Login.Commands.SignInCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

[AllowAnonymous]
[Route("finance-manager/authorization")]
public class LoginController : BaseController
{
    public LoginController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("user/login")]
    public async Task<IActionResult> SignInAsync([FromBody] SignInCommand command)
    {
        var response = await _mediator.Send(command);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPost("admin/login")]
    public async Task<IActionResult> SignInAdminAsync([FromBody] SignInAdminCommand command)
    {
        var response = await _mediator.Send(command);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPost("user/sign-up")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAccountCommand command)
    {
        var response = await _mediator.Send(command);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}
