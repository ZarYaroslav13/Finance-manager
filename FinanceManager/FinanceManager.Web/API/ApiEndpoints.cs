using System.Diagnostics.CodeAnalysis;

namespace FinanceManager.Web.API;

[ExcludeFromCodeCoverage]
public static class ApiEndpoints
{
    private const string _baseUrl = "https://localhost:7099/finance-manager";

    public static class Login
    {
        private const string _baseControllerUrl = _baseUrl + "/authorization";

        public const string SignIn = _baseControllerUrl + "/user/login";
        public const string SignInAsAdmin = _baseControllerUrl + "/admin/login";
        public const string SignUp = _baseControllerUrl + "/user/sign-up";
        public const string Refresh = _baseControllerUrl + "/to-do";
    }
}
