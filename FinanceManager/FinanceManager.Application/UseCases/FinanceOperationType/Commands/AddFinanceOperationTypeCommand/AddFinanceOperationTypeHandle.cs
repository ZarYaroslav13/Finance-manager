using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;

public class AddFinanceOperationTypeHandle : BaseRequestHandler, IRequestHandler<AddFinanceOperationTypeCommand, Result<FinanceOperationTypeDTO>>
{
    private readonly IFinanceService _financeService;

    public AddFinanceOperationTypeHandle(IFinanceService financeService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<Result<FinanceOperationTypeDTO>> Handle(AddFinanceOperationTypeCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await _financeService.IsCallerWallerOwner(request.WalletId));

            var data = _mapper.Map<FinanceOperationTypeDTO>(
                                await _financeService.AddFinanceOperationTypeAsync(
                                    _mapper.Map<FinanceOperationTypeModel>(request)));

            return await Result<FinanceOperationTypeDTO>.SuccessAsync(data, "Finance operation type created successfully!");
        });
    }
}
