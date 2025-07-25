using AutoMapper;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.FinanceOperations.Queries.IsCallerOperationOwnerQuery;

internal class IsCallerOperationOwnerHandler : BaseRequestHandler, IRequestHandler<IsCallerOperationOwnerQuery, IResult<bool>>
{
    private readonly IRepository<FinanceOperation> _repository;
    public IsCallerOperationOwnerHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperation>();
    }

    public async Task<IResult<bool>> Handle(IsCallerOperationOwnerQuery request, CancellationToken cancellationToken)
    {
        var operation = await _repository.FindBy((o) => o.Id == request.Id, new[] { nameof(FinanceOperation.Type), nameof(FinanceOperation.Type.Wallet) });

        return Result<bool>.Success(operation.Type.Wallet.UserId.ToString() == _currentUserService.UserId);
    }
}
