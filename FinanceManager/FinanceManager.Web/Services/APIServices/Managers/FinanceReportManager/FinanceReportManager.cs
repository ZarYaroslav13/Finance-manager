using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceReports.Commands;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.Managers.FinanceReportManager;

public class FinanceReportManager : BaseManager, IFinanceReportManager
{
    public FinanceReportManager(
        IFinanceManagerApiHttpClient httpClient, ILogger<FinanceReportManager> logger) : base(httpClient, logger)
    {
    }

    public async Task<Result<FinanceReportDTO>> CreateDailyReportAsync(CreateDailyReportRequest request)
    {
        return await SendRequest(async () => await _apiHttpClient.CreateDailyReport(request));
    }

    public async Task<Result<FinanceReportDTO>> CreatePeriodReportAsync(CreatePeriodReportRequest request)
    {
        return await SendRequest(async () => await _apiHttpClient.CreatePeriodReport(request));
    }
}
