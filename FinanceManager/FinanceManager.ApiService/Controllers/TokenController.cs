using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.Tokens.Commands.CreateRefreshTokenCommand;
using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class TokenController : BaseController
{
    public TokenController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Get([FromBody] GetTokenCommand command)
    {
        return await SendRequestAsync(command);
    }

    /// <summary>
    /// Refresh Token
    /// </summary>
    /// <param name="model"></param>
    /// <returns>Status 200 OK</returns>
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] CreateRefreshTokenCommand command)
    {
        var response = await _mediator.Send(command);
        return response.Succeeded ? Ok(response) : BadRequest(response);
    }
}
