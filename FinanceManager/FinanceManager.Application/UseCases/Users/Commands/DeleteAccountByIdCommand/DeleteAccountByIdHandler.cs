using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Accounts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Users.Commands.DeleteAccountByIdCommand;

public class DeleteAccountByIdHandler : BaseRequestHandler, IRequestHandler<DeleteAccountByIdCommand, BaseResponse<bool>>
{
    private readonly IAccountService _accountService;

    public DeleteAccountByIdHandler(IAccountService accountService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(mapper, logger)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public Task<BaseResponse<bool>> Handle(DeleteAccountByIdCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            CheckIsUserResourceOwnerOrAdmin(request, idSelector: r => r.Id);

            _accountService.DeleteAccountWithId(request.Id);

            response.MakeAsSuccess("Delete succeed!");
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return Task.FromResult(response);
    }
}
