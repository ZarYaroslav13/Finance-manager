using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.FinanceReports.Commands.CreatePeriodReportCommand;

public class CreatePeriodReportCommand : IRequest<Result<FinanceReportModel>>
{
    [GuidRequired]
    public Guid WalletId { get; set; }

    [Required]
    public DateTime? StartDate { get; set; }

    [Required]
    public DateTime? EndDate { get; set; }
}
