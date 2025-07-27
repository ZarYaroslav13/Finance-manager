using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.UserPreferences.Commands;
using FinanceManager.Domain.UseCases.Preferences.Command.UpdateUserPreferencesCommand;
using FinanceManager.Domain.UseCases.Preferences.Query.GetUserPreferencesQuery;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.Services.Preferences;

public class PreferencesService : BaseService, IPreferencesService
{
    public PreferencesService(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task<Result<UserPreferencesDTO>> GetPreferencesOfUserAsync(Guid userId)
    {
        var result = await _mediator.Send(new GetUserPreferencesQuery() { UserId = userId });

        return _mapper.Map<Result<UserPreferencesDTO>>(result);
    }

    public async Task<IResult> UpdatePreferncesAsync(UpdateUserPreferencesRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<UpdateUserPreferencesCommand>(request));

        return result;
    }
}
