using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Accounts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;

public class UpdateAccountCommandHandler : BaseRequestHandler, IRequestHandler<UpdateAccountCommand, BaseResponse<AccountDTO>>
{
    private readonly IAccountService _accountService;

    public UpdateAccountCommandHandler(IAccountService accountService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(mapper, logger)
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
            CheckIsUserResourceOwnerOrAdmin(request, idSelector: r => r.Id);

            response.Data = _mapper.Map<AccountDTO>(
                    await _accountService.UpdateAccountAsync(
                        _mapper.Map<AccountModel>(request)));

            response.MakeAsSuccess("Updating success!");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }

        return response;
    }
}
