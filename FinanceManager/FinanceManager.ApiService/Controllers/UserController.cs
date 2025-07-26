using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.Models.Requests.Users.Commands;
using FinanceManager.Application.Services.Users;
using FinanceManager.Domain.Authorization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class UserController : BaseController
{
    private readonly IUserService _userService;
    public UserController(IUserService userService, IMediator mediator) : base(mediator)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    [Authorize(Policy = PolicyManager.AdminPolicy)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(int pageNumber, int pageSize)
    {
        return await ExecuteRequet(async () => await _userService.GetAllAsync(pageNumber, pageSize));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccount(Guid id)
    {
        return await ExecuteRequet(async () => await _userService.GetAsync(id));
    }

    [HttpGet("{id}/roles")]
    public async Task<IActionResult> GetUserRoles(Guid id)
    {
        return await ExecuteRequet(async () => await _userService.GetUserRolesAsync(id));
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
        return await ExecuteRequet(async () => await _userService.ConfirmEmailAsync(userId, code));
    }

    /// <summary>
    /// Register a User
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Status 200 OK</returns>
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
    {
        return await ExecuteRequet(async () => await _userService.RegisterAsync(request));
    }

    /// <summary>
    /// Forgot Password
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Status 200 OK</returns>
    [HttpPost("forgot-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordRequest request)
    {
        return await ExecuteRequet(async () => await _userService.ForgotPasswordAsync(request));
    }

    /// <summary>
    /// Reset Password
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Status 200 OK</returns>
    [HttpPost("reset-password")]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordRequest request)
    {
        return await ExecuteRequet(async () => await _userService.ResetPasswordAsync(request));
    }

    [Authorize(Policy = PolicyManager.AdminPolicy)]
    [HttpPatch]
    public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesRequest request)
    {
        return await ExecuteRequet(async () => await _userService.UpdateUserRolesAsync(request));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserById(Guid id)
    {
        return await ExecuteRequet(async () => await _userService.DeleteUserAsync(id));
    }
}
