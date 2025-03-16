using AutoMapper;
using FinanceManager.ApiService.Controllers.Base;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.FinanceReport.Commands.CreateDailyReportCommand;
using FinanceManager.Application.UseCases.FinanceReport.Commands.CreatePeriodReportCommand;
using FinanceManager.Domain.Services.Finances;
using FinanceManager.Domain.Services.Wallets;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
