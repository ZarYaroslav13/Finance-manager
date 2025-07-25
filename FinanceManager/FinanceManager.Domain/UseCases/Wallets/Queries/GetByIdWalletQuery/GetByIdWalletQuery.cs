using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Wallets.Queries.GetByIdWalletQuery;

public class GetByIdWalletQuery : IRequest<Result<WalletModel>>
{
    [GuidRequired]
    public Guid WalletId { get; set; }
}
