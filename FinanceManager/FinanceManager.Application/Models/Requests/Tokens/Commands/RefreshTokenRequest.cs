using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.Tokens.Commands;

public class RefreshTokenRequest
{
    [Required]
    public string Token { get; set; }

    [Required]
    public string RefreshToken { get; set; }
}
