using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Commons.Wallets.Commands.DeleteWalletCommand;

public class DeleteWalletCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid WalletId { get; set; }

    [Required]
    public bool IsUserOwner { get; set; }
}
