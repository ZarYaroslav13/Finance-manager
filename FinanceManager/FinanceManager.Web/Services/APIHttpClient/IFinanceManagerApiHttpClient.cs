using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Base;
using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;
using FinanceManager.Application.UseCases.FinanceOperations.Queries.GetAllOperationsOfTypeQuery;
using FinanceManager.Application.UseCases.FinanceOperations.Queries.GetAllOperationsOfWalletQuery;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.AddFinanceOperationTypeCommand;
using FinanceManager.Application.UseCases.FinanceOperationTypes.Commands.UpdateFinanceOperationTypeCommand;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreateDailyReportCommand;
using FinanceManager.Application.UseCases.FinanceReports.Commands.CreatePeriodReportCommand;
using FinanceManager.Application.UseCases.Tokens.Commands.GetTokenCommand;
using FinanceManager.Application.UseCases.Tokens.Commands.RefreshTokenCommand;
using FinanceManager.Application.UseCases.Users.Commands.ForgotPasswordCommand;
using FinanceManager.Application.UseCases.Users.Commands.RegisterCommand;
using FinanceManager.Application.UseCases.Users.Commands.ResetPasswordCommand;
using FinanceManager.Application.UseCases.Users.Queries.ConfirmEmailQuery;
using FinanceManager.Application.UseCases.Users.Queries.GetAllUsersQuery;
using FinanceManager.Application.UseCases.Wallets.Commands.CreateWalletCommand;
using FinanceManager.Application.UseCases.Wallets.Commands.UpdateWalletCommand;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Web.Services.APIHttpClient;

public interface IFinanceManagerApiHttpClient
{
    #region Tokens
    public Task<Result<TokenDTO>> GetTokenAsync(GetTokenCommand command);

    public Task<Result<TokenDTO>> RefreshTokenAsync(RefreshTokenCommand command);
    #endregion

    #region Users
    public Task<PaginatedResult<UserDTO>> GetAllUsersAsync(GetAllUsersQuery query);

    public Task<Result<UserDTO>> GetUserAsync(Guid id);

    public Task<Domain.Wrapper.IResult> ConfirmEmailAsync(ConfirmEmailQuery query);

    public Task<Domain.Wrapper.IResult> RegisterUserAsync(RegisterCommand command);

    public Task<Domain.Wrapper.IResult> ForgotPasswordAsync(ForgotPasswordCommand command);

    public Task<Domain.Wrapper.IResult> ResetPasswordAsync(ResetPasswordCommand command);

    public Task<Domain.Wrapper.IResult> DeleteUserdAsync(Guid id);
    #endregion

    #region Accounts
    public Task<Domain.Wrapper.IResult> UpdateAccountAsync(UpdateAccountCommand command);

    public Task<Domain.Wrapper.IResult> ChangeAccountPasswordAsync(ChangeUserPasswordCommand command);
    #endregion

    #region Wallets
    public Task<Result<List<WalletDTO>>> GetWalletsAsync(Guid userId);

    public Task<Result<WalletDTO>> GetWalletAsync(Guid id);

    public Task<Result<WalletDTO>> CreateWallet(CreateWalletCommand command);

    public Task<Result<WalletDTO>> UpdateWallet(UpdateWalletCommand command);

    public Task<Domain.Wrapper.IResult> DeleteWallet(Guid id);
    #endregion

    #region Reports
    public Task<Result<FinanceReportDTO>> CreateDailyReport(CreateDailyReportCommand command);

    public Task<Result<FinanceReportDTO>> CreatePeriodReport(CreatePeriodReportCommand command);
    #endregion

    #region FinanceOperationTypes
    public Task<Result<List<FinanceOperationTypeDTO>>> GetAllFinanceOperationTypesAsync(Guid userId);

    public Task<Result<FinanceOperationTypeDTO>> GetFinanceOperationTypeAsync(Guid userId);

    public Task<Result<FinanceOperationTypeDTO>> AddFinanceOperationTypeAsync(AddFinanceOperationTypeCommand command);

    public Task<Result<FinanceOperationTypeDTO>> UpdateFinanceOperationTypeAsync(UpdateFinanceOperationTypeCommand command);

    public Task<Domain.Wrapper.IResult> DeleteFinanceOperationTypeAsync(Guid id);
    #endregion

    #region FinanceOperations
    public Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationsOfWalletAsync(GetAllOperationsOfWalletQuery query);

    public Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationsOfTypeAsync(GetAllOperationsOfTypeQuery query);

    public Task<Result<FinanceOperationDTO>> GetFinanceOperationAsync(Guid userId);

    public Task<Result<FinanceOperationDTO>> AddFinanceOperationAsync(AddFinanceOperationTypeCommand command);

    public Task<Result<FinanceOperationDTO>> UpdateFinanceOperationAsync(UpdateFinanceOperationTypeCommand command);

    public Task<Domain.Wrapper.IResult> DeleteFinanceOperationAsync(Guid id);
    #endregion
}
