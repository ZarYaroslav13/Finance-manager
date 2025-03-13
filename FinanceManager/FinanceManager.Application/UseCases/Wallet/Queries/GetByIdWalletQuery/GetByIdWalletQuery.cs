using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.Wallet.Queries.GetByIdWalletQuery;

public class GetByIdWalletQuery : IRequest<BaseResponse<WalletDTO>>
{
    public int UserId { get; set; }

    public string UserRole { get; set; }

    public int WalletId { get; set; }
}
