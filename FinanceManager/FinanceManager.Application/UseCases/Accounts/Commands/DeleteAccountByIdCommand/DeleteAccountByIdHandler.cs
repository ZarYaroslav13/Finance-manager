using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Accounts;
using FinanceManager.Domain.Services.Admins;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Accounts.Commands.DeleteAccountByIdCommand;

public class DeleteAccountByIdHandler : BaseHandler, IRequestHandler<DeleteAccountByIdCommand>
{
    private readonly IAccountService _accountService;

    public DeleteAccountByIdHandler(IAccountService accountService, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public Task Handle(DeleteAccountByIdCommand request, CancellationToken cancellationToken)
    {
        int userId = GetUserId(request.Identity);
        string userRole = GetUserRole(request.Identity);
        string logStringInformation = "DeleteById called by user to remove account with Id: {Id}";

        if (userRole == AdminService.AdminRole)
            logStringInformation = "DeleteById called by admin to remove account with Id: {Id}";

        _logger.LogInformation(logStringInformation, request.Id);

        if (userRole != AdminService.AdminRole && request.Id != userId)
        {
            _logger.LogWarning($"Unauthorized access attempt to update account with Id: {request.Id} by user with id: {userId} and role {userRole}");
            throw new UnauthorizedAccessException($"Access denied");
        }

        _accountService.DeleteAccountWithId(request.Id);

        _logger.LogInformation("User with role {Role} and Id {IdUser} successfully deleted account with Id: {Id} successfully", userRole, userId, request.Id);

        return Task.CompletedTask;
    }
}
