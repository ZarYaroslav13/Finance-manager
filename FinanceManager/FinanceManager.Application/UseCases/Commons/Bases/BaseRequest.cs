namespace FinanceManager.Application.UseCases.Commons.Bases;

public class BaseRequest
{
    public int UserId { get; set; }

    public string UserRole { get; set; } = String.Empty;
}
