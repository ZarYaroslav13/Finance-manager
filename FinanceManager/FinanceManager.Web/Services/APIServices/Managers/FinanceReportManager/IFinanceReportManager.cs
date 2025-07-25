using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIServices.Managers.FinanceReportManager
{
    public interface IFinanceReportManager : IManager
    {
        public Task<Result<FinanceReportDTO>> CreateDailyReportAsync(CreateDailyReportCommand command);

        public Task<Result<FinanceReportDTO>> CreatePeriodReportAsync(CreatePeriodReportCommand command);
    }
}
