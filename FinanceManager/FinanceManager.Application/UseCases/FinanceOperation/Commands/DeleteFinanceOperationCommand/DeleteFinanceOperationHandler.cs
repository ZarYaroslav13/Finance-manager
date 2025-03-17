using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Finances;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperation.Commands.DeleteFinanceOperationCommand;

public class DeleteFinanceOperationHandler : BaseHandler, IRequestHandler<DeleteFinanceOperationCommand, BaseResponse<bool>>
{
    private readonly IFinanceService _financeService;

    public DeleteFinanceOperationHandler(IFinanceService financeService, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<BaseResponse<bool>> Handle(DeleteFinanceOperationCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            await CheckIsUserResourceOwnerOrAdminAsync(request,
                addinionallyCondition:
                    async () =>
                        await _financeService.IsAccountOwnerOfFinanceOperationAsync(request.UserId, request.Id));

            await _financeService.DeleteFinanceOperationAsync(request.Id);

            response.MakeAsSuccess("Finance operation deleted successfully!");

            response.Data = true;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}
