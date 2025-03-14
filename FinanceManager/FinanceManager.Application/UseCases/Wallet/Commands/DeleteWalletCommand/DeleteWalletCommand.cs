using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.Wallet.Commands.DeleteWalletCommand;

public class DeleteWalletCommand : BaseRequest,  IRequest<BaseResponse<bool>>
{
    public int WalletId { get; set; }
}
