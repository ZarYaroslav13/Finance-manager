using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.Users.Commands;

public class RegisterRequest
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

    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}
