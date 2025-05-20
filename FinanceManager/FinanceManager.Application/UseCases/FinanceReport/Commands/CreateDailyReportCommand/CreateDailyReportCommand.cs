using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceReport.Commands.CreateDailyReportCommand;

public class CreateDailyReportCommand : BaseRequest, IRequest<Result<FinanceReportDTO>>
{
    public Guid WalletId { get; set; }
    public DateTime Date { get; set; }
}
