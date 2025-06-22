namespace FinanceManager.Web.Services.Reports.Generetors;

public class ReportGeneretorsLocator
{
    private Dictionary<FileType, IReportGeneretor> _generetors;

    public ReportGeneretorsLocator(CSVGenerator СSVGenerator)
    {
        _generetors = new()
        {
            { FileType.Excel, СSVGenerator ?? throw new ArgumentNullException(nameof(CSVGenerator))},
        };
    }

    public IReportGeneretor GetGeneretor(FileType reportFileType) => _generetors[reportFileType];

}
