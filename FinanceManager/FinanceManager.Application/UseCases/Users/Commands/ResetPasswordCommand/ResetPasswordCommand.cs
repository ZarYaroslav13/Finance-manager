using System.ComponentModel.DataAnnotations;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Users.Commands.ResetPasswordCommand;

public class ResetPasswordCommand : IRequest<IResult>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }

    [Required]
    public string Token { get; set; }
}
