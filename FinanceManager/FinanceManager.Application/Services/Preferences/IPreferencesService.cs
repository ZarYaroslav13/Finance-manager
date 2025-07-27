using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.UserPreferences.Commands;
using FinanceManager.Domain.UseCases.Preferences.Command.UpdateUserPreferencesCommand;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Application.Services.Preferences;

public interface IPreferencesService
{
    public Task<Result<UserPreferencesDTO>> GetPreferencesOfUserAsync(Guid userId);

    public Task<IResult> UpdatePreferncesAsync(UpdateUserPreferencesRequest request);
}
