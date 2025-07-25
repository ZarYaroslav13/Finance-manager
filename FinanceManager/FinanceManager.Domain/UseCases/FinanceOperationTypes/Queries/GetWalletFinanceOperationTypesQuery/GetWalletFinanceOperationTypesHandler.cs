using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;
using FinanceManager.Infrastructure.UnitOfWork;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.UseCases.FinanceOperationTypes.Queries.GetAllFinanceOperationTypesQuery;

public class GetWalletFinanceOperationTypesHandler : BaseRequestHandler, IRequestHandler<GetWalletFinanceOperationTypesQuery, Result<List<FinanceOperationTypeModel>>>
{
    private readonly IRepository<FinanceOperationType> _repository;
    public GetWalletFinanceOperationTypesHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperationType>();
    }

    public async Task<Result<List<FinanceOperationTypeModel>>> Handle(GetWalletFinanceOperationTypesQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request,
                () => request.IsCallerOwner);

            var data = (await _repository
                .GetAllAsync(includeProperties: nameof(FinanceOperationType.Wallet), filter: fot => fot.WalletId == request.WalletId))
                .Select(_mapper.Map<FinanceOperationTypeModel>)
                .ToList();

            return await Result<List<FinanceOperationTypeModel>>.SuccessAsync(data, "Finance operation types retrived successfully!");
        });
    }
}

