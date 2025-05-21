using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Wallets;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Wallets.Queries.GetByIdWalletQuery;

public class GetByIdWalletHandler : BaseRequestHandler, IRequestHandler<GetByIdWalletQuery, Result<WalletDTO>>
{
    private readonly IWalletService _service;

    public GetByIdWalletHandler(IWalletService service,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<Result<WalletDTO>> Handle(GetByIdWalletQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {

            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await _service.IsCallerWalletOwner(request.WalletId));

            var data = _mapper.Map<WalletDTO>(
                    await _service.FindWalletAsync(request.WalletId));

            return Result<WalletDTO>.Success(data, "Retrived wallet successfully!");
        });
    }
}
