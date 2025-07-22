using AutoMapper;
using FinanceManager.Domain.UseCases.Preferences.Command.UpdateUserPreferencesCommand;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.UseCases.Commons.Mapping;

public class PreferencesProfile : Profile
{
    public PreferencesProfile()
    {
        CreateMap<UpdateUserPreferencesCommand, UserPreference>();
    }
}
