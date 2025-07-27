using AutoMapper;
using FinanceManager.Domain.UseCases.Commons.Preferences.Command.UpdateUserPreferencesCommand;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.UseCases.Mapping;

public class PreferencesProfile : Profile
{
    public PreferencesProfile()
    {
        CreateMap<UpdateUserPreferencesCommand, UserPreference>();
    }
}
