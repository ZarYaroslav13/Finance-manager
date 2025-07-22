using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Base;
using FinanceManager.Application.UseCases.FinanceOperations.Commands.AddFinanceOperationCommand;
using FinanceManager.Application.UseCases.FinanceOperations.Commands.UpdateFinanceOperationCommand;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreateDailyReportCommand;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreatePeriodReportCommand;
using FinanceManager.Application.UseCases.Users.Commands.ForgotPasswordCommand;
using FinanceManager.Application.UseCases.Users.Commands.RegisterCommand;
using FinanceManager.Application.UseCases.Users.Commands.ResetPasswordCommand;
using FinanceManager.Application.UseCases.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Application.UseCases.Wallets.Commands.UpdateWalletCommand;
using FinanceManager.Domain.API;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;
using FinanceManager.Domain.UseCases.Preferences.Command.UpdateUserPreferencesCommand;
using FinanceManager.Domain.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Domain.UseCases.Tokens.Commands.RefreshTokenCommand;
using FinanceManager.Domain.Wrapper;
using Refit;

namespace FinanceManager.Web.Services.APIServices.APIHttpClient;

public interface IFinanceManagerApiHttpClient
{
    #region Tokens
    [Post(APIEndpoints.Token.Get)]
    public Task<Result<TokenDTO>> GetTokenAsync([Body] GetTokenCommand command, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.Token.Refresh)]
    public Task<Result<TokenDTO>> RefreshTokenAsync([Body] RefreshTokenCommand command, CancellationToken cancellationToken = default);
    #endregion

    #region Users

    [Get(APIEndpoints.Users.GetAll)]
    public Task<PaginatedResult<UserDTO>> GetAllUsersAsync([Query] int pageNumber, [Query] int take, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.Users.GetUser)]
    public Task<Result<UserDTO>> GetUserAsync(Guid id, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.Users.ConfirmEmail)]
    public Task<Result> ConfirmEmailAsync([Query] Guid userId, [Query] string code, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.Users.Register)]
    public Task<Result> RegisterUserAsync([Body] RegisterCommand command, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.Users.ForgotPassword)]
    public Task<Result> ForgotPasswordAsync([Body] ForgotPasswordCommand command, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.Users.ResetPassword)]
    public Task<Result> ResetPasswordAsync([Body] ResetPasswordCommand command, CancellationToken cancellationToken = default);

    [Delete(APIEndpoints.Users.DeleteUser)]
    public Task<Result> DeleteUserdAsync(Guid id, CancellationToken cancellationToken = default);
    #endregion

    #region UserPreferences
    [Get(APIEndpoints.UserPreferences.GetUserPreferences)]
    public Task<Result<UserPreferencesDTO>> GetUserPreferences(Guid id, CancellationToken cancellationToken = default);

    [Put(APIEndpoints.UserPreferences.Update)]
    public Task<Result<UserPreferencesDTO>> UpdateUserPreferences([Body] UpdateUserPreferencesCommand command, CancellationToken cancellationToken = default);
    #endregion

    #region Accounts
    [Put(APIEndpoints.Accounts.Update)]
    public Task<Result> UpdateAccountAsync([Body] UpdateAccountCommand command, CancellationToken cancellationToken = default);

    [Patch(APIEndpoints.Accounts.ChangePassword)]
    public Task<Result> ChangeAccountPasswordAsync([Body] ChangeUserPasswordCommand command, CancellationToken cancellationToken = default);
    #endregion

    #region Wallets
    [Get(APIEndpoints.Wallets.GetAll)]
    public Task<Result<List<WalletDTO>>> GetWalletsAsync(Guid accountId, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.Wallets.GetWallet)]
    public Task<Result<WalletDTO>> GetWalletAsync(Guid id, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.Wallets.Create)]
    public Task<Result<WalletDTO>> CreateWallet([Body] CreateWalletCommand command, CancellationToken cancellationToken = default);

    [Put(APIEndpoints.Wallets.Update)]
    public Task<Result<WalletDTO>> UpdateWallet([Body] UpdateWalletCommand command, CancellationToken cancellationToken = default);

    [Delete(APIEndpoints.Wallets.DeleteWallet)]
    public Task<Result> DeleteWallet(Guid id, CancellationToken cancellationToken = default);
    #endregion

    #region Reports
    [Post(APIEndpoints.FinanceReport.CreateDaily)]
    public Task<Result<FinanceReportDTO>> CreateDailyReport([Body] CreateDailyReportCommand command, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.FinanceReport.CreatePeriod)]
    public Task<Result<FinanceReportDTO>> CreatePeriodReport([Body] CreatePeriodReportCommand command, CancellationToken cancellationToken = default);
    #endregion

    #region FinanceOperationTypes
    [Get(APIEndpoints.FinanceOperationType.GetAllOfUser)]
    public Task<Result<List<FinanceOperationTypeDTO>>> GetAllUserFinanceOperationTypesAsync(Guid userId, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.FinanceOperationType.GetAll)]
    public Task<Result<List<FinanceOperationTypeDTO>>> GetAllFinanceOperationTypesAsync(Guid walletId, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.FinanceOperationType.Get)]
    public Task<Result<FinanceOperationTypeDTO>> GetFinanceOperationTypeAsync(Guid id, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.FinanceOperationType.Create)]
    public Task<Result<FinanceOperationTypeDTO>> AddFinanceOperationTypeAsync([Body] AddFinanceOperationTypeCommand command, CancellationToken cancellationToken = default);

    [Put(APIEndpoints.FinanceOperationType.Update)]
    public Task<Result<FinanceOperationTypeDTO>> UpdateFinanceOperationTypeAsync([Body] UpdateFinanceOperationTypeCommand command, CancellationToken cancellationToken = default);

    [Delete(APIEndpoints.FinanceOperationType.Delete)]
    public Task<Result> DeleteFinanceOperationTypeAsync(Guid id, CancellationToken cancellationToken = default);
    #endregion

    #region FinanceOperations
    [Get(APIEndpoints.FinanceOperation.GetAllByWallet)]
    public Task<Result<List<FinanceOperationDTO>>> GetAllOfWalletAsync(
        Guid walletId,
        [Query] int index = 0,
        [Query] int count = 0, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.FinanceOperation.GetAllByType)]
    public Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationsOfTypeAsync(
        Guid typeId,
        [Query] int index = 0,
        [Query] int count = 0, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.FinanceOperation.GetOperation)]
    public Task<Result<FinanceOperationDTO>> GetFinanceOperationAsync(Guid id, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.FinanceOperation.Create)]
    public Task<Result<FinanceOperationDTO>> AddFinanceOperationAsync([Body] AddFinanceOperationCommand command, CancellationToken cancellationToken = default);

    [Put(APIEndpoints.FinanceOperation.Update)]
    public Task<Result<FinanceOperationDTO>> UpdateFinanceOperationAsync([Body] UpdateFinanceOperationCommand command, CancellationToken cancellationToken = default);

    [Delete(APIEndpoints.FinanceOperation.DeleteOperation)]
    public Task<Result> DeleteFinanceOperationAsync(Guid id, CancellationToken cancellationToken = default);
    #endregion
}
