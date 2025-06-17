using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreateDailyReportCommand;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreatePeriodReportCommand;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.Managers.FinanceReportManager;

public class FinanceReportManager : BaseManager, IFinanceReportManager
{
    public FinanceReportManager(
        IFinanceManagerApiHttpClient httpClient, ILogger<FinanceReportManager> logger) : base(httpClient, logger)
    {
    }

    public async Task<Result<FinanceReportDTO>> CreateDailyReportAsync(CreateDailyReportCommand command)
    {
        return await SendRequest(async () => await _apiHttpClient.CreateDailyReport(command));
    }

    public async Task<Result<FinanceReportDTO>> CreatePeriodReportAsync(CreatePeriodReportCommand command)
    {
        return await SendRequest(async () => await _apiHttpClient.CreatePeriodReport(command));
    }
}
