using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.Tokens.Commands;

public class GetTokenRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Length(10, 50)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
