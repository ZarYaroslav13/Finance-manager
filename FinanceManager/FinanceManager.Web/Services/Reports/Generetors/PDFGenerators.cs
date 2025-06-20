using FinanceManager.Application.Models;

namespace FinanceManager.Web.Services.Reports.Generetors;

public class PDFGenerators : IReportGeneretor
{
    public FileType GeneretorFileType => FileType.PDF;

    public string GeterateReport(FinanceReportDTO reportDTO)
    {
        throw new NotImplementedException();
    }
}
