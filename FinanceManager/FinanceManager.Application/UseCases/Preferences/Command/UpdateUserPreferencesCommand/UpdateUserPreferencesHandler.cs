using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Preferences;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Preferences.Command.UpdateUserPreferencesCommand;

public class UpdateUserPreferencesHandler : BaseRequestHandler, IRequestHandler<UpdateUserPreferencesCommand, IResult>
{
    private readonly IPreferencesService _preferenceService;

    public UpdateUserPreferencesHandler(IPreferencesService preferenceService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _preferenceService = preferenceService ?? throw new ArgumentNullException(nameof(preferenceService));
    }

    public async Task<IResult> Handle(UpdateUserPreferencesCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourse(request,
                () => _currentUserService.UserId == request.UserId.ToString());

            var result = await _preferenceService.UpdatePreferncesAsync(
                    _mapper.Map<UserPreferencesModel>(request));

            return result;
        });
    }
}
