using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperationType.Commands.AddFinanceOperationTypeCommand;

public class AddFinanceOperationTypeHandle : BaseRequestHandler, IRequestHandler<AddFinanceOperationTypeCommand, Result<FinanceOperationTypeDTO>>
{
    private readonly IFinanceService _financeService;

    public AddFinanceOperationTypeHandle(IFinanceService financeService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<Result<FinanceOperationTypeDTO>> Handle(AddFinanceOperationTypeCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<FinanceOperationTypeDTO>();
        try
        {
            await CheckIsUserResourceOwnerOrAdminAsync(request,
                addinionallyCondition:
                    async () =>
                        await _financeService.IsAccountOwnerOfWalletAsync(request.UserId, request.WalletId));

            response.Data = _mapper.Map<FinanceOperationTypeDTO>(
                                await _financeService.AddFinanceOperationTypeAsync(
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
