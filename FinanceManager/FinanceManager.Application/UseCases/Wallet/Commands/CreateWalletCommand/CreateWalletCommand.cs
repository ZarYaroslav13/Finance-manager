using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.UseCases.Wallet.Commands.CreateWalletCommand;

public class CreateWalletCommand : IRequest<BaseResponse<WalletDTO>>
{
    public int AccountId { get; set; }

    [Required]
    [Length(2, 50)]
    public string Name { get; set; }
}
