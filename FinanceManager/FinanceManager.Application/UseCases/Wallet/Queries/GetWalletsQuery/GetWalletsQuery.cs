using FinanceManager.Application.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.Wallet.Queries.GetWalletsQuery;

public class GetWalletsQuery : BaseRequest, IRequest<BaseResponse<List<WalletDTO>>>
{
    public int AccountId { get; set; }
}
