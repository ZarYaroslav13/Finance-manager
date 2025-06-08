using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Base;
using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreateDailyReportCommand;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreatePeriodReportCommand;
using FinanceManager.Application.UseCases.Preferences.Command.UpdateUserPreferencesCommand;
using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Application.UseCases.Tokens.Commands.RefreshTokenCommand;
using FinanceManager.Application.UseCases.Users.Commands.ForgotPasswordCommand;
using FinanceManager.Application.UseCases.Users.Commands.RegisterCommand;
using FinanceManager.Application.UseCases.Users.Commands.ResetPasswordCommand;
using FinanceManager.Application.UseCases.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Application.UseCases.Wallets.Commands.UpdateWalletCommand;
using FinanceManager.Domain.API;
using FinanceManager.Domain.Wrapper;
using Refit;

namespace FinanceManager.Web.Services.APIServices.APIHttpClient;

public interface IFinanceManagerApiHttpClient
{
    #region Tokens
    [Post(APIEndpoints.Token.Get)]
    public Task<Result<TokenDTO>> GetTokenAsync([Body] GetTokenCommand command);

    [Post(APIEndpoints.Token.Refresh)]
    public Task<Result<TokenDTO>> RefreshTokenAsync([Body] RefreshTokenCommand command);
    #endregion

    #region Users

    [Get(APIEndpoints.Users.GetAll)]
    public Task<PaginatedResult<UserDTO>> GetAllUsersAsync([Query] int pageNumber, [Query] int take);

    [Get(APIEndpoints.Users.GetUser)]
    public Task<Result<UserDTO>> GetUserAsync(Guid id);

    [Get(APIEndpoints.Users.ConfirmEmail)]
    public Task<Result> ConfirmEmailAsync([Query] Guid userId, [Query] string code);

    [Post(APIEndpoints.Users.Register)]
    public Task<Result> RegisterUserAsync([Body] RegisterCommand command);

    [Post(APIEndpoints.Users.ForgotPassword)]
    public Task<Result> ForgotPasswordAsync([Body] ForgotPasswordCommand command);

    [Post(APIEndpoints.Users.ResetPassword)]
    public Task<Result> ResetPasswordAsync([Body] ResetPasswordCommand command);

    [Delete(APIEndpoints.Users.DeleteUser)]
    public Task<Result> DeleteUserdAsync(Guid id);
    #endregion

    #region UserPreferences
    [Get(APIEndpoints.UserPreferences.GetUserPreferences)]
    public Task<Result<UserPreferencesDTO>> GetUserPreferences(Guid id);

    [Put(APIEndpoints.UserPreferences.Update)]
    public Task<Result<UserPreferencesDTO>> UpdateUserPreferences([Body] UpdateUserPreferencesCommand command);
    #endregion

    #region Accounts
    [Put(APIEndpoints.Accounts.Update)]
    public Task<Result> UpdateAccountAsync([Body] UpdateAccountCommand command);

    [Patch(APIEndpoints.Accounts.ChangePassword)]
    public Task<Result> ChangeAccountPasswordAsync([Body] ChangeUserPasswordCommand command);
    #endregion

    #region Wallets
    [Get(APIEndpoints.Wallets.GetAll)]
    public Task<Result<List<WalletDTO>>> GetWalletsAsync(Guid accountId);

    [Get(APIEndpoints.Wallets.GetWallet)]
    public Task<Result<WalletDTO>> GetWalletAsync(Guid id);

    [Post(APIEndpoints.Wallets.Create)]
    public Task<Result<WalletDTO>> CreateWallet([Body] CreateWalletCommand command);

    [Put(APIEndpoints.Wallets.Update)]
    public Task<Result<WalletDTO>> UpdateWallet([Body] UpdateWalletCommand command);

    [Delete(APIEndpoints.Wallets.DeleteWallet)]
    public Task<Result> DeleteWallet(Guid id);
    #endregion

    #region Reports
    [Post(APIEndpoints.FinanceReport.CreateDaily)]
    public Task<Result<FinanceReportDTO>> CreateDailyReport([Body] CreateDailyReportCommand command);

    [Post(APIEndpoints.FinanceReport.CreatePeriod)]
    public Task<Result<FinanceReportDTO>> CreatePeriodReport([Body] CreatePeriodReportCommand command);
    #endregion

    #region FinanceOperationTypes
    [Get(APIEndpoints.FinanceOperationType.GetAll)]
    public Task<Result<List<FinanceOperationTypeDTO>>> GetAllFinanceOperationTypesAsync(Guid walletId);

    [Get(APIEndpoints.FinanceOperationType.Get)]
    public Task<Result<FinanceOperationTypeDTO>> GetFinanceOperationTypeAsync(Guid id);

    [Get(APIEndpoints.FinanceOperationType.Create)]
    public Task<Result<FinanceOperationTypeDTO>> AddFinanceOperationTypeAsync([Body] AddFinanceOperationTypeCommand command);

    [Get(APIEndpoints.FinanceOperationType.Update)]
    public Task<Result<FinanceOperationTypeDTO>> UpdateFinanceOperationTypeAsync([Body] UpdateFinanceOperationTypeCommand command);

    [Get(APIEndpoints.FinanceOperationType.Delete)]
    public Task<Result> DeleteFinanceOperationTypeAsync(Guid id);
    #endregion

    #region FinanceOperations
    [Get(APIEndpoints.FinanceOperation.GetAllByWallet)]
    public Task<Result<List<FinanceOperationDTO>>> GetAllOfWalletAsync(
        Guid walletId,
        [Query] int index,
        [Query] int count);

    [Get(APIEndpoints.FinanceOperation.GetAllByType)]
    public Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationsOfTypeAsync(
        Guid typeId,
        [Query] int index,
        [Query] int count);

    [Get(APIEndpoints.FinanceOperation.GetOperation)]
    public Task<Result<FinanceOperationDTO>> GetFinanceOperationAsync(Guid id);

    [Post(APIEndpoints.FinanceOperation.Create)]
    public Task<Result<FinanceOperationDTO>> AddFinanceOperationAsync([Body] AddFinanceOperationTypeCommand command);

    [Post(APIEndpoints.FinanceOperation.Update)]
    public Task<Result<FinanceOperationDTO>> UpdateFinanceOperationAsync([Body] UpdateFinanceOperationTypeCommand command);

    [Post(APIEndpoints.FinanceOperation.DeleteOperation)]
    public Task<Result> DeleteFinanceOperationAsync(Guid id);
    #endregion
}
