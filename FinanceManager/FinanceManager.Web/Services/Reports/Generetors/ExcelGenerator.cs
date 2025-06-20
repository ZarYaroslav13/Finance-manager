using FinanceManager.Application.Models;

namespace FinanceManager.Web.Services.Reports.Generetors;

public class ExcelGenerator : IReportGeneretor
{
    public FileType GeneretorFileType => FileType.Excel;

    public string GeterateReport(FinanceReportDTO reportDTO)
    {
        throw new NotImplementedException();
    }
}
