using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperationType.Queries.GetAllFinanceOperationTypesQuery;

public class GetAllFinanceOperationTypesHandler : BaseRequestHandler, IRequestHandler<GetAllFinanceOperationTypesQuery, Result<List<FinanceOperationTypeDTO>>>
{
    private readonly IFinanceService _financeService;

    public GetAllFinanceOperationTypesHandler(IFinanceService financeService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<Result<List<FinanceOperationTypeDTO>>> Handle(GetAllFinanceOperationTypesQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await _financeService.IsCallerWallerOwner(request.WalletId));

            var data = (await _financeService.GetAllFinanceOperationTypesOfWalletAsync(request.WalletId))
                .Select(_mapper.Map<FinanceOperationTypeDTO>)
                .ToList();

            return await Result<List<FinanceOperationTypeDTO>>.SuccessAsync(data, "Finance operation created successfully!");
        });
    }
}

