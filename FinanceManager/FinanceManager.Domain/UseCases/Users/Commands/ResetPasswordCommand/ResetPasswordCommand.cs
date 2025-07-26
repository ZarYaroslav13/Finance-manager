using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Users.Commands.ResetPasswordCommand;

public class ResetPasswordCommand : IRequest<IResult>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Length(10, 50)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    public string Token { get; set; }
}
