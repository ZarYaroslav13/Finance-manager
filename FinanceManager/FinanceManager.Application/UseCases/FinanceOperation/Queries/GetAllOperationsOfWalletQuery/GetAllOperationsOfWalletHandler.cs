using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Finances;
using Infrastructure.Models;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.FinanceOperation.Queries.GetAllOperationsOfWalletQuery;

public class GetAllOperationsOfWalletHandler : BaseHandler, IRequestHandler<GetAllOperationsOfWalletQuery, BaseResponse<List<FinanceOperationDTO>>>
{
    private readonly IFinanceService _financeService;

    public GetAllOperationsOfWalletHandler(IFinanceService financeService, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<BaseResponse<List<FinanceOperationDTO>>> Handle(GetAllOperationsOfWalletQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<List<FinanceOperationDTO>>();

        try
        {
            await CheckIsUserResourceOwnerOrAdminAsync(request, 
                addinionallyCondition: 
                    async () => 
                        await _financeService.IsAccountOwnerOfWalletAsync(request.UserId, request.WalletId));
            
            response.Data = (await _financeService
                .GetAllFinanceOperationOfWalletAsync(request.WalletId, request.Index, request.Count))
                .Select(_mapper.Map<FinanceOperationDTO>)
                .ToList();

            response.MakeAsSuccess("Operations received successfully");
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}
