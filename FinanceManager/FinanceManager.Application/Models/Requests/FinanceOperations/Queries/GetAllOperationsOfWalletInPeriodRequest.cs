using FinanceManager.Domain.DataAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.FinanceOperations.Queries;

public class GetAllOperationsOfWalletInPeriodRequest
{
    [GuidRequired]
    public Guid WalletId { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }
}
