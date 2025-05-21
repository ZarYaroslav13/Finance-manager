using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreateDailyReportCommand;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreatePeriodReportCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceManager.ApiService.Controllers;

public class FinanceReportController : BaseController
{
    public FinanceReportController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("daily")]
    public async Task<IActionResult> CreateReportAsync([FromBody] CreateDailyReportCommand command)
    {
        return await SendRequestAsync(command);
    }

    [HttpPost("period")]
    public async Task<IActionResult> CreateReportAsync([FromBody] CreatePeriodReportCommand command)
    {
        return await SendRequestAsync(command);
    }
}
