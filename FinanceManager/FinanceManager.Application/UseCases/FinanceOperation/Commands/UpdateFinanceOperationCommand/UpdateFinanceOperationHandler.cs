using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperation.Commands.UpdateFinanceOperationCommand;

public class UpdateFinanceOperationHandler : BaseRequestHandler, IRequestHandler<UpdateFinanceOperationCommand, Result<FinanceOperationDTO>>
{
    private readonly IFinanceService _financeService;

    public UpdateFinanceOperationHandler(IFinanceService financeService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<Result<FinanceOperationDTO>> Handle(UpdateFinanceOperationCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await _financeService.IsCallerFinanceOperationOperationOwner(Guid.Parse(request.Id)));

            var data = _mapper.Map<FinanceOperationDTO>(
                    await _financeService.UpdateFinanceOperationAsync(
                            _mapper.Map<FinanceOperationModel>(request)));

            return Result<FinanceOperationDTO>.Success(data, "Finance operation updated successfully!");
        });
    }
}
