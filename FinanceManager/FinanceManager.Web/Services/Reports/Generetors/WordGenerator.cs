using FinanceManager.Application.Models;

namespace FinanceManager.Web.Services.Reports.Generetors;

public class WordGenerator : IReportGeneretor
{
    public FileType GeneretorFileType => FileType.Word;

    public string GeterateReport(FinanceReportDTO reportDTO)
    {
        throw new NotImplementedException();
    }
}
