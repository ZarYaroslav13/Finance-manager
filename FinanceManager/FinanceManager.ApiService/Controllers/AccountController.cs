using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.Services.Accounts;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class AccountController : BaseController
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService, IMediator mediator) : base(mediator)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountCommand command)
    {
        return await ExecuteRequet(async () => await _accountService.UpdateAccountAsync(command));
    }

    [HttpPatch("change-password")]
    public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangeUserPasswordCommand command)
    {
        return await ExecuteRequet(async () => await _accountService.ChangePasswordAsync(command));
    }
}
