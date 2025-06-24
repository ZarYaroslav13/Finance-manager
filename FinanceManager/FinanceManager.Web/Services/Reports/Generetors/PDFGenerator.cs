using FinanceManager.Application.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.Reports.Generators;
using Microsoft.Extensions.Localization;
using Spire.Doc;

namespace FinanceManager.Web.Services.Reports.Generetors;

public class PDFGenerator : ReportGeneretor
{
    private readonly WordGenerator _generator;

    public PDFGenerator(WordGenerator generator,
        IWebHostEnvironment hostEnvironment, ICurrentUserService currentUserService, IStringLocalizer<PDFGenerator> localizer) : base(hostEnvironment, currentUserService, localizer)
    {
        _generator = generator ?? throw new ArgumentNullException(nameof(generator));
    }

    public override FileType GeneretorFileType => FileType.PDF;

    protected override async Task<Domain.Wrapper.IResult> GenerateFileReport(FinanceReportDTO report, string reportPath)
    {
        try
        {
            var name = await _generator.GenerateReport(report);

            string reportDirectory = Path.Combine(_envirement.WebRootPath, "reports");
            string wordPath = Path.Combine(reportDirectory, name);


            Document document = new();

            document.LoadFromFile(wordPath);

            document.SaveToFile(reportPath, FileFormat.PDF);

            return Result.Success();
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }
}
