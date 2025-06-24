using FinanceManager.Web.Services.Reports.Generetors;

namespace FinanceManager.Web.Services.Reports.Generators;

public class ReportGeneretorsLocator
{
    private Dictionary<FileType, IReportGeneretor> _generetors;

    public ReportGeneretorsLocator(CSVGenerator cSVGenerator, WordGenerator wordGenerator, PDFGenerator pDFGenerator)
    {
        _generetors = new()
        {
            { FileType.Excel, cSVGenerator ?? throw new ArgumentNullException(nameof(cSVGenerator))},
            { FileType.Word, wordGenerator ?? throw new ArgumentNullException(nameof(wordGenerator))},
            { FileType.PDF, pDFGenerator ?? throw new ArgumentNullException(nameof(pDFGenerator))},
        };
    }

    public IReportGeneretor GetGeneretor(FileType reportFileType) => _generetors[reportFileType];

}
