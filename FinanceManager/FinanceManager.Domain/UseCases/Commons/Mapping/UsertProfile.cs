using AutoMapper;
//using FinanceManager.Domain.UseCases.Users.Commands.RegisterCommand;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Infrastructure.Models.Authorization;

namespace FinanceManager.Domain.UseCases.Commons.Mapping;

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
