using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Accounts;
using FinanceManager.Domain.Services.Admins;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Accounts.Commands.DeleteAccountByIdCommand;

public class DeleteAccountByIdHandler : BaseHandler, IRequestHandler<DeleteAccountByIdCommand, BaseResponse<bool>>
{
    private readonly IAccountService _accountService;

    public DeleteAccountByIdHandler(IAccountService accountService, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public Task<BaseResponse<bool>> Handle(DeleteAccountByIdCommand request, CancellationToken cancellationToken)
    {
        int userId = request.UserId;
        string userRole = request.UserRole;
        var response = new BaseResponse<bool>();


        try
        {

            if (userRole != AdminService.AdminRole && request.Id != userId)
            {
                _logger.LogWarning($"Unauthorized access attempt to update account with Id: {request.Id} by user with id: {userId} and role {userRole}");
                throw new UnauthorizedAccessException($"Access denied");
            }

            _accountService.DeleteAccountWithId(request.Id);

            if (response.Data)
                response.MakeAsSuccess("Delete succeed!"); ;
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return Task.FromResult(response);
    }
}
