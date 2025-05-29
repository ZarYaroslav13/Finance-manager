using System.Globalization;
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
using FinanceManager.Domain.API;
using FinanceManager.Domain.Wrapper;
using Microsoft.Extensions.Options;

namespace FinanceManager.Web.Services.APIHttpClient;

public class FinanceManagerApiHttpClient : IFinanceManagerApiHttpClient
{
    private readonly HttpClient _httpClient;

    public FinanceManagerApiHttpClient(HttpClient httpClient, IOptions<APIOptions> options)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        _httpClient.DefaultRequestHeaders.AcceptLanguage.Clear();
        _httpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd(CultureInfo.DefaultThreadCurrentCulture?.TwoLetterISOLanguageName);
        _httpClient.BaseAddress = new(options.Value.BaseAddress);
    }

    #region Tokens
    public Task<Result<TokenDTO>> GetTokenAsync(GetTokenCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result<TokenDTO>> RefreshTokenAsync(RefreshTokenCommand command)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Users
    public Task<PaginatedResult<UserDTO>> GetAllUsersAsync(GetAllUsersQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<Result<UserDTO>> GetUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Wrapper.IResult> ConfirmEmailAsync(ConfirmEmailQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Wrapper.IResult> RegisterUserAsync(RegisterCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Wrapper.IResult> ForgotPasswordAsync(ForgotPasswordCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Wrapper.IResult> ResetPasswordAsync(ResetPasswordCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Wrapper.IResult> DeleteUserdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Accounts
    public Task<Domain.Wrapper.IResult> UpdateAccountAsync(UpdateAccountCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Wrapper.IResult> ChangeAccountPasswordAsync(ChangeUserPasswordCommand command)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Wallets
    public Task<Result<List<WalletDTO>>> GetWalletsAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<WalletDTO>> GetWalletAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<WalletDTO>> CreateWallet(CreateWalletCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result<WalletDTO>> UpdateWallet(UpdateWalletCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Wrapper.IResult> DeleteWallet(Guid id)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Reports
    public Task<Result<FinanceReportDTO>> CreateDailyReport(CreateDailyReportCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result<FinanceReportDTO>> CreatePeriodReport(CreatePeriodReportCommand command)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region FinanceOperationTypes
    public Task<Result<List<FinanceOperationTypeDTO>>> GetAllFinanceOperationTypesAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<FinanceOperationTypeDTO>> GetFinanceOperationTypeAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<FinanceOperationTypeDTO>> AddFinanceOperationTypeAsync(AddFinanceOperationTypeCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result<FinanceOperationTypeDTO>> UpdateFinanceOperationTypeAsync(UpdateFinanceOperationTypeCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Wrapper.IResult> DeleteFinanceOperationTypeAsync(Guid id)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region FinanceOperations
    public Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationsOfWalletAsync(GetAllOperationsOfWalletQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<Result<List<FinanceOperationDTO>>> GetAllFinanceOperationsOfTypeAsync(GetAllOperationsOfTypeQuery query)
    {
        throw new NotImplementedException();
    }

    public Task<Result<FinanceOperationDTO>> GetFinanceOperationAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Result<FinanceOperationDTO>> AddFinanceOperationAsync(AddFinanceOperationTypeCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result<FinanceOperationDTO>> UpdateFinanceOperationAsync(UpdateFinanceOperationTypeCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Wrapper.IResult> DeleteFinanceOperationAsync(Guid id)
    {
        throw new NotImplementedException();
    }
    #endregion
}
