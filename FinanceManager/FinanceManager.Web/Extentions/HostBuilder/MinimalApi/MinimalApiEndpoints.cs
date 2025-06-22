namespace FinanceManager.Web.Extentions.HostBuilder.MinimalApi;

public static class MinimalApiEndpoints
{
    public const string BaseUrl = "https://localhost:5066";

    public static class Downloads
    {
        public const string ControllerBaseUrl = "/downloads";

        /// <summary>
        /// Argument string "name"
        /// </summary>
        public const string Report = ControllerBaseUrl + "/reports/{name}";

        public const string ReportRequest = BaseUrl + ControllerBaseUrl + "/reports/";
    }

    public static class Authentication
    {
        public const string ControllerBaseUrl = "/authentication";

        public const string Login = ControllerBaseUrl + "/login";

        public const string Logout = ControllerBaseUrl + "/logout";
    }

    public static class Localization
    {
        public const string ControllerBaseUrl = "/localization";

        public const string ChangeCulture = ControllerBaseUrl + "/set-culture";
    }
}