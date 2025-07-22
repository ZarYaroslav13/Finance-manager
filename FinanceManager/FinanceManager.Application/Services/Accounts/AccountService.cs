using AutoMapper;
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

    public async Task<IResult> ChangePasswordAsync(ChangeUserPasswordCommand command)
    {

        var result = await _mediator.Send(command);

        return result;
    }

    public async Task<IResult> UpdateAccountAsync(UpdateAccountCommand command)
    {
        var result = await _mediator.Send(command);

        return result;
    }
}
