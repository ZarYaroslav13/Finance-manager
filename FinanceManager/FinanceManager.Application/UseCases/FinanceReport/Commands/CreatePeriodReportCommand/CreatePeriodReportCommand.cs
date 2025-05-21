using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceReport.Commands.CreatePeriodReportCommand;

public class CreatePeriodReportCommand : IRequest<Result<FinanceReportDTO>>
{
    [GuidRequired]
    public Guid WalletId { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }
}
