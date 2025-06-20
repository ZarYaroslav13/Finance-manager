using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Web.Services.Reports.Generetors;

public static class ReportGeneretorLocator
{
    private static Dictionary<FileType, IReportGeneretor> Generetors { get; } = new()
    {
        { FileType.Excel,  new ExcelGenerator()},
        { FileType.Word,  new WordGenerator()},
        { FileType.PDF,  new PDFGenerators()},
    };

    public static IReportGeneretor GetGeneretor(FileType reportFileType) => Generetors[reportFileType];

}
