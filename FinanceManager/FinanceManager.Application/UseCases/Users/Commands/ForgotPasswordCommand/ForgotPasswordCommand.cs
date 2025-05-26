using System.ComponentModel.DataAnnotations;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Users.Commands.ForgotPasswordCommand;

public class ForgotPasswordCommand : IRequest<IResult>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
