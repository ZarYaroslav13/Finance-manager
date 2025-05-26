using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.Users.Commands.DeleteAccountByIdCommand;
using FinanceManager.Application.UseCases.Users.Commands.ForgotPasswordCommand;
using FinanceManager.Application.UseCases.Users.Commands.RegisterCommand;
using FinanceManager.Application.UseCases.Users.Commands.ResetPasswordCommand;
using FinanceManager.Application.UseCases.Users.Queries.ConfirmEmailQuery;
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

    /// <summary>
    /// Register a User
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Status 200 OK</returns>
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand command)
    {
        return await SendRequestAsync(command);
    }

    /// <summary>
    /// Forgot Password
    /// </summary>
    /// <param name="email"></param>
    /// <returns>Status 200 OK</returns>
    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPasswordAsync(string email)
    {
        return await SendRequestAsync(new ForgotPasswordCommand()
        {
            Email = email,
            Origin = Request.Headers["origin"]
        });
    }

    /// <summary>
    /// Reset Password
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Status 200 OK</returns>
    [HttpPost("reset-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPasswordAsync(ResetPasswordCommand command)
    {
        return await SendRequestAsync(command);
    }

    /// <summary>
    /// Confirm Email
    /// </summary>
    /// <param name="query"></param>
    /// <returns>Status 200 OK</returns>
    [HttpGet("confirm-email")]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmEmailAsync([FromQuery] Guid userId, [FromQuery] string code)
    {
        return await SendRequestAsync(new ConfirmEmailQuery
        {
            UserId = userId,
            Code = code
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
