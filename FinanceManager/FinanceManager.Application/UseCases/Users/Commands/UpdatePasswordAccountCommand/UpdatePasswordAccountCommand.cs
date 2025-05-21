using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.Users.Commands.UpdatePasswordAccountCommand;

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
