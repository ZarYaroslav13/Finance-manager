namespace FinanceManager.Web.Pages;

public static class PagesHref
{
    public const string Home = "/";

    public static class Authentication
    {
        public const string Login = "/login";

        public const string Register = "/register";
    }

    public static class Personal
    {
        public const string Account = "/account";

        public static class Wallet
        {
            public const string Wallets = "wallets";
        }

        public static class FinanceOperationType
        {
            public const string FinanceOperationTypes = "finance-operation-types";
        }

        public static class FinanceOperation
        {
            public const string FinanceOperations = "finance-operations";
        }

        public const string FinanceReports = "finance-reports";
    }

    public static class Admin
    {
        public const string Users = "/users";

        public const string Roles = "/roles";
    }

    public const string Logout = "/logout";
}
