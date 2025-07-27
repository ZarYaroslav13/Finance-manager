using AutoMapper;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Commons.Wallets.Queries.IsCallerWalletOwnerQuery;

public class IsCallerWalletOwnerHandler : BaseRequestHandler, IRequestHandler<IsCallerWalletOwnerQuery, IResult<bool>>
{
    private readonly IRepository<Wallet> _repository;

    public IsCallerWalletOwnerHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<Wallet>();
    }

    public async Task<IResult<bool>> Handle(IsCallerWalletOwnerQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            var wallet = await _repository.GetByIdAsync(request.WalletId);

            return Result<bool>.Success(wallet.UserId == request.WalletId);
        });
    }
}
