using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceReport.Commands.CreateDailyReportCommand;

public class CreateDailyReportCommand : IRequest<Result<FinanceReportDTO>>
{
    public string WalletId { get; set; }
    public DateTime Date { get; set; }
}
