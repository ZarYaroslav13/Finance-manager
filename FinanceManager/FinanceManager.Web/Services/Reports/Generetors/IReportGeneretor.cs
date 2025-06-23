using FinanceManager.Application.Models;

namespace FinanceManager.Web.Services.Reports.Generators;

public interface IReportGeneretor
{
    /// <summary>
    ///  Generate report and save in wwwroot
    /// </summary>
    /// <returns>report file path</returns>
    public Task<string> GenerateReport(FinanceReportDTO report);
}
