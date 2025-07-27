using AutoMapper;
using FinanceManager.Application.Models.Requests.Account.Commands;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.Services.Accounts;

public class AccountService : BaseService, IAccountService
{
    public AccountService(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task<IResult> UpdateAccountAsync(UpdateAccountRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<UpdateAccountCommand>(request));

        return result;
    }

    public async Task<IResult> ChangePasswordAsync(ChangeUserPasswordRequest request)
    {

        var result = await _mediator.Send(_mapper.Map<ChangeUserPasswordCommand>(request));

        return result;
    }
}
