using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.Models.Requests.Account.Commands;
using FinanceManager.Application.Services.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class AccountController : BaseController
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateAccountRequest request)
    {
        return await ExecuteRequet(async () => await _accountService.UpdateAccountAsync(request));
    }

    [HttpPatch("change-password")]
    public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangeUserPasswordRequest request)
    {
        return await ExecuteRequet(async () => await _accountService.ChangePasswordAsync(request));
    }
}
