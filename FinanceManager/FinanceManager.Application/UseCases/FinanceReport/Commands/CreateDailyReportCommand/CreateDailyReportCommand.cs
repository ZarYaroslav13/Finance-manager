using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceReport.Commands.CreateDailyReportCommand;

public class CreateDailyReportCommand : BaseRequest, IRequest<BaseResponse<FinanceReportDTO>>
{
    public int WalletId { get; set; }
    public DateTime Date { get; set; }
}
