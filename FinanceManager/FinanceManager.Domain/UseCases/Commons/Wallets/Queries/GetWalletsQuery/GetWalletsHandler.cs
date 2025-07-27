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

namespace FinanceManager.Domain.UseCases.Commons.Wallets.Queries.GetWalletsQuery;

public class GetWalletsHandler : BaseRequestHandler, IRequestHandler<GetWalletsQuery, Result<List<WalletModel>>>
{
    private readonly IRepository<Wallet> _repository;

    public GetWalletsHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _repository = _unitOfWork.GetRepository<Wallet>();
    }

    public async Task<Result<List<WalletModel>>> Handle(GetWalletsQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {

            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await Task.FromResult(_currentUserService.UserId == request.AccountId.ToString()));

            var data = (await _repository
            .GetAllAsync(filter: w => w.UserId == request.AccountId))
            .Select(_mapper.Map<WalletModel>)
            .ToList();

            return Result<List<WalletModel>>.Success(data, "Wallets retrived successfully");
        });
    }
}
