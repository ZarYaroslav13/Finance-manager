namespace FinanceManager.Application.Models;

public class AutenticationTokenDTO
{
    public string JWTToken { get; set; }

    public string RefreshToken { get; set; }
}
