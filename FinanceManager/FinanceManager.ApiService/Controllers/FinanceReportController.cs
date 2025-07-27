using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.Models.Requests.FinanceReports.Commands;
using FinanceManager.Application.Services.Finances;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class FinanceReportController : BaseController
{
    private readonly IFinanceReportCreator _financeReportCreator;
    public FinanceReportController(IFinanceReportCreator financeReportCreator)
    {
        _financeReportCreator = financeReportCreator ?? throw new ArgumentNullException(nameof(financeReportCreator));
    }

    [HttpPost("daily")]
    public async Task<IActionResult> CreateReportAsync([FromBody] CreateDailyReportRequest request)
    {
        return await ExecuteRequet(async () => await _financeReportCreator.CreateFinanceReportAsync(request));
    }

    [HttpPost("period")]
    public async Task<IActionResult> CreateReportAsync([FromBody] CreatePeriodReportRequest request)
    {
        return await ExecuteRequet(async () => await _financeReportCreator.CreateFinanceReportAsync(request));
    }
}
