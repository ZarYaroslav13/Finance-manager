using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.Mapping;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<AdminModel, AdminDTO>().ReverseMap();
    }
}
