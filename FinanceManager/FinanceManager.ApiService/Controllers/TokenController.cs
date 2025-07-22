using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.Services.Token;
using FinanceManager.Domain.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Domain.UseCases.Tokens.Commands.RefreshTokenCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class TokenController : BaseController
{
    private readonly ITokenService _tokenService;

    public TokenController(ITokenService tokenService, IMediator mediator) : base(mediator)
    {
        _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromBody] GetTokenCommand command)
    {
        return await ExecuteRequet(async () => await _tokenService.LoginAsync(command));
    }

    /// <summary>
    /// Refresh Token
    /// </summary>
    /// <param name="model"></param>
    /// <returns>Status 200 OK</returns>
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenCommand command)
    {
        return await ExecuteRequet(async () => await _tokenService.GetRefreshTokenAsync(command));
    }
}
