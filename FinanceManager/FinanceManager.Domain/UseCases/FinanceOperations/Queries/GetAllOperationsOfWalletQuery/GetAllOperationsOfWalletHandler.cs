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

namespace FinanceManager.Domain.UseCases.FinanceOperations.Queries.GetAllOperationsOfWalletQuery;

internal class GetAllOperationsOfWalletHandler : BaseRequestHandler, IRequestHandler<GetAllOperationsOfWalletQuery, Result<List<FinanceOperationModel>>>
{
    private readonly IRepository<FinanceOperation> _repository;
    public GetAllOperationsOfWalletHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperation>();
    }

    public async Task<Result<List<FinanceOperationModel>>> Handle(GetAllOperationsOfWalletQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request, request.IsCallerOwner);

            var data = (await _repository
                .GetAllAsync(
                    includeProperties: nameof(FinanceOperation.Type),
                    filter: fo => fo.Type.WalletId == request.WalletId,
                    orderBy: iQ => iQ.OrderBy(fo => fo.Date),
                    skip: request.Index,
                    take: request.Count))
                .Select(_mapper.Map<FinanceOperationModel>)
                .ToList();

            return Result<List<FinanceOperationModel>>.Success(data, "Finance operations retrived successfully");
        });
    }
}
