using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperationType.Commands.UpdateFinanceOperationTypeCommand;

public class UpdateFinanceOperationTypeHandler : BaseRequestHandler, IRequestHandler<UpdateFinanceOperationTypeCommand, Result<FinanceOperationTypeDTO>>
{
    private readonly IFinanceService _financeService;

    public UpdateFinanceOperationTypeHandler(IFinanceService financeService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<Result<FinanceOperationTypeDTO>> Handle(UpdateFinanceOperationTypeCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<FinanceOperationTypeDTO>();
        try
        {
            await CheckIsUserResourceOwnerOrAdminAsync(request,
                addinionallyCondition:
                    async () =>
                        await _financeService.IsAccountOwnerOfFinanceOperationTypeAsync(request.UserId, request.Id));

            response.Data = _mapper.Map<FinanceOperationTypeDTO>(
                                await _financeService.UpdateFinanceOperationTypeAsync(
                                    _mapper.Map<FinanceOperationTypeModel>(request)));

            response.MakeAsSuccess("Types received successfully!");
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}
