using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Admins;
using FinanceManager.Domain.Services.Wallets;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.Wallet.Queries.GetByIdWalletQuery;

public class GetByIdWalletHandler : BaseHandler, IRequestHandler<GetByIdWalletQuery, BaseResponse<WalletDTO>>
{
    private readonly IWalletService _service;

    public GetByIdWalletHandler(IWalletService service, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _service = service ?? throw new ArgumentNullException(nameof(service));
    }

    public async Task<BaseResponse<WalletDTO>> Handle(GetByIdWalletQuery request, CancellationToken cancellationToken)
    {
        if (!(await _service.IsAccountOwnerWalletAsync(request.UserId, request.WalletId)) && request.UserRole != AdminService.AdminRole)
        {
            _logger.LogWarning($"Unauthorized access attempt to get wallet with Id: {request.WalletId} by user Id: {request.UserId}");
            throw new UnauthorizedAccessException($"Access to this wallet is denied");
        }

        var response = new BaseResponse<WalletDTO>();

        try
        {
            response.Data = _mapper.Map<WalletDTO>(
                    await _service.FindWalletAsync(request.WalletId));
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}
