using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Accounts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Accounts.Commands.UpdatePasswordAccountCommand;

public class UpdatePasswordAccountCommandHandler : BaseHandler, IRequestHandler<UpdatePasswordAccountCommand, BaseResponse<AccountDTO>>
{
    private readonly IAccountService _accountService;

    public UpdatePasswordAccountCommandHandler(IAccountService accountService, IMapper mapper, ILogger<BaseHandler> logger) : base(mapper, logger)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public async Task<BaseResponse<AccountDTO>> Handle(UpdatePasswordAccountCommand request, CancellationToken cancellationToken)
    {
        BaseResponse<AccountDTO> response = new();

        try
        {
            CheckIsUserResourceOwnerOrAdmin(request, idSelector: r => r.Id);

            response.Data = _mapper.Map<AccountDTO>(
                    await _accountService.UpdateAccountPasswordAsync(request.Id, request.OldPassword, request.NewPassword));

            response.MakeAsSuccess("Updating success!");
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            response.Message = e.Message;
        }

        return response;
    }
}
