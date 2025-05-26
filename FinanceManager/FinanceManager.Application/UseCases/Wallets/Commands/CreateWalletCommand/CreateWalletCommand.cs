using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Wallets.Commands.CreateWalletCommand;

public class CreateWalletCommand : IRequest<Result<WalletDTO>>
{
    [GuidRequired]
    public Guid UserId { get; set; }

    [Required]
    [Length(2, 50)]
    public string Name { get; set; }

    public int Balance { get; set; }
}
