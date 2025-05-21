using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Wallets.Commands.DeleteWalletCommand;

public class DeleteWalletCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid WalletId { get; set; }
}
