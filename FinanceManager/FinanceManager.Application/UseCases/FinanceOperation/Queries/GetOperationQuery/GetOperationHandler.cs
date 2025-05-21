using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperation.Queries.GetOperationQuery;

public class GetOperationHandler : BaseRequestHandler, IRequestHandler<GetOperationQuery, Result<FinanceOperationDTO>>
{
    private readonly IFinanceService _financeService;

    public GetOperationHandler(IFinanceService financeService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<Result<FinanceOperationDTO>> Handle(GetOperationQuery request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id);

        return await HandleAsync(async () =>
        {

            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await _financeService.IsCallerFinanceOperationOperationOwner(id));

            var data = _mapper.Map<FinanceOperationDTO>(
                await _financeService.GetFinanceOperation(id));

            return Result<FinanceOperationDTO>.Success(data, "Finance operation retrived successfully");
        });
    }
}
