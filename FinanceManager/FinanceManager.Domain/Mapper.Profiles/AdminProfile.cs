using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.Mapper.Profiles;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<Admin, AdminModel>().ReverseMap();
    }
}
