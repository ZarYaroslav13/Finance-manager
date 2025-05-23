using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Infrastructure.Models.Authorization;

namespace FinanceManager.Domain.Mapper.Profiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<FinanceManagerRole, RoleModel>().ReverseMap();
    }
}
