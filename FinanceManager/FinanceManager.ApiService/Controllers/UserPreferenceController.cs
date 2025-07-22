using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.Services.Preferences;
using FinanceManager.Domain.UseCases.Preferences.Command.UpdateUserPreferencesCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class UserPreferenceController : BaseController
{
    private readonly IPreferencesService _preferencesService;

    public UserPreferenceController(IPreferencesService preferencesService,
        IMediator mediator) : base(mediator)
    {
        _preferencesService = preferencesService ?? throw new ArgumentNullException(nameof(preferencesService));
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetUserPreferences(Guid userId)
    {
        return await ExecuteRequet(async () => await _preferencesService.GetPreferencesOfUserAsync(userId));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserPreferences([FromBody] UpdateUserPreferencesCommand command)
    {
        return await ExecuteRequet(async () => await _preferencesService.UpdatePreferncesAsync(command));
    }
}
