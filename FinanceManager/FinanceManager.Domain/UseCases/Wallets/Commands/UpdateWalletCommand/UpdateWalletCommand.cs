using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Wallets.Commands.UpdateWalletCommand;

public class UpdateWalletCommand : IRequest<Result<WalletModel>>
{
    [GuidRequired]
    public Guid Id { get; set; }

    [Required]
    [Length(2, 50)]
    public string Name { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Balance { get; set; } = 0;

    public List<FinanceOperationTypeModel> FinanceOperationTypes { get; set; } = new();

    public List<IncomeModel> Incomes { get; set; } = new();

    public List<ExpenseModel> Expenses { get; set; } = new();

    [GuidRequired]
    public Guid UserId { get; set; }

    [Required]
    public bool IsUserOwner { get; set; }
}
