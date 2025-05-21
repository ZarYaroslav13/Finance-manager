using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Wallets.Queries.GetWalletsQuery;

public class GetWalletsQuery : IRequest<Result<List<WalletDTO>>>
{
    [GuidRequired]
    public Guid AccountId { get; set; }
}
