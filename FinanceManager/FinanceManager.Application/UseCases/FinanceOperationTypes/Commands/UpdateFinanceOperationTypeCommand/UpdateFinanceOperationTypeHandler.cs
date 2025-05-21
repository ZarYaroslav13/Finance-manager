using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;

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
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await _financeService.IsCallerFinanceOperationTypeOwner(request.Id));

            var data = _mapper.Map<FinanceOperationTypeDTO>(
                                await _financeService.UpdateFinanceOperationTypeAsync(
                                    _mapper.Map<FinanceOperationTypeModel>(request)));

            return Result<FinanceOperationTypeDTO>.Success(data, "Finance operation type updated successfully!");
        });
    }
}
