using FinanceManager.Application.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.Wallet.Queries.GetByIdWalletQuery;

public class GetByIdWalletQuery : BaseRequest, IRequest<BaseResponse<WalletDTO>>
{
    public int WalletId { get; set; }
}
