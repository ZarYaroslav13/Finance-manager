using FinanceManager.Domain.DataAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.FinanceReports.Commands;

public class CreateDailyReportRequest
{
    [GuidRequired]
    public Guid WalletId { get; set; }

    [Required]
    public DateTime? Date { get; set; }
}
