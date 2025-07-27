using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Commons.Users.Commands.ForgotPasswordCommand;

public class ForgotPasswordCommand : IRequest<IResult>
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
