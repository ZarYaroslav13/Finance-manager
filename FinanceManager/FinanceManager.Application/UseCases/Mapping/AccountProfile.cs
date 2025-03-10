using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Accounts.Commands.UpdateCommand;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.UseCases.Mapping;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<UpdateAccountCommand, AccountModel>().BeforeMap((src, dest) =>
        {
            src.Email = src.Email.Trim();
            src.FirstName = src.FirstName.Trim();
            src.LastName = src.LastName.Trim();
        });

        CreateMap<AccountDTO, UpdateAccountCommand>();


    }
}
