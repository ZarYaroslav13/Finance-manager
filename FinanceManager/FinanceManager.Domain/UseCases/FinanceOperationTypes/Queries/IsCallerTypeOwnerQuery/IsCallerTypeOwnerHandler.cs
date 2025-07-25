using AutoMapper;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.FinanceOperationTypes.Queries.IsCallerTypeOwnerQuery;

internal class IsCallerTypeOwnerHandler : BaseRequestHandler, IRequestHandler<IsCallerTypeOwnerQuery, IResult<bool>>
{
    private readonly IRepository<FinanceOperationType> _repository;

    public IsCallerTypeOwnerHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<FinanceOperationType>();
    }

    public async Task<IResult<bool>> Handle(IsCallerTypeOwnerQuery request, CancellationToken cancellationToken)
    {
        var type = await _repository.FindBy((t) => t.Id == request.Id, nameof(FinanceOperationType.Wallet));

        return Result<bool>.Success(type.Wallet.UserId.ToString() == _currentUserService.UserId);
    }
}
