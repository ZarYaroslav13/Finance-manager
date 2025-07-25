using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;
using FinanceManager.Infrastructure.UnitOfWork;

namespace FinanceManager.Domain.UseCases.FinanceReports.Commands.CreatePeriodReportCommand;

public class CreatePeriodReportHandler : BaseRequestHandler, IRequestHandler<CreatePeriodReportCommand, Result<FinanceReportModel>>
{
    public CreatePeriodReportHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
    }

    public async Task<Result<FinanceReportModel>> Handle(CreatePeriodReportCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await _walletService.IsCallerWalletOwner(request.WalletId));

            DateTime startDate = request.StartDate ?? throw new ArgumentNullException(nameof(request.StartDate));
            DateTime endDate = request.EndDate ?? throw new ArgumentNullException(nameof(request.EndDate));

            var wallet = await _walletService.FindWalletAsync(request.WalletId);

            var data = _mapper.Map<FinanceReportDTO>(
                    await _creator.CreateFinanceReportAsync(wallet, startDate, endDate));

            data.Balance = wallet.Balance;

            return Result<FinanceReportDTO>.Success(data, "Report created successfully!");
        });
    }
}
