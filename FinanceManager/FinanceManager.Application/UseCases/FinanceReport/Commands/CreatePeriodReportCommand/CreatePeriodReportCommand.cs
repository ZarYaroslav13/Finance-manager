using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceReport.Commands.CreatePeriodReportCommand;

public class CreatePeriodReportCommand : IRequest<Result<FinanceReportDTO>>
{
    public string WalletId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
