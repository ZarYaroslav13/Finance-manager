using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Base;
using FinanceManager.Application.Models.Requests.Account.Commands;
using FinanceManager.Application.Models.Requests.FinanceOperations.Commands;
using FinanceManager.Application.Models.Requests.FinanceOperations.Queries;
using FinanceManager.Application.Models.Requests.FinanceOperationTypes.Commands;
using FinanceManager.Application.Models.Requests.FinanceReports.Commands;
using FinanceManager.Application.Models.Requests.Tokens.Commands;
using FinanceManager.Application.Models.Requests.UserPreferences.Commands;
using FinanceManager.Application.Models.Requests.Users.Commands;
using FinanceManager.Application.Models.Requests.Users.Queries;
using FinanceManager.Application.Models.Requests.Wallets.Commands;
using FinanceManager.Domain.API;
using FinanceManager.Domain.Wrapper;
using Refit;

namespace FinanceManager.Web.Services.APIServices.APIHttpClient;

public interface IFinanceManagerApiHttpClient
{
    #region Tokens
    [Post(APIEndpoints.Token.Get)]
    public Task<Result<TokenDTO>> GetTokenAsync([Body] GetTokenRequest request, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.Token.Refresh)]
    public Task<Result<TokenDTO>> RefreshTokenAsync([Body] RefreshTokenRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region Users

    [Get(APIEndpoints.Users.GetAll)]
    public Task<PaginatedResult<UserDTO>> GetAllUsersAsync([Body] GetAllUsersRequest request, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.Users.GetUser)]
    public Task<Result<UserDTO>> GetUserAsync(Guid id, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.Users.ConfirmEmail)]
    public Task<Result> ConfirmEmailAsync([Query] Guid userId, [Query] string code, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.Users.Register)]
    public Task<Result> RegisterUserAsync([Body] RegisterRequest request, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.Users.ForgotPassword)]
    public Task<Result> ForgotPasswordAsync([Body] ForgotPasswordRequest request, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.Users.ResetPassword)]
    public Task<Result> ResetPasswordAsync([Body] ResetPasswordRequest request, CancellationToken cancellationToken = default);

    [Delete(APIEndpoints.Users.DeleteUser)]
    public Task<Result> DeleteUserdAsync(Guid id, CancellationToken cancellationToken = default);
    #endregion

    #region UserPreferences
    [Get(APIEndpoints.UserPreferences.GetUserPreferences)]
    public Task<Result<UserPreferencesDTO>> GetUserPreferences(Guid id, CancellationToken cancellationToken = default);

    [Put(APIEndpoints.UserPreferences.Update)]
    public Task<Result<UserPreferencesDTO>> UpdateUserPreferences([Body] UpdateUserPreferencesRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region Accounts
    [Put(APIEndpoints.Accounts.Update)]
    public Task<Result> UpdateAccountAsync([Body] UpdateAccountRequest request, CancellationToken cancellationToken = default);

    [Patch(APIEndpoints.Accounts.ChangePassword)]
    public Task<Result> ChangeAccountPasswordAsync([Body] ChangeAccountPasswordRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region Wallets
    [Get(APIEndpoints.Wallets.GetAll)]
    public Task<Result<List<WalletDTO>>> GetWalletsAsync(Guid accountId, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.Wallets.GetWallet)]
    public Task<Result<WalletDTO>> GetWalletAsync(Guid id, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.Wallets.Create)]
    public Task<Result<WalletDTO>> CreateWallet([Body] CreateWalletRequest request, CancellationToken cancellationToken = default);

    [Put(APIEndpoints.Wallets.Update)]
    public Task<Result<WalletDTO>> UpdateWallet([Body] UpdateWalletRequest request, CancellationToken cancellationToken = default);

    [Delete(APIEndpoints.Wallets.DeleteWallet)]
    public Task<Result> DeleteWallet(Guid id, CancellationToken cancellationToken = default);
    #endregion

    #region Reports
    [Post(APIEndpoints.FinanceReport.CreateDaily)]
    public Task<Result<FinanceReportDTO>> CreateDailyReport([Body] CreateDailyReportRequest request, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.FinanceReport.CreatePeriod)]
    public Task<Result<FinanceReportDTO>> CreatePeriodReport([Body] CreatePeriodReportRequest request, CancellationToken cancellationToken = default);
    #endregion

    #region FinanceOperationTypes
    [Get(APIEndpoints.FinanceOperationType.GetAllOfUser)]
    public Task<Result<List<FinanceOperationTypeDTO>>> GetAllUserFinanceOperationTypesAsync(Guid userId, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.FinanceOperationType.GetAll)]
    public Task<Result<List<FinanceOperationTypeDTO>>> GetAllFinanceOperationTypesOfWalletAsync(Guid walletId, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.FinanceOperationType.Get)]
    public Task<Result<FinanceOperationTypeDTO>> GetFinanceOperationTypeAsync(Guid id, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.FinanceOperationType.Create)]
    public Task<Result<FinanceOperationTypeDTO>> AddFinanceOperationTypeAsync([Body] AddFinanceOperationTypeRequest request, CancellationToken cancellationToken = default);

    [Put(APIEndpoints.FinanceOperationType.Update)]
    public Task<Result<FinanceOperationTypeDTO>> UpdateFinanceOperationTypeAsync([Body] UpdateFinanceOperationTypeRequest request, CancellationToken cancellationToken = default);

    [Delete(APIEndpoints.FinanceOperationType.Delete)]
    public Task<Result> DeleteFinanceOperationTypeAsync(Guid id, CancellationToken cancellationToken = default);
    #endregion

    #region FinanceOperations
    [Get(APIEndpoints.FinanceOperation.GetAllByWallet)]
    public Task<Result<List<FinanceOperationDTO>>> GetAllOfWalletAsync([Body] GetAllOperationsOfWalletRequest request, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.FinanceOperation.GetAllByType)]
    public Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationsOfTypeAsync([Body] GetAllOperationsOfTypeRequest request, CancellationToken cancellationToken = default);

    [Get(APIEndpoints.FinanceOperation.GetOperation)]
    public Task<Result<FinanceOperationDTO>> GetFinanceOperationAsync(Guid id, CancellationToken cancellationToken = default);

    [Post(APIEndpoints.FinanceOperation.Create)]
    public Task<Result<FinanceOperationDTO>> AddFinanceOperationAsync([Body] AddFinanceOperationRequest request, CancellationToken cancellationToken = default);

    [Put(APIEndpoints.FinanceOperation.Update)]
    public Task<Result<FinanceOperationDTO>> UpdateFinanceOperationAsync([Body] UpdateFinanceOperationRequest request, CancellationToken cancellationToken = default);

    [Delete(APIEndpoints.FinanceOperation.DeleteOperation)]
    public Task<Result> DeleteFinanceOperationAsync(Guid id, CancellationToken cancellationToken = default);
    #endregion
}
