using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.FinanceReport.Commands.CreateDailyReportCommand;

public class CreateDailyReportCommand : BaseRequest, IRequest<BaseResponse<FinanceReportDTO>>
{
    public int WalletId { get; set; }
    public DateTime Date { get; set; }
}
