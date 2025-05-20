using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Accounts;
using FinanceManager.Domain.Services.Token;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Login.Commands.SignInAdminCommand;

public class SignInAdminHandler : BaseRequestHandler, IRequestHandler<SignInAdminCommand, BaseResponse<TokenDTO>>
{
    private readonly IAccountService _accountService;
    private readonly IAdminService _adminService;
    private readonly ITokenService _tokenManager;

    public SignInAdminHandler(
        IAdminService adminService,
        IAccountService accountService,
        ITokenService tokenManager,
        IMapper mapper,
        ILogger<BaseRequestHandler> logger) : base(mapper, logger)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        _tokenManager = tokenManager ?? throw new ArgumentNullException(nameof(tokenManager));
    }

    public async Task<BaseResponse<TokenDTO>> Handle(SignInAdminCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<TokenDTO>();

        try
        {
            response.Data = await TryLogin(request);

            response.MakeAsSuccess("Logged successfully");
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }

    private async Task<TokenDTO> TryLogin(SignInAdminCommand request)
    {
        var identity = await _tokenManager.GetAdminIdentityAsync(request.Email, request.Password);
        if (identity == null)
        {
            _logger.LogWarning("Sign in failed for email: {Email}. Invalid credentials.", request.Email);
            throw new UnauthorizedAccessException("Invalid email or username");
        }

        TokenDTO token = new()
        {
            JWTToken = _tokenManager.GetRefreshToken(identity),
            RefreshToken = ""
        };

        return token;
    }
}
