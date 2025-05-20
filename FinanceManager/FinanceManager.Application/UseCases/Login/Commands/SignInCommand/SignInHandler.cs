using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Accounts;
using FinanceManager.Domain.Services.Token;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Login.Commands.SignInCommand;

public class SignInHandler : BaseRequestHandler, IRequestHandler<SignInCommand, BaseResponse<TokenDTO>>
{
    private readonly IAccountService _accountService;
    private readonly IAdminService _adminService;
    private readonly ITokenService _tokenManager;

    public SignInHandler(
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

    public async Task<BaseResponse<TokenDTO>> Handle(SignInCommand request, CancellationToken cancellationToken)
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

    private async Task<TokenDTO> TryLogin(SignInCommand request)
    {
        var identity = await _tokenManager.LoginAsync(request.Email, request.Password);
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
