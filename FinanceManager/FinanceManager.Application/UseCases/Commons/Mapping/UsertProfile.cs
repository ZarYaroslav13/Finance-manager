using AutoMapper;
using FinanceManager.Application.Models.Base;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;

namespace FinanceManager.Application.UseCases.Commons.Mapping;

public class UsertProfile : Profile
{
    public UsertProfile()
    {
        CreateMap<UserDTO, UpdateAccountCommand>();

        CreateMap<UpdateAccountCommand, UserModel>().BeforeMap((src, dest) =>
        {
            src.Email = src.Email.Trim();
            src.FirstName = src.FirstName.Trim();
            src.LastName = src.LastName.Trim();
        });

        CreateMap<RegisterCommand, UserModel>().BeforeMap((src, dest) =>
        {
            src.Email = src.Email.Trim();
            src.FirstName = src.FirstName.Trim();
            src.LastName = src.LastName.Trim();
        }); ;
    }
}
