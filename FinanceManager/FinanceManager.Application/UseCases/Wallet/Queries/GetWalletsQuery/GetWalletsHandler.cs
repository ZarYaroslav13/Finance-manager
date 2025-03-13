using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Admins;
using FinanceManager.Domain.Services.Wallets;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        if (request.UserRole != AdminService.AdminRole && request.UserId != request.AccountId)
        {
            _logger.LogInformation("Access to get wallets information of account with {AccountId} is denied for  user with id: {UserId} and role: {UserRole}",
                request.AccountId, request.UserId, request.UserRole);
            throw new UnauthorizedAccessException("Access denied");
        }

        var response = new BaseResponse<List<WalletDTO>>();

        try
        {
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
