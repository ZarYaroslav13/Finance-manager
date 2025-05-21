using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperation.Commands.DeleteFinanceOperationCommand;

public class DeleteFinanceOperationHandler : BaseRequestHandler, IRequestHandler<DeleteFinanceOperationCommand, IResult>
{
    private readonly IFinanceService _financeService;

    public DeleteFinanceOperationHandler(IFinanceService financeService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<IResult> Handle(DeleteFinanceOperationCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () =>
                    await _financeService.IsCallerFinanceOperationOperationOwner(Guid.Parse(request.Id)));

            await _financeService.DeleteFinanceOperationAsync(Guid.Parse(request.Id));

            return Result.Success("Finance operation deleted successfully!");
        });
    }
}
