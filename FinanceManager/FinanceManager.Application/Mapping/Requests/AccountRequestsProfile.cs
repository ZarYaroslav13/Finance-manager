using AutoMapper;
using FinanceManager.Application.Models.Requests.Account.Commands;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;

namespace FinanceManager.Application.Mapping.Requests;

public class AccountRequestsProfile : Profile
{
    public AccountRequestsProfile()
    {
        CreateMap<ChangeUserPasswordRequest, ChangeUserPasswordCommand>();

        CreateMap<UpdateAccountRequest, UpdateAccountCommand>();
    }
}
