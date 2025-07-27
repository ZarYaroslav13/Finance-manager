using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Commons.Wallets.Queries.IsCallerWalletOwnerQuery;

public class IsCallerWalletOwnerQuery : IRequest<IResult<bool>>
{
    [GuidRequired]
    public Guid WalletId { get; set; }
}
