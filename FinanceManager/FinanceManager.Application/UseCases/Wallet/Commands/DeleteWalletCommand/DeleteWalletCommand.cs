using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.Wallet.Commands.DeleteWalletCommand;

public class DeleteWalletCommand : IRequest<BaseResponse<bool>>
{
    public int UsertId { get; set; }

    public string UsertRole { get; set; }

    public int WalletId { get; set; }
}
