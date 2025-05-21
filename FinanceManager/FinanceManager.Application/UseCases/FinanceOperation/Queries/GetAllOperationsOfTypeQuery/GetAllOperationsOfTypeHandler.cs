using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperation.Queries.GetAllOperationsOfTypeQuery;

internal class GetAllOperationsOfTypeHandler : BaseRequestHandler, IRequestHandler<GetAllOperationsOfTypeQuery, Result<List<FinanceOperationDTO>>>
{
    private readonly IFinanceService _financeService;

    public GetAllOperationsOfTypeHandler(IFinanceService financeService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<Result<List<FinanceOperationDTO>>> Handle(GetAllOperationsOfTypeQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await _financeService.IsCallerFinanceOperationTypeOwner(request.TypeId));

            var data = (await _financeService
                .GetAllFinanceOperationOfTypeAsync(request.TypeId, request.Index, request.Count))
                .Select(_mapper.Map<FinanceOperationDTO>)
                .ToList();

            return Result<List<FinanceOperationDTO>>.Success(data, "Operations received successfully");
        });
    }
}
