using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Wallets;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Wallet.Queries.GetWalletsQuery;

public class GetWalletsHandler : BaseHandler, IRequestHandler<GetWalletsQuery, BaseResponse<List<WalletDTO>>>
{
    private readonly IWalletService _service;

    public GetWalletsHandler(IWalletService service, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<BaseResponse<List<WalletDTO>>> Handle(GetWalletsQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<List<WalletDTO>>();

        try
        {
            CheckIsUserResourceOwnerOrAdmin(request, idSelector: r => r.AccountId);

            response.Data = (await _service.GetAllWalletsOfAccountAsync(request.AccountId))
                .Select(_mapper.Map<WalletDTO>)
                .ToList();

            response.MakeAsSuccess("Wallets are received successfully");
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}
