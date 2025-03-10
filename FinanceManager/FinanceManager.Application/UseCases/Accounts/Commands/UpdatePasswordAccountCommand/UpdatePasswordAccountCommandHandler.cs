using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Base;
using FinanceManager.Domain.Services.Accounts;
using FinanceManager.Domain.Services.Admins;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Accounts.Commands.UpdatePasswordAccountCommand;

public class UpdatePasswordAccountCommandHandler : BaseHandler, IRequestHandler<UpdatePasswordAccountCommand, AccountDTO>
{
    private readonly IAccountService _accountService;

    public UpdatePasswordAccountCommandHandler(IAccountService accountService, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public async Task<AccountDTO> Handle(UpdatePasswordAccountCommand request, CancellationToken cancellationToken)
    {
        AccountDTO response = new();
        int userId = GetUserId(request.Identity);
        string userRole = GetUserRole(request.Identity);

        try
        {
            _logger.LogInformation("UpdateAsync called to update account with Id: {Id} by user with id: {UserId} and role {UserRole}", request.Id, userId, userRole);

            if (userRole != AdminService.AdminRole && request.Id != userId)
            {
                _logger.LogWarning($"Unauthorized access attempt to update account with Id: {request.Id} by user with id: {userId} and role {userRole}");
                throw new UnauthorizedAccessException($"Access denied");
            }

            response = _mapper.Map<AccountDTO>(
                    await _accountService.UpdateAccountPasswordAsync(request.Id, request.OldPassword, request.NewPassword));

            _logger.LogInformation("Account password with id: {Id} updated successfully by user with id: {UserId} and role {UserRole}", response.Id, userId, userRole);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }

        return response;
    }
}
