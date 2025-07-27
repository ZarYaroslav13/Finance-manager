using FinanceManager.Domain.DataAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.Wallets.Commands;

public class UpdateWalletRequest
{
    [GuidRequired]
    public Guid Id { get; set; }

    [Required]
    [Length(2, 50)]
    public string Name { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Balance { get; set; } = 0;

    public List<FinanceOperationTypeDTO> FinanceOperationTypes { get; set; } = new();

    public List<IncomeDTO> Incomes { get; set; } = new();

    public List<ExpenseDTO> Expenses { get; set; } = new();

    [GuidRequired]
    public Guid UserId { get; set; }
}
