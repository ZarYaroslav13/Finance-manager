using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.UseCases.FinanceReports.Commands.CreateDailyReportCommand;

public class CreateDailyReportCommand : IRequest<Result<FinanceReportDTO>>
{
    [GuidRequired]
    public Guid WalletId { get; set; }

    [Required]
    public DateTime Date { get; set; }
}
