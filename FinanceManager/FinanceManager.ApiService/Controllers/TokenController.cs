using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Application.UseCases.Tokens.Commands.RefreshTokenCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class TokenController : BaseController
{
    public TokenController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [AllowAnonymous]
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
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenCommand command)
    {
        return await SendRequestAsync(command);
    }
}
