using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.Login.Commands.SignInCommand;

public class SignInCommand : IRequest<BaseResponse<TokenDTO>>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Length(10, 50)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
