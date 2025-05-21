using System.ComponentModel.DataAnnotations;
using MediatR;

namespace FinanceManager.Application.UseCases.Login.Commands.CreateAccountCommand;

public class CreateAccountCommand : IRequest<BaseResponse<bool>>
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
