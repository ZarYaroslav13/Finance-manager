using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.Preferences.Command.UpdateUserPreferencesCommand;
using FinanceManager.Application.UseCases.Preferences.Query.GetUserPreferencesQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class UserPreferenceController : BaseController
{
    public UserPreferenceController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUserPreferences(Guid userId)
    {
        return await SendRequestAsync(new GetUserPreferencesQuery()
        {
            UserId = userId
        });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserPreferences(UpdateUserPreferencesCommand command)
    {
        return await SendRequestAsync(command);
    }
}
