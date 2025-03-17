using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Finances;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.FinanceOperation.Queries.GetAllOperationsOfTypeQuery;

internal class GetAllOperationsOfTypeHandler : BaseHandler, IRequestHandler<GetAllOperationsOfTypeQuery, BaseResponse<List<FinanceOperationDTO>>>
{
    private readonly IFinanceService _financeService;

    public GetAllOperationsOfTypeHandler(IFinanceService financeService, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<BaseResponse<List<FinanceOperationDTO>>> Handle(GetAllOperationsOfTypeQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<List<FinanceOperationDTO>>();

        try
        {
            await CheckIsUserResourceOwnerOrAdminAsync(request,
                addinionallyCondition:
                    async () =>
                        await _financeService.IsAccountOwnerOfFinanceOperationTypeAsync(request.UserId, request.TypeId));

            response.Data = (await _financeService
                .GetAllFinanceOperationOfTypeAsync(request.TypeId, request.Index, request.Count))
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
