using AutoMapper;
using FinanceManager.Application.Models.Requests.UserPreferences.Commands;
using FinanceManager.Domain.UseCases.Preferences.Command.UpdateUserPreferencesCommand;

namespace FinanceManager.Application.Mapping.Requests;

public class UserPreferencesRequestsProfile : Profile
{
    public UserPreferencesRequestsProfile()
    {
        CreateMap<UpdateUserPreferencesRequest, UpdateUserPreferencesCommand>();
    }
}
