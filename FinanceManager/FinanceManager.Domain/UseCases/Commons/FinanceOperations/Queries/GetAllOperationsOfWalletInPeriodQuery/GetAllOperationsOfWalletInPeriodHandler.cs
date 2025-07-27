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

namespace FinanceManager.Domain.UseCases.Commons.FinanceOperations.Queries.GetAllOperationsOfWalletInPeriodQuery;

public class GetAllOperationsOfWalletInPeriodHandler : BaseRequestHandler, IRequestHandler<GetAllOperationsOfWalletInPeriodQuery, Result<List<FinanceOperationModel>>>
{
    private readonly IRepository<FinanceOperation> _repository;

    public GetAllOperationsOfWalletInPeriodHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperation>();
    }

    public async Task<Result<List<FinanceOperationModel>>> Handle(GetAllOperationsOfWalletInPeriodQuery request, CancellationToken cancellationToken)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(request.StartDate, request.EndDate);

        CheckIsUserHaveAccesToResourse(request, request.IsCallerOwner);

        var dayAfterEndDate = request.EndDate.AddDays(1);
        var dayBeforeStartDate = request.StartDate.AddDays(-1);

        var data = (await _repository
                .GetAllAsync(
                includeProperties: nameof(FinanceOperation.Type),
                filter: fo =>
                       fo.Type.WalletId == request.WalletId
                    && fo.Date <= dayAfterEndDate
                    && fo.Date >= dayBeforeStartDate,
                orderBy: foO =>
                       foO.OrderBy(fo => fo.Date)))
                .Select(_mapper.Map<FinanceOperationModel>)
                .ToList();

        return Result<List<FinanceOperationModel>>.Success(data, "Finance operations retrived successfully");

    }
}
