using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Preferences.Query.GetUserPreferencesQuery
{
    public class GetUserPreferencesHander : BaseRequestHandler, IRequestHandler<GetUserPreferencesQuery, Result<UserPreferencesModel>>
    {
        private readonly IRepository<UserPreference> _repository;

        public GetUserPreferencesHander
            (IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger)
            : base(unitOfWork, currentUserService, mapper, logger)
        {
            _repository = _unitOfWork.GetRepository<UserPreference>();
        }

        public async Task<Result<UserPreferencesModel>> Handle(GetUserPreferencesQuery request, CancellationToken cancellationToken)
        {
            return await HandleAsync(async () =>
            {
                CheckIsUserHaveAccesToResourse(request,
                    () => _currentUserService.UserId == request.UserId.ToString());

                var data = await _repository.FindBy(u => u.UserId == request.UserId);

                return Result<UserPreferencesModel>.Success(
                        _mapper.Map<UserPreferencesModel>(data));
            });
        }
    }
}
