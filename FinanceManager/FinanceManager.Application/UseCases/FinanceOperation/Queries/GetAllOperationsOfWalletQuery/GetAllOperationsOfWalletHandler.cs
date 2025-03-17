using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Finances;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperation.Queries.GetAllOperationsOfWalletQuery;

public class GetAllOperationsOfWalletHandler : BaseRequestHandler, IRequestHandler<GetAllOperationsOfWalletQuery, BaseResponse<List<FinanceOperationDTO>>>
{
    private readonly IFinanceService _financeService;

    public GetAllOperationsOfWalletHandler(IFinanceService financeService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(mapper, logger)
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
