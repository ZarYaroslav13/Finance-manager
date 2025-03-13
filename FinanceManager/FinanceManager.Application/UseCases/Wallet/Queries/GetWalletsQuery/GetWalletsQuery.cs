using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.Wallet.Queries.GetWalletsQuery;

public class GetWalletsQuery : IRequest<BaseResponse<List<WalletDTO>>>
{
    public int UserId { get; set; }

    public string UserRole { get; set; }

    public int AccountId { get; set; }
}
