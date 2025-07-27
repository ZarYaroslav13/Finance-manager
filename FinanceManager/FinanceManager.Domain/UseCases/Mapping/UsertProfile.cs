using AutoMapper;
using FinanceManager.Domain.UseCases.Commons.Accounts.Commands.UpdateAccountCommand;


//using FinanceManager.Domain.UseCases.Users.Commands.RegisterCommand;
using FinanceManager.Infrastructure.Models.Authorization;

namespace FinanceManager.Domain.UseCases.Mapping;

public class UsertProfile : Profile
{
    public UsertProfile()
    {
        //CreateMap<UserDTO, UpdateAccountCommand>();

        CreateMap<UpdateAccountCommand, FinanceManagerUser>().BeforeMap((src, dest) =>
        {
            src.Email = src.Email.Trim();
            src.FirstName = src.FirstName.Trim();
            src.LastName = src.LastName.Trim();
        });

        //CreateMap<RegisterCommand, UserModel>().BeforeMap((src, dest) =>
        //{
        //    src.Email = src.Email.Trim();
        //    src.FirstName = src.FirstName.Trim();
        //    src.LastName = src.LastName.Trim();
        //}); ;
    }
}
