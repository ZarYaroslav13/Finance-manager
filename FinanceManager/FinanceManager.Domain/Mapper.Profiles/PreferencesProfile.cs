using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.Mapper.Profiles;

public class PreferencesProfile : Profile
{
    public PreferencesProfile()
    {
        CreateMap<UserPreference, UserPreferencesModel>().ReverseMap();
    }
}
