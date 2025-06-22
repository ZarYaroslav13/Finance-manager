namespace FinanceManager.Web.Services.Reports;

public enum FileType
{
    Excel,
    Word,
    PDF
}

public static class FileTypeExtention
{
    public static string ToFileTypeExtention(this FileType fileType)
    {
        switch (fileType)
        {
            case FileType.Excel: return "csv";
            case FileType.Word: return "docx";
            case FileType.PDF: return "pdf";
            default: return "txt";
        }
    }
}