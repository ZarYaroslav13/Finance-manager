namespace FinanceManager.Domain.Services.CurrentUserService;

public interface ICurrentUserService
{
    string UserId { get; }

    List<string> Roles { get; }

    bool IsAdmin { get; }
}
