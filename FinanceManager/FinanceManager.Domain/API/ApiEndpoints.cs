using System.Diagnostics.CodeAnalysis;

namespace FinanceManager.Domain.API;

[ExcludeFromCodeCoverage]
public static class ApiEndpoints
{
    private const string _baseUrl = "https://localhost:7099/finance-manager";

    public static class Login
    {
        public const string BaseControllerUrl = _baseUrl + "/authorization";

        public const string SignIn = BaseControllerUrl + "/user/login";
        public const string SignInAsAdmin = BaseControllerUrl + "/admin/login";
        public const string SignUp = BaseControllerUrl + "/user/sign-up";
        public const string Refresh = BaseControllerUrl + "/to-do";
    }
    public static class Accounts
    {
        public const string BaseControllerUrl = _baseUrl + "/accounts";

        public const string GetCurrent = BaseControllerUrl;
        public static string Get(string Id)
        {
            return GetCurrent + '/' + Id;
        }
    }

    public static class Users
    {
        public const string BaseControllerUrl = _baseUrl + "/users";

        public const string ResetPassword = _baseUrl + "/reset";

        public const string ConfirmEmail = _baseUrl + "/confirm-email";
    }
}
