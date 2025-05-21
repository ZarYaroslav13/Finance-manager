using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Wallets;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Wallets.Queries.GetWalletsQuery;

public class GetWalletsHandler : BaseRequestHandler, IRequestHandler<GetWalletsQuery, Result<List<WalletDTO>>>
{
    private readonly IWalletService _service;

    public GetWalletsHandler(IWalletService service,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<Result<List<WalletDTO>>> Handle(GetWalletsQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {

            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await Task.FromResult(_currentUserService.UserId == request.AccountId.ToString()));

            var data = (await _service.GetAllWalletsOfAccountAsync(request.AccountId))
                .Select(_mapper.Map<WalletDTO>)
                .ToList();

            return Result<List<WalletDTO>>.Success(data, "Wallets retrived successfully");
        });
    }
}
