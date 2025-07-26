using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.Users.Commands;

public class ForgotPasswordRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
