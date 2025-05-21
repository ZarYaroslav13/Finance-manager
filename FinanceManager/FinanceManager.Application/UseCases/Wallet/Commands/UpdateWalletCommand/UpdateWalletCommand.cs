using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Wallets.Commands.UpdateWalletCommand;

public class UpdateWalletCommand : IRequest<Result<WalletDTO>>
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
    public Guid AccountId { get; set; }
}
