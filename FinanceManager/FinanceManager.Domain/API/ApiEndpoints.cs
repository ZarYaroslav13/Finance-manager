using System.Diagnostics.CodeAnalysis;

namespace FinanceManager.Domain.API;

[ExcludeFromCodeCoverage]
public static class APIEndpoints
{
    private const string _baseUrl = "https://localhost:7099/finance-manager";

    public static class Token
    {
        public const string BaseControllerUrl = _baseUrl + "/tokens";

        public const string Get = BaseControllerUrl;
        public const string Refresh = BaseControllerUrl + "/refresh";
    }

    public static class Users
    {
        public const string BaseControllerUrl = _baseUrl + "/users";

        public const string GetAll = BaseControllerUrl;
        public static string Get(Guid id) => BaseControllerUrl + '/' + id.ToString();

        public const string ConfirmEmail = BaseControllerUrl + "/confirm-email";

        public const string Register = BaseControllerUrl;

        public const string ForgotPassword = BaseControllerUrl + "/forgot-password";

        public const string ResetPassword = BaseControllerUrl + "/reset-password";
        public static string DeleteUser(Guid id) => BaseControllerUrl + '/' + id.ToString();
    }

    public static class Accounts
    {
        public const string BaseControllerUrl = _baseUrl + "/accounts";

        public const string Update = BaseControllerUrl;

        public const string ChangePassword = BaseControllerUrl + "/change-password";
    }

    public static class Wallets
    {
        public const string BaseControllerUrl = _baseUrl + "/wallets";

        public static string GetAll(Guid accountId) => _baseUrl + "/accounts/" + accountId.ToString() + "/wallets";

        public static string Get(Guid id) => BaseControllerUrl + '/' + id.ToString();

        public static string Create = BaseControllerUrl;

        public static string Update = BaseControllerUrl;

        public static string Delete(Guid id) => BaseControllerUrl + '/' + id.ToString();
    }

    public static class FinanceOperationType
    {
        public const string BaseControllerUrl = _baseUrl + "/finance-operation-types";

        public static string Get(Guid id) => BaseControllerUrl + '/' + id.ToString();

        public static string Create = BaseControllerUrl;

        public static string Update = BaseControllerUrl;

        public static string Delete(Guid id) => BaseControllerUrl + '/' + id.ToString();
    }

    public static class FinanceOperation
    {
        public const string BaseControllerUrl = _baseUrl + "/finance-operations";

        public static string Get(Guid id) => BaseControllerUrl + '/' + id.ToString();

        public static string Create = BaseControllerUrl;

        public static string Update = BaseControllerUrl;

        public static string Delete(Guid id) => BaseControllerUrl + '/' + id.ToString();
    }

    public static class FinanceReport
    {
        public const string BaseControllerUrl = _baseUrl + "/finance-reports";

        public const string GetDaily = BaseControllerUrl + "/daily";

        public const string GetPeriod = BaseControllerUrl + "/period";
    }
}
