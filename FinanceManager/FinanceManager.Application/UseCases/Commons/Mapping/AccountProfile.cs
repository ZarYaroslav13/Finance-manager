using AutoMapper;
using FinanceManager.Application.UseCases.Users.Commands.UpdateCommand;
using FinanceManager.Domain.Models;

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
