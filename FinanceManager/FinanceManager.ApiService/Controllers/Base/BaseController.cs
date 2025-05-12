using System.Security.Claims;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
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
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
    }

    protected async Task<IActionResult> SendRequestAsync<TCommand>(TCommand command)
    where TCommand : BaseRequest
    {
        command.UserId = GetUserId();
        command.UserRole = GetUserRole();

        var responseType = typeof(TCommand)
            .GetInterfaces()
            .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequest<>))
            ?.GetGenericArguments()
            .FirstOrDefault();

        if (responseType == null || !typeof(BaseResponse<>).IsAssignableFrom(responseType.GetGenericTypeDefinition()))
        {
            return BadRequest("Invalid command response type.");
        }

        dynamic baseResponse = await _mediator.Send(command);

        return baseResponse.Success ? Ok(baseResponse) : BadRequest(baseResponse);
    }

    protected string GetUserRole()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        if (identity == null)
            throw new InvalidOperationException(nameof(identity));

        return identity.FindFirst(identity.RoleClaimType).Value;
    }

    protected int GetUserId()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        if (identity == null)
            throw new InvalidOperationException(nameof(identity));

        string stringId = identity.FindFirst(nameof(AccountDTO.Id)).Value;

        int id = 0;

        if (!int.TryParse(stringId, out id))
            throw new InvalidOperationException(nameof(stringId));

        return id;
    }

    protected string GetUserEmail()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        if (identity == null)
            throw new InvalidOperationException(nameof(identity));

        return identity.Name;
    }
}
