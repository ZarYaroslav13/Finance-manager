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

namespace FinanceManager.Domain.UseCases.Wallets.Queries.GetByIdWalletQuery;

public class GetByIdWalletHandler : BaseRequestHandler, IRequestHandler<GetByIdWalletQuery, Result<WalletModel>>
{
    private readonly IRepository<Wallet> _repository;
    public GetByIdWalletHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<Wallet>();
    }

    public async Task<Result<WalletModel>> Handle(GetByIdWalletQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            var data = _mapper.Map<WalletModel>(
                    await _repository.GetByIdAsync(request.WalletId));

            CheckIsUserHaveAccesToResourse(request,
                () => data.UserId.ToString() == _currentUserService.UserId);

            return Result<WalletModel>.Success(data, "Retrived wallet successfully!");
        });
    }
}
