using FinanceManager.Domain.DataAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.FinanceOperations.Commands;

public class AddFinanceOperationRequest
{
    [Range(0, int.MaxValue)]
    public int Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [GuidRequired]
    public Guid TypeId { get; set; }
}
