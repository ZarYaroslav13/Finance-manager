using FinanceManager.Application.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using Microsoft.Extensions.Localization;

namespace FinanceManager.Web.Services.Reports.Generetors;

public abstract class ReportGeneretor : IReportGeneretor
{
    public abstract FileType GeneretorFileType { get; }

    protected readonly IStringLocalizer<ReportGeneretor> _localizer;

    private readonly IWebHostEnvironment _envirement;
    private readonly ICurrentUserService _currentUserService;

    public ReportGeneretor(IWebHostEnvironment hostEnvironment, ICurrentUserService currentUserService, IStringLocalizer<ReportGeneretor> localizer)
    {
        _envirement = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
        _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
    }

    public async Task<string> GenerateReport(FinanceReportDTO report)
    {
        string reportFileName = $"report-{_currentUserService.UserId}.{GeneretorFileType.ToFileTypeExtention()}";
        string reportDirectory = Path.Combine(_envirement.WebRootPath, "reports");
        string reportPath = Path.Combine(reportDirectory, reportFileName);
        Directory.CreateDirectory(reportDirectory);

        var result = await GenerateFileReport(report, reportPath);

        return reportFileName;
    }

    protected abstract Task<Domain.Wrapper.IResult> GenerateFileReport(FinanceReportDTO report, string reportPath);
}
