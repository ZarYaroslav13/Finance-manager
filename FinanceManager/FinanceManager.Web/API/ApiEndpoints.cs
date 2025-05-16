using System.Diagnostics.CodeAnalysis;

namespace FinanceManager.Web.API;

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
}
