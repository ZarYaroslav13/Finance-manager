using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.Finances;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperation.Commands.UpdateFinanceOperationCommand;

public class UpdateFinanceOperationHandler : BaseRequestHandler, IRequestHandler<UpdateFinanceOperationCommand, BaseResponse<FinanceOperationDTO>>
{
    private readonly IFinanceService _financeService;

    public UpdateFinanceOperationHandler(IFinanceService financeService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<BaseResponse<FinanceOperationDTO>> Handle(UpdateFinanceOperationCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<FinanceOperationDTO>();

        try
        {
            await CheckIsUserResourceOwnerOrAdminAsync(request,
                addinionallyCondition:
                    async () =>
                        await _financeService.IsAccountOwnerOfFinanceOperationTypeAsync(request.UserId, request.TypeId));

            response.Data = _mapper.Map<FinanceOperationDTO>(
                    await _financeService.UpdateFinanceOperationAsync(
                            _mapper.Map<FinanceOperationModel>(request)));

            response.MakeAsSuccess("Finance operation updated successfully!");
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}
