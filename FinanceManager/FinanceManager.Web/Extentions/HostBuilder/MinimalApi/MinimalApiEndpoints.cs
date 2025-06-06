namespace FinanceManager.Web.Extentions.HostBuilder.MinimalApi;

public static class MinimalApiEndpoints
{
    public const string BaseUrl = "https://localhost:5066";

    public static class Authentication
    {
        public const string ControllerBaseUrl = "/authentication";

        public const string Login = ControllerBaseUrl + "/login";
    }
}