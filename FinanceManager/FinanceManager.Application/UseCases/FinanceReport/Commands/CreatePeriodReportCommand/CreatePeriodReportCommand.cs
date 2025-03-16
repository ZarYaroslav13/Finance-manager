using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceReport.Commands.CreatePeriodReportCommand;

public class CreatePeriodReportCommand : BaseRequest, IRequest<BaseResponse<FinanceReportDTO>>
{
    public int WalletId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
