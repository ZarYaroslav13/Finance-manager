using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.FinanceReports.Commands;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIServices.Managers.FinanceReportManager
{
    public interface IFinanceReportManager : IManager
    {
        public Task<Result<FinanceReportDTO>> CreateDailyReportAsync(CreateDailyReportRequest request);

        public Task<Result<FinanceReportDTO>> CreatePeriodReportAsync(CreatePeriodReportRequest request);
    }
}
