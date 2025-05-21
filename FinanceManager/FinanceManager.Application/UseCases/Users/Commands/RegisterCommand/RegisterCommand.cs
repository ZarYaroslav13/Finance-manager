using System.ComponentModel.DataAnnotations;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Users.Commands.RegisterCommand;

public class RegisterCommand : IRequest<IResult>
{
    [Required]
    public string LastName { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Origin { get; set; }

    [Required]
    [Length(10, 50)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
