using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperations.Queries.GetAllOperationsOfWalletQuery;

public class GetAllOperationsOfWalletHandler : BaseRequestHandler, IRequestHandler<GetAllOperationsOfWalletQuery, Result<List<FinanceOperationDTO>>>
{
    private readonly IFinanceService _financeService;

    public GetAllOperationsOfWalletHandler(IFinanceService financeService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<Result<List<FinanceOperationDTO>>> Handle(GetAllOperationsOfWalletQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await _financeService.IsCallerWallerOwner(request.WalletId));

            var data = (await _financeService
                .GetAllFinanceOperationOfWalletAsync(request.WalletId, request.Index, request.Count))
                .Select(_mapper.Map<FinanceOperationDTO>)
                .ToList() ?? new();

            return Result<List<FinanceOperationDTO>>.Success(data, "Finance operations retrived successfully");
        });
    }
}
