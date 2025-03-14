using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.UseCases.Accounts.Commands.UpdatePasswordAccountCommand;

public class UpdatePasswordAccountCommand : BaseRequest, IRequest<BaseResponse<AccountDTO>>
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Length(10, 50)]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; }

    [Required]
    [Length(10, 50)]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }
}
