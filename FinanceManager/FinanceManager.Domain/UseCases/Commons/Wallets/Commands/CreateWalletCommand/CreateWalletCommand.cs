using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Commons.Wallets.Commands.CreateWalletCommand;

public class CreateWalletCommand : IRequest<Result<WalletModel>>
{
    [GuidRequired]
    public Guid UserId { get; set; }

    [Required]
    [Length(2, 50)]
    public string Name { get; set; }

    public int Balance { get; set; }
}
