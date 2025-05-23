using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Infrastructure.Models.Authorization;

namespace FinanceManager.Domain.Mapper.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserModel, FinanceManagerUser>().ReverseMap();
    }
}
