using FinanceManager.Application.Models;

namespace FinanceManager.Web.Services.Reports.Generetors;

public interface IReportGeneretor
{
    public FileType GeneretorFileType { get; }

    /// <summary>
    ///  Generate report and save in wwwroot
    /// </summary>
    /// <returns>report file path</returns>
    public string GeterateReport(FinanceReportDTO reportDTO);
}
