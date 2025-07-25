using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceOperations.Queries;
using FinanceManager.Application.Models.Requests.FinanceReports.Commands;
using FinanceManager.Application.Services.Wallets;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.Services.Finances;

public class FinanceReportCreator : BaseService, IFinanceReportCreator
{
    private readonly IWalletService _walletService;
    protected readonly IFinanceService _financeService;

    public FinanceReportCreator(IWalletService walletService, IFinanceService financeService,
        IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
        _walletService = walletService ?? throw new ArgumentNullException(nameof(walletService));
        _financeService = financeService ?? throw new ArgumentNullException(nameof(financeService));
    }

    public async Task<Result<FinanceReportDTO>> CreateFinanceReportAsync(CreatePeriodReportRequest request)
    {
        var startDate = request.StartDate ?? DateTime.MaxValue;
        var endDate = request.EndDate ?? DateTime.MinValue;
        ArgumentOutOfRangeException.ThrowIfGreaterThan(startDate, endDate);

        Period period = new() { StartDate = startDate, EndDate = endDate };

        var wallet = await _walletService.FindWalletAsync(request.WalletId);

        if (wallet.Succeeded)
            return Result<FinanceReportDTO>.Fail(wallet.Messages);

        var report = new FinanceReportDTO(request.WalletId, wallet.Data.Name, period);
        var allOperations = await _financeService.GetAllFinanceOperationOfWalletAsync(_mapper.Map<GetAllOperationsOfWalletInPeriodRequest>(request));

        if (allOperations.Succeeded)
            return Result<FinanceReportDTO>.Fail(allOperations.Messages);

        report.Operations = allOperations.Data;

        return Result<FinanceReportDTO>.Success(report);
    }

    public async Task<Result<FinanceReportDTO>> CreateFinanceReportAsync(CreateDailyReportRequest request)
    {
        return await CreateFinanceReportAsync(_mapper.Map<CreatePeriodReportRequest>(request));
    }
}
