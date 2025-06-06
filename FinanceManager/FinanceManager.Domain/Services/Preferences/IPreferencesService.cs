using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;

namespace FinanceManager.Domain.Services.Preferences;

public interface IPreferencesService
{
    public Task<Result<UserPreferencesModel>> GetPreferencesOfUserAsync(Guid userId);

    public Task<IResult> UpdatePreferncesAsync(UserPreferencesModel preferences);
}
