using System.Diagnostics.CodeAnalysis;

namespace FinanceManager.Domain.API;

[ExcludeFromCodeCoverage]
public static class APIEndpoints
{
    private const string _baseUrl = "https://localhost:7099/finance-manager";

    public static class Token
    {
        public const string BaseControllerUrl = "/tokens";
        public const string FullBaseControllerUrl = _baseUrl + "/tokens";


        public const string Get = BaseControllerUrl;
        public const string GetFull = FullBaseControllerUrl;

        public const string Refresh = BaseControllerUrl + "/refresh";
        public const string RefreshFull = FullBaseControllerUrl + "/refresh";
    }

    public static class Users
    {
        public const string BaseControllerUrl = "/users";
        public const string FullBaseControllerUrl = _baseUrl + "/users";

        public const string GetAll = BaseControllerUrl;
        public const string GetAllFull = FullBaseControllerUrl;

        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string GetUser = BaseControllerUrl + "/{id}";
        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string GetUserFull = FullBaseControllerUrl + "/{id}";

        public const string ConfirmEmail = BaseControllerUrl + "/confirm-email";
        public const string ConfirmEmailFull = FullBaseControllerUrl + "/confirm-email";

        public const string Register = BaseControllerUrl;
        public const string RegisterFull = FullBaseControllerUrl;

        public const string ForgotPassword = BaseControllerUrl + "/forgot-password";
        public const string ForgotPasswordFull = FullBaseControllerUrl + "/forgot-password";

        public const string ResetPassword = BaseControllerUrl + "/reset-password";
        public const string ResetPasswordFull = FullBaseControllerUrl + "/reset-password";

        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string DeleteUser = BaseControllerUrl + "/{id}";
        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string DeleteUserFull = FullBaseControllerUrl + "/{id}";
    }

    public static class Accounts
    {
        public const string BaseControllerUrl = "/accounts";
        public const string FullBaseControllerUrl = _baseUrl + "/accounts";

        public const string Update = BaseControllerUrl;
        public const string UpdateFull = FullBaseControllerUrl;

        public const string ChangePassword = BaseControllerUrl + "/change-password";
        public const string ChangePasswordFull = FullBaseControllerUrl + "/change-password";
    }

    public static class Wallets
    {
        public const string BaseControllerUrl = "/wallets";
        public const string FullBaseControllerUrl = _baseUrl + "/wallets";

        /// <summary>
        /// method where are you using that endpoint must take id with name accountId
        /// </summary>
        public const string GetAll = "/accounts/{accountId}/wallets";
        /// <summary>
        /// method where are you using that endpoint must take id with name accountId
        /// </summary>
        public const string GetAllFull = _baseUrl + "/accounts/{accountId}/wallets";

        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string GetWallet = BaseControllerUrl + "/{id}";
        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string GetWalletFull = FullBaseControllerUrl + "/{id}";

        public const string Create = BaseControllerUrl;
        public const string CreateFull = FullBaseControllerUrl;

        public const string Update = BaseControllerUrl;
        public const string UpdateFull = FullBaseControllerUrl;

        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string DeleteWallet = BaseControllerUrl + "/{id}";
        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string DeleteWalletFull = FullBaseControllerUrl + "/{id}";
    }

    public static class FinanceReport
    {
        public const string BaseControllerUrl = "/finance-reports";
        public const string FullBaseControllerUrl = _baseUrl + "/finance-reports";

        public const string CreateDaily = BaseControllerUrl + "/daily";
        public const string CreateDailyFull = FullBaseControllerUrl + "/daily";

        public const string CreatePeriod = BaseControllerUrl + "/period";
        public const string CreatePeriodFull = FullBaseControllerUrl + "/period";
    }

    public static class FinanceOperationType
    {
        public const string BaseControllerUrl = "/finance-operation-types";
        public const string FullBaseControllerUrl = _baseUrl + "/finance-operation-types";

        /// <summary>
        /// method where are you using that endpoint must take id with name walletId
        /// </summary>
        public const string GetAll = BaseControllerUrl + "/wallet/{walletId}";
        /// <summary>
        /// method where are you using that endpoint must take id with name walletId
        /// </summary>
        public const string GetAllFull = FullBaseControllerUrl + "/wallet/{walletId}";

        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string Get = BaseControllerUrl + "/{id}";
        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string GetFull = FullBaseControllerUrl + "/{id}";

        public const string Create = BaseControllerUrl;
        public const string CreateFull = FullBaseControllerUrl;

        public const string Update = BaseControllerUrl;
        public const string UpdateFull = FullBaseControllerUrl;

        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string Delete = BaseControllerUrl + "/{id}";
        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string DeleteFull = FullBaseControllerUrl + "/{id}";
    }

    public static class FinanceOperation
    {
        public const string BaseControllerUrl = "/finance-operations";
        public const string FullBaseControllerUrl = _baseUrl + "/finance-operations";

        /// <summary>
        /// method where are you using that endpoint must take id with name walletId
        /// </summary>
        public const string GetAllByWallet = BaseControllerUrl + "/{walletId}";
        /// <summary>
        /// method where are you using that endpoint must take id with name walletId
        /// </summary>
        public const string GetAllByWalletFull = FullBaseControllerUrl + "/{walletId}";

        /// <summary>
        /// method where are you using that endpoint must take id with name typeId
        /// </summary>
        public const string GetAllByType = BaseControllerUrl + "/{typeId}";
        /// <summary>
        /// method where are you using that endpoint must take id with name typeId
        /// </summary>
        public const string GetAllByTypeFull = FullBaseControllerUrl + "/{typeId}";

        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string GetOperation = BaseControllerUrl + "/{id}";
        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string GetOperationFull = FullBaseControllerUrl + "/{id}";

        public const string Create = BaseControllerUrl;
        public const string CreateFull = FullBaseControllerUrl;

        public const string Update = BaseControllerUrl;
        public const string UpdateFull = FullBaseControllerUrl;

        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string DeleteOperation = BaseControllerUrl + "/{id}";
        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string DeleteOperationFull = FullBaseControllerUrl + "/{id}";
    }
}
