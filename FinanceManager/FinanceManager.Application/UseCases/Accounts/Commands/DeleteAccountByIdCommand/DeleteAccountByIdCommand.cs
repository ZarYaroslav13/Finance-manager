using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.UseCases.Accounts.Commands.DeleteAccountByIdCommand;

public class DeleteAccountByIdCommand : BaseRequest, IRequest<BaseResponse<bool>>
{
    [Required]
    public int Id { get; set; }
}
