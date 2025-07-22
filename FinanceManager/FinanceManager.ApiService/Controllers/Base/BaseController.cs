using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers.Base;

[Authorize]
[Route("finance-manager/[controller]s")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    protected async Task<IActionResult> SendRequestAsync<TCommand>(TCommand command)
    where TCommand : IBaseRequest
    {
        dynamic result = await _mediator.Send(command);

        return result.Succeeded ? Ok(result) : BadRequest(result);
    }

    protected async Task<IActionResult> ExecuteRequet(Func<Task<dynamic>> request)
    {
        var result = await request();

        return result.Succeeded ? Ok(result) : BadRequest(result);
    }
}
