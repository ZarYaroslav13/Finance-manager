using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.Accounts;
using FinanceManager.Domain.Services.Admins;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Accounts.Commands.UpdateCommand;

public class UpdateAccountCommandHandler : BaseHandler, IRequestHandler<UpdateAccountCommand, AccountDTO>
{
    private readonly IAccountService _accountService;

    public UpdateAccountCommandHandler(IAccountService accountService, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public async Task<AccountDTO> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
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
                    await _accountService.UpdateAccountAsync(
                        _mapper.Map<AccountModel>(request)));

            _logger.LogInformation("Account with id: {Id} updated successfully by user with id: {UserId} and role {UserRole}", response.Id, userId, userRole);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }

        return response;
    }
}
