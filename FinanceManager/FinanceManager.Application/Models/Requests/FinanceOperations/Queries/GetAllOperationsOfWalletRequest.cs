using FinanceManager.Domain.DataAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.FinanceOperations.Queries;

public class GetAllOperationsOfWalletRequest
{
    [GuidRequired]
    public Guid WalletId { get; set; }

    [Range(0, int.MaxValue)]
    public int Index { get; set; } = 0;

    [Range(0, int.MaxValue)]
    public int Count { get; set; } = 0;
}
