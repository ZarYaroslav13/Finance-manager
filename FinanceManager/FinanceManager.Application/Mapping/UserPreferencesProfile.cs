using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.Mapping;

public class UserPreferencesProfile : Profile
{
    public UserPreferencesProfile()
    {
        CreateMap<UserPreferencesModel, UserPreferencesDTO>().ReverseMap();
    }
}
