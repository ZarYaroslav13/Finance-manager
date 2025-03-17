using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Finances;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperationType.Commands.DeleteFinanceOperationTypeCommand;

public class DeleteFinanceOperationTypeHandler : BaseRequestHandler, IRequestHandler<DeleteFinanceOperationTypeCommand, BaseResponse<bool>>
{
    private readonly IFinanceService _financeService;

    public DeleteFinanceOperationTypeHandler(IFinanceService financeService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<BaseResponse<bool>> Handle(DeleteFinanceOperationTypeCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            await CheckIsUserResourceOwnerOrAdminAsync(request,
                addinionallyCondition:
                    async () =>
                        await _financeService.IsAccountOwnerOfFinanceOperationTypeAsync(request.UserId, request.Id));

            await _financeService.DeleteFinanceOperationTypeAsync(request.Id);

            response.Data = true;
            response.MakeAsSuccess("Types received successfully!");
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}
