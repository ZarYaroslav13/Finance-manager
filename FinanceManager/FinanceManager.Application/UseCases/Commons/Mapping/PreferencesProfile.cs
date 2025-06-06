using AutoMapper;
using FinanceManager.Application.UseCases.Preferences.Command.UpdateUserPreferencesCommand;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.UseCases.Commons.Mapping;

public class PreferencesProfile : Profile
{
    public PreferencesProfile()
    {
        CreateMap<UpdateUserPreferencesCommand, UserPreferencesModel>();
    }
}
