using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Finances;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperationType.Queries.GetAllFinanceOperationTypesQuery;

public class GetAllFinanceOperationTypesHandler : BaseHandler, IRequestHandler<GetAllFinanceOperationTypesQuery, BaseResponse<List<FinanceOperationTypeDTO>>>
{
    private readonly IFinanceService _financeService;

    public GetAllFinanceOperationTypesHandler(IFinanceService financeService, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<BaseResponse<List<FinanceOperationTypeDTO>>> Handle(GetAllFinanceOperationTypesQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<List<FinanceOperationTypeDTO>>();
        try
        {
            await CheckIsUserResourceOwnerOrAdminAsync(request,
                addinionallyCondition:
                    async () =>
                        await _financeService.IsAccountOwnerOfWalletAsync(request.UserId, request.WalletId));

            response.Data = (await _financeService.GetAllFinanceOperationTypesOfWalletAsync(request.WalletId))
                .Select(_mapper.Map<FinanceOperationTypeDTO>)
                .ToList();

            response.MakeAsSuccess("Types received successfully!");
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}

