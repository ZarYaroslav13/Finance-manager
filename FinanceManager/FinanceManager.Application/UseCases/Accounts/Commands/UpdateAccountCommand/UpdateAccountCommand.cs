using FinanceManager.Application.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FinanceManager.Application.UseCases.Accounts.Commands.UpdateCommand;

public class UpdateAccountCommand : IRequest<AccountDTO>
{
    public ClaimsIdentity? Identity { get; set; }

    [Required]
    public int Id { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
