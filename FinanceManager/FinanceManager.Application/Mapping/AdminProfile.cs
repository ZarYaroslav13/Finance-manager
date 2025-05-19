using AutoMapper;
using FinanceManager.Application.Models;

namespace FinanceManager.Application.Mapping;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<AdminModel, AdminDTO>().ReverseMap();
    }
}
