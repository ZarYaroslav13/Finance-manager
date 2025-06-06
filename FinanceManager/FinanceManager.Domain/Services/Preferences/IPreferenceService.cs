using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Domain.Services.Preferences;

public interface IPreferenceService
{
    public Task<IResult<UserPreferencesModel>> GetPreferencesOfUserAsync(Guid userId);

    public Task<IResult> UpdatePreferncesAsync(UserPreferencesModel preferences);
}
