using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperationTypes.Queries.GetFinanceOperationTypeQuery;

public class GetFinanceOperationTypeHandler : BaseRequestHandler, IRequestHandler<GetFinanceOperationTypeQuery, Result<FinanceOperationTypeDTO>>
{
    private readonly IFinanceService _financeService;
    public GetFinanceOperationTypeHandler(IFinanceService financeService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<Result<FinanceOperationTypeDTO>> Handle(GetFinanceOperationTypeQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await _financeService.IsCallerFinanceOperationTypeOwner(request.Id));

            var data = _mapper.Map<FinanceOperationTypeDTO>(
                    await _financeService.GetFinanceOperationType(request.Id));

            return await Result<FinanceOperationTypeDTO>.SuccessAsync(data, "Finance operation type retrived successfully!");
        });
    }
}
