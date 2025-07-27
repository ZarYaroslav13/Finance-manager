using AutoMapper;
using FinanceManager.Application.Models.Requests.Account.Commands;
using FinanceManager.Domain.UseCases.Commons.Accounts.Commands.ChangeUserPasswordCommand;
using FinanceManager.Domain.UseCases.Commons.Accounts.Commands.UpdateAccountCommand;

namespace FinanceManager.Application.Mapping.Requests;

public class AccountRequestsProfile : Profile
{
    public AccountRequestsProfile()
    {
        CreateMap<ChangeAccountPasswordRequest, ChangeUserPasswordCommand>();

        CreateMap<UpdateAccountRequest, UpdateAccountCommand>();
    }
}
