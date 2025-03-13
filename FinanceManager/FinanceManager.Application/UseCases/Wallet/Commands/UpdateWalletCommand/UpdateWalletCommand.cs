using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.UseCases.Wallet.Commands.UpdateWalletCommand;

public class UpdateWalletCommand : IRequest<BaseResponse<WalletDTO>>
{
    public int UserId { get; set; }

    public string UserRole { get; set; }

    public int Id { get; set; }

    [Required]
    [Length(2, 50)]
    public string Name { get; set; }

    public int Balance { get; set; } = 0;

    public List<FinanceOperationTypeDTO> FinanceOperationTypes { get; set; } = new();

    public List<IncomeDTO> Incomes { get; set; } = new();

    public List<ExpenseDTO> Expenses { get; set; } = new();

    public int AccountId { get; set; }
}
