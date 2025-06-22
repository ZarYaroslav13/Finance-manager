namespace FinanceManager.Web.Services.Reports.Generetors;

public class ReportGeneretorsLocator
{
    private Dictionary<FileType, IReportGeneretor> _generetors;

    public ReportGeneretorsLocator(CSVGenerator СSVGenerator, WordGenerator wordGenerator)
    {
        _generetors = new()
        {
            { FileType.Excel, СSVGenerator ?? throw new ArgumentNullException(nameof(CSVGenerator))},
            { FileType.Word, wordGenerator ?? throw new ArgumentNullException(nameof(CSVGenerator))},
        };
    }

    public IReportGeneretor GetGeneretor(FileType reportFileType) => _generetors[reportFileType];

}
