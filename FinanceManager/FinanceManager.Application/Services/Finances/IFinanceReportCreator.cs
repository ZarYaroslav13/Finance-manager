using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceReports.Commands;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Application.Services.Finances;

public interface IFinanceReportCreator
{
    public Task<Result<FinanceReportDTO>> CreateFinanceReportAsync(CreatePeriodReportRequest request);

    public Task<Result<FinanceReportDTO>> CreateFinanceReportAsync(CreateDailyReportRequest request);
}
