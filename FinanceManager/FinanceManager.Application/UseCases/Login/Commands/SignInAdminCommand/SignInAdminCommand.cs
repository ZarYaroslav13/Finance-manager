using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;

namespace FinanceManager.Application.UseCases.Login.Commands.SignInAdminCommand;

public class SignInAdminCommand : IRequest<BaseResponse<TokenDTO>>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Length(10, 50)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
