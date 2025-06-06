using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Preferences;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Preferences.Query.GetUserPreferencesQuery
{
    public class GetUserPreferencesHander : BaseRequestHandler, IRequestHandler<GetUserPreferencesQuery, Result<UserPreferencesDTO>>
    {
        private readonly IPreferencesService _preferenceService;

        public GetUserPreferencesHander(IPreferencesService preferenceService,
            ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
        {
            _preferenceService = preferenceService ?? throw new ArgumentNullException(nameof(preferenceService));
        }

        public async Task<Result<UserPreferencesDTO>> Handle(GetUserPreferencesQuery request, CancellationToken cancellationToken)
        {
            return await HandleAsync(async () =>
            {
                await CheckIsUserHaveAccesToResourse(request,
                    () => _currentUserService.UserId == request.UserId.ToString());

                var result = await _preferenceService.GetPreferencesOfUserAsync(request.UserId);

                return _mapper.Map<Result<UserPreferencesDTO>>(result);
            });
        }
    }
}
