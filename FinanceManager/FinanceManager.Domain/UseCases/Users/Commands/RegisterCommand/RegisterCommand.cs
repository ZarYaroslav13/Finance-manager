using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Users.Commands.RegisterCommand;

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
    [Length(10, 50)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
