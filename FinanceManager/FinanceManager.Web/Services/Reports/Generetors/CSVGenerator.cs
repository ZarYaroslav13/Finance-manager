using CsvHelper;
using CsvHelper.Configuration;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Wrapper;
using Microsoft.Extensions.Localization;
using System.Text;

namespace FinanceManager.Web.Services.Reports.Generetors;

public class CSVGenerator : ReportGeneretor
{
    public override FileType GeneretorFileType => FileType.Excel;

    private readonly CsvConfiguration _configuration;

    public CSVGenerator(CsvConfiguration configuration,
        IWebHostEnvironment hostEnvironment, ICurrentUserService currentUserService, IStringLocalizer<ReportGeneretor> localizer) : base(hostEnvironment, currentUserService, localizer)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    protected override async Task<Domain.Wrapper.IResult> GenerateFileReport(FinanceReportDTO report, string reportPath)
    {
        try
        {
            using (var writer = new StreamWriter(reportPath, false, new UTF8Encoding(true)))
            {
                using (var csv = new CsvWriter(writer, _configuration))
                {
                    WriteReportInfo(csv, report);

                    WriteReportOperations(csv, report);
                }
            }

            return await Result.SuccessAsync();
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }

    private void WriteReportInfo(CsvWriter csv, FinanceReportDTO report)
    {
        var reportInfoHeaders = new[]
        {
        _localizer[nameof(FinanceReportDTO.WalletId)],
        _localizer[nameof(FinanceReportDTO.WalletName)],
        _localizer[nameof(FinanceReportDTO.Balance)],
        _localizer[nameof(FinanceReportDTO.TotalIncome)],
        _localizer[nameof(FinanceReportDTO.TotalExpense)],
        _localizer[nameof(FinanceReportDTO.Period.StartDate)],
        _localizer[nameof(FinanceReportDTO.Period.EndDate)],
        };

        foreach (var header in reportInfoHeaders)
        {
            csv.WriteField(header);
        }

        csv.NextRecord();

        var reportInfo = new object[]
        {
        report.WalletId,
        report.WalletName,
        report.Balance,
        report.TotalIncome,
        report.TotalExpense,
        report.Period.StartDate,
        report.Period.EndDate,
        };

        foreach (var value in reportInfo)
        {
            csv.WriteField(value);
        }

        csv.NextRecord();
    }

    private void WriteReportOperations(CsvWriter csv, FinanceReportDTO report)
    {
        csv.WriteField(_localizer[nameof(FinanceOperationDTO.Id)]);
        csv.WriteField(_localizer[nameof(FinanceOperationDTO.Amount)]);
        csv.WriteField(_localizer[nameof(FinanceOperationDTO.Date)]);
        csv.WriteField(_localizer["Type id"]);
        csv.WriteField(_localizer[nameof(FinanceOperationDTO.Type.Name)]);
        csv.WriteField(_localizer[nameof(FinanceOperationDTO.Type.Description)]);
        csv.WriteField(_localizer[nameof(FinanceOperationDTO.Type.EntryType)]);

        csv.NextRecord();

        foreach (var item in report.Operations)
        {
            csv.WriteField(item.Id);
            csv.WriteField(item.Amount);
            csv.WriteField(item.Date);
            csv.WriteField(item.Type.Id);
            csv.WriteField(item.Type.Name);
            csv.WriteField(item.Type.Description);
            csv.WriteField(item.Type.EntryType.ToString());

            csv.NextRecord();
        }
    }
}
