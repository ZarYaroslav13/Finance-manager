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
        public const string FullBaseControllerUrl = _baseUrl + BaseControllerUrl;

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

    public static class UserPreferences
    {
        public const string BaseControllerUrl = "/user-preferences";
        public const string FullBaseControllerUrl = _baseUrl + BaseControllerUrl;

        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string GetUserPreferences = BaseControllerUrl + "/{id}";
        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string GetUserPreferencesFull = FullBaseControllerUrl + "/{id}";


        public const string Update = BaseControllerUrl;
        public const string UpdateFull = FullBaseControllerUrl;
    }

    public static class Accounts
    {
        public const string BaseControllerUrl = "/accounts";
        public const string FullBaseControllerUrl = _baseUrl + BaseControllerUrl;

        public const string Update = BaseControllerUrl;
        public const string UpdateFull = FullBaseControllerUrl;

        public const string ChangePassword = BaseControllerUrl + "/change-password";
        public const string ChangePasswordFull = FullBaseControllerUrl + "/change-password";
    }

    public static class Wallets
    {
        public const string BaseControllerUrl = "/wallets";
        public const string FullBaseControllerUrl = _baseUrl + BaseControllerUrl;

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

        public const string DeleteWallet = BaseControllerUrl;
        public const string DeleteWalletFull = FullBaseControllerUrl;
    }

    public static class FinanceReport
    {
        public const string BaseControllerUrl = "/finance-reports";
        public const string FullBaseControllerUrl = _baseUrl + BaseControllerUrl;

        public const string CreateDaily = BaseControllerUrl + "/daily";
        public const string CreateDailyFull = FullBaseControllerUrl + "/daily";

        public const string CreatePeriod = BaseControllerUrl + "/period";
        public const string CreatePeriodFull = FullBaseControllerUrl + "/period";
    }

    public static class FinanceOperationType
    {
        public const string ControllerUrl = "/finance-operation-types";
        public const string FullControllerUrl = _baseUrl + ControllerUrl;

        /// <summary>
        /// method where are you using that endpoint must take id with name userId
        /// </summary>
        public const string GetAllOfUser = ControllerUrl + "/users/{userId}";
        /// <summary>
        /// method where are you using that endpoint must take id with name userId
        /// </summary>
        public const string GetAllOfUserFull = FullControllerUrl + "/users/{userId}";

        /// <summary>
        /// method where are you using that endpoint must take id with name walletId
        /// </summary>
        public const string GetAll = ControllerUrl + "/wallet/{walletId}";
        /// <summary>
        /// method where are you using that endpoint must take id with name walletId
        /// </summary>
        public const string GetAllFull = FullControllerUrl + "/wallet/{walletId}";

        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string Get = ControllerUrl + "/{id}";
        /// <summary>
        /// method where are you using that endpoint must take id with name id
        /// </summary>
        public const string GetFull = FullControllerUrl + "/{id}";

        public const string Create = ControllerUrl;
        public const string CreateFull = FullControllerUrl;

        public const string Update = ControllerUrl;
        public const string UpdateFull = FullControllerUrl;

        public const string Delete = ControllerUrl;
        public const string DeleteFull = FullControllerUrl;
    }

    public static class FinanceOperation
    {
        public const string BaseControllerUrl = "/finance-operations";
        public const string FullBaseControllerUrl = _baseUrl + BaseControllerUrl;

        /// <summary>
        /// method where are you using that endpoint must take id with name walletId
        /// </summary>
        public const string GetAllByWallet = BaseControllerUrl + "/wallets/{request.WalletId}";
        /// <summary>
        /// method where are you using that endpoint must take id with name walletId
        /// </summary>
        public const string GetAllByWalletFull = FullBaseControllerUrl + "/wallets/{request.WalletId}";

        /// <summary>
        /// method where are you using that endpoint must take id with name typeId
        /// </summary>
        public const string GetAllByType = BaseControllerUrl + "/types/{request.TypeId}";
        /// <summary>
        /// method where are you using that endpoint must take id with name typeId
        /// </summary>
        public const string GetAllByTypeFull = FullBaseControllerUrl + "/types/{request.TypeId}";

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

        public const string DeleteOperation = BaseControllerUrl;
        public const string DeleteOperationFull = FullBaseControllerUrl;
    }
}
