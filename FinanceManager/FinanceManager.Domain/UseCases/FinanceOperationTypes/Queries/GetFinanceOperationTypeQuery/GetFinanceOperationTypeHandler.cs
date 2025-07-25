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

namespace FinanceManager.Domain.UseCases.FinanceOperationTypes.Queries.GetFinanceOperationTypeQuery;

public class GetFinanceOperationTypeHandler : BaseRequestHandler, IRequestHandler<GetFinanceOperationTypeQuery, Result<FinanceOperationTypeModel>>
{
    public IRepository<FinanceOperationType> _repository;

    public GetFinanceOperationTypeHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperationType>();
    }

    public async Task<Result<FinanceOperationTypeModel>> Handle(GetFinanceOperationTypeQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request, request.IsCallerOwner);

            var data = _mapper.Map<FinanceOperationTypeModel>(
            await _repository.GetByIdAsync(request.Id));

            return await Result<FinanceOperationTypeModel>.SuccessAsync(data, "Finance operation type retrived successfully!");
        });
    }
}
