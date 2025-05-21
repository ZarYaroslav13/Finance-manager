namespace FinanceManager.Application.Models;

public class TokenDTO
{
    public string Token { get; set; }

    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}
