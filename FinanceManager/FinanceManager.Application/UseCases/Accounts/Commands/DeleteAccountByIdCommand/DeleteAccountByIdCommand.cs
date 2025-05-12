using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.Accounts.Commands.DeleteAccountByIdCommand;

public class DeleteAccountByIdCommand : BaseRequest, IRequest<BaseResponse<bool>>
{
    [Required]
    public int Id { get; set; }
}
