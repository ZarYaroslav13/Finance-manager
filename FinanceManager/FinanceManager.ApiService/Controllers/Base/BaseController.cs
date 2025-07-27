using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers.Base;

[Authorize]
[Route("finance-manager/[controller]s")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    protected async Task<IActionResult> ExecuteRequet(Func<Task<dynamic>> request)
    {
        var result = await request();

        return result.Succeeded ? Ok(result) : BadRequest(result);
    }
}
