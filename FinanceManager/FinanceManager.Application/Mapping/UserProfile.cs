using AutoMapper;
using FinanceManager.Application.Models.Base;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserModel, UserDTO>().ReverseMap();
    }
}
