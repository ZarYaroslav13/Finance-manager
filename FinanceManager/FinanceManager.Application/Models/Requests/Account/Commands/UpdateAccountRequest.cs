using FinanceManager.Domain.DataAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.Account.Commands;

public class UpdateAccountRequest
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
