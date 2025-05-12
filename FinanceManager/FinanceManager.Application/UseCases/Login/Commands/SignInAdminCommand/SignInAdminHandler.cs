using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.Security.Jwt;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Accounts;
using FinanceManager.Domain.Services.Admins;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Login.Commands.SignInAdminCommand;

public class SignInAdminHandler : BaseRequestHandler, IRequestHandler<SignInAdminCommand, BaseResponse<AutenticationTokenDTO>>
{
    private readonly IAccountService _accountService;
    private readonly IAdminService _adminService;
    private readonly ITokenManager _tokenManager;

    public SignInAdminHandler(
        IAdminService adminService,
        IAccountService accountService,
        ITokenManager tokenManager,
        IMapper mapper,
        ILogger<BaseRequestHandler> logger) : base(mapper, logger)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        _tokenManager = tokenManager ?? throw new ArgumentNullException(nameof(tokenManager));
    }

    public async Task<BaseResponse<AutenticationTokenDTO>> Handle(SignInAdminCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<AutenticationTokenDTO>();

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

    private async Task<AutenticationTokenDTO> TryLogin(SignInAdminCommand request)
    {
        var identity = await _tokenManager.GetAdminIdentityAsync(request.Email, request.Password);
        if (identity == null)
        {
            _logger.LogWarning("Sign in failed for email: {Email}. Invalid credentials.", request.Email);
            throw new UnauthorizedAccessException("Invalid email or username");
        }

        AutenticationTokenDTO token = new()
        {
            JWTToken = _tokenManager.CreateToken(identity),
            RefreshToken = ""
        };

        return token;
    }
}
