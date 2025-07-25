using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Domain.UseCases.Wallets.Queries.GetWalletsQuery;

public class GetWalletsQuery : IRequest<Result<List<WalletModel>>>
{
    [GuidRequired]
    public Guid AccountId { get; set; }
}
