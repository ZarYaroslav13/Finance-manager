using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperation.Commands.AddFinanceOperationCommand;

public class AddFinanceOperationHandler : BaseRequestHandler, IRequestHandler<AddFinanceOperationCommand, Result<FinanceOperationDTO>>
{
    private readonly IFinanceService _financeService;

    public AddFinanceOperationHandler(IFinanceService financeService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<Result<FinanceOperationDTO>> Handle(AddFinanceOperationCommand request, CancellationToken cancellationToken)
    {
        var response = new Result<FinanceOperationDTO>();

        try
        {
            await CheckIsUserHaveAccesToResourseAsync(request, 
                request.TypeId,

                );

            await CheckIsUserResourceOwnerOrAdminAsync(request,
                addinionallyCondition:
                    async () =>
                        await _financeService.IsAccountOwnerOfFinanceOperationTypeAsync(request.UserId, request.TypeId));

            var data = _mapper.Map<FinanceOperationDTO>(
                    await _financeService.AddFinanceOperationAsync(
                            _mapper.Map<FinanceOperationModel>(request)));

            return await Result<FinanceOperationDTO>.SuccessAsync(data, "Finance operation created successfully!");
        }
        catch (Exception e)
        {
            return await Result<FinanceOperationDTO>.FailAsync(e.Message);
        }

        return response;
    }
}
