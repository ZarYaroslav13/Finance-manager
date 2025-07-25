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

namespace FinanceManager.Domain.UseCases.FinanceOperations.Queries.GetOperationQuery;

public class GetOperationHandler : BaseRequestHandler, IRequestHandler<GetOperationQuery, Result<FinanceOperationModel>>
{
    private readonly IRepository<FinanceOperation> _repository;
    public GetOperationHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperation>();
    }

    public async Task<Result<FinanceOperationModel>> Handle(GetOperationQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request, request.IsCallerOwner);

            var data = _mapper.Map<FinanceOperationModel>(
            await _repository.GetByIdAsync(request.Id));

            return Result<FinanceOperationModel>.Success(data, "Finance operation retrived successfully");
        });
    }
}
