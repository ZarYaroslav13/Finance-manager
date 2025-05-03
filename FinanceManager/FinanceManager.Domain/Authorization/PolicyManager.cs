namespace FinanceManager.Domain.Authorization;

public class PolicyManager
{
    public const string AdminRole = "Admin";
    public const string AdminPolicy = "OnlyForAdmins";

    public const string CommonUserPolicy = "ForCommonUsers";
    public const string UserRole = "User";
}
