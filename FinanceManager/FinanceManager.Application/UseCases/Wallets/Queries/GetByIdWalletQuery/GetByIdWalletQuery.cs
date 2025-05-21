using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Wallets.Queries.GetByIdWalletQuery;

public class GetByIdWalletQuery : IRequest<Result<WalletDTO>>
{
    [GuidRequired]
    public Guid WalletId { get; set; }
}
