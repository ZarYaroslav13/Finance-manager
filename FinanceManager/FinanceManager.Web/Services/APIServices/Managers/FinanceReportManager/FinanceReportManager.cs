using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreateDailyReportCommand;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreatePeriodReportCommand;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.Managers.FinanceReportManager;

public class FinanceReportManager : BaseManager, IFinanceReportManager
{
    public FinanceReportManager(IFinanceManagerApiHttpClient httpClient) : base(httpClient)
    {
    }

    public Task<Result<FinanceReportDTO>> CreateDailyReportAsync(CreateDailyReportCommand command)
    {
        var result = _httpClient.CreateDailyReport(command);

        return result;
    }

    public Task<Result<FinanceReportDTO>> CreatePeriodReportAsync(CreatePeriodReportCommand command)
    {
        var result = _httpClient.CreatePeriodReport(command);

        return result;
    }
}
