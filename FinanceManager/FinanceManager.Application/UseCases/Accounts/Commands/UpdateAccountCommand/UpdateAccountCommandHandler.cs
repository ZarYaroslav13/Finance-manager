using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.Accounts;
using FinanceManager.Domain.Services.Admins;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Accounts.Commands.UpdateCommand;

public class UpdateAccountCommandHandler : BaseHandler, IRequestHandler<UpdateAccountCommand, BaseResponse<AccountDTO>>
{
    private readonly IAccountService _accountService;

    public UpdateAccountCommandHandler(IAccountService accountService, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public async Task<BaseResponse<AccountDTO>> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        BaseResponse<AccountDTO> response = new();
        int userId = request.UserId;
        string userRole = request.UserRole;

        try
        {
            if (userRole != AdminService.AdminRole && request.Id != userId)
            {
                _logger.LogWarning($"Unauthorized access attempt to update account with Id: {request.Id} by user with id: {userId} and role {userRole}");
                throw new UnauthorizedAccessException($"Access denied");
            }

            response.Data = _mapper.Map<AccountDTO>(
                    await _accountService.UpdateAccountAsync(
                        _mapper.Map<AccountModel>(request)));

            response.ConvertAsSuccessSuccess("Updating success!");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }

        return response;
    }
}
