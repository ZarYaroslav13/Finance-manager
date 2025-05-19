namespace FinanceManager.Domain.Services.Users;

public interface IUserService
{
    Task<List<UserResponse>> GetAllAsync();

    Task<UserResponse> GetAsync(string userId);

    Task<IResult> RegisterAsync(RegisterRequest request, string origin);

    Task<IResult<UserRolesResponse>> GetRolesAsync(string id);

    Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest request);

    Task<IResult<string>> ConfirmEmailAsync(string userId, string code);

    Task<IResult> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);

    Task<IResult> ResetPasswordAsync(ResetPasswordRequest request);

    Task<string> ExportToExcelAsync(string searchString = "");
}
}
