using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.Wallet.Queries.GetByIdWalletQuery;

public class GetByIdWalletQuery : BaseRequest, IRequest<BaseResponse<WalletDTO>>
{
    public int WalletId { get; set; }
}
