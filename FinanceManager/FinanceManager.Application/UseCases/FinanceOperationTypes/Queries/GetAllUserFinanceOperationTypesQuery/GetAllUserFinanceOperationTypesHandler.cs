using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperationTypes.Queries.GetAllUserFinanceOperationTypesQuery;

public class GetAllUserFinanceOperationTypesHandler : BaseRequestHandler, IRequestHandler<GetAllUserFinanceOperationTypesQuery, Result<List<FinanceOperationTypeDTO>>>
{
    private readonly IFinanceService _financeService;

    public GetAllUserFinanceOperationTypesHandler(IFinanceService financeService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<Result<List<FinanceOperationTypeDTO>>> Handle(GetAllUserFinanceOperationTypesQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourse(request,
                () => request.userId == new Guid(_currentUserService.UserId));

            var data = (await _financeService.GetAllUserFinanceOperationTypesAsync(request.userId))
                .Select(_mapper.Map<FinanceOperationTypeDTO>)
                .ToList();

            return await Result<List<FinanceOperationTypeDTO>>.SuccessAsync(data, "Finance operation types retrived successfully!");
        });
    }
}
