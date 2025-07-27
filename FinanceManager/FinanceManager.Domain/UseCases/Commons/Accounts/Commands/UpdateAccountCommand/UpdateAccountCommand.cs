using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Commons.Accounts.Commands.UpdateAccountCommand;

public class UpdateAccountCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid Id { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
