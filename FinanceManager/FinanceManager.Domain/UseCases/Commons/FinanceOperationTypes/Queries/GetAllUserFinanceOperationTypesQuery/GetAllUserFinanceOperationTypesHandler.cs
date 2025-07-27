using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Commons.FinanceOperationTypes.Queries.GetAllUserFinanceOperationTypesQuery;

public class GetAllUserFinanceOperationTypesHandler : BaseRequestHandler, IRequestHandler<GetAllUserFinanceOperationTypesQuery, Result<List<FinanceOperationTypeModel>>>
{
    private readonly IRepository<FinanceOperationType> _repository;
    public GetAllUserFinanceOperationTypesHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperationType>();
    }

    public async Task<Result<List<FinanceOperationTypeModel>>> Handle(GetAllUserFinanceOperationTypesQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request, _currentUserService.UserId == request.UserId.ToString());

            var data = (await _repository
                .GetAllAsync(includeProperties: nameof(FinanceOperationType.Wallet), filter: fot => fot.Wallet.UserId == request.UserId))
                .Select(_mapper.Map<FinanceOperationTypeModel>)
                .ToList();

            return await Result<List<FinanceOperationTypeModel>>.SuccessAsync(data, "Finance operation types retrived successfully!");
        });
    }
}
