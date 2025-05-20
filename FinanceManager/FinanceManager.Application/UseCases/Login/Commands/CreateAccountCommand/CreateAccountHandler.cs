using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Accounts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Login.Commands.CreateAccountCommand;

public class CreateAccountHandler : BaseRequestHandler, IRequestHandler<CreateAccountCommand, BaseResponse<bool>>
{
    private readonly IAccountService _accountService;

    public CreateAccountHandler(IAccountService accountService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(mapper, logger)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public async Task<BaseResponse<bool>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var newAccount = _mapper.Map<AccountDTO>(
                       await _accountService.AddAccountAsync(
                          _mapper.Map<AccountModel>(request)));

            if (newAccount != null)
            {
                response.Success = true;
                response.Data = true;
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}
