using AutoMapper;
using FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Application.UseCases.Accounts.Commands.UpdateAccountCommand;

namespace FinanceManager.Application.UseCases.Commons.Mapping;

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
    }
}
