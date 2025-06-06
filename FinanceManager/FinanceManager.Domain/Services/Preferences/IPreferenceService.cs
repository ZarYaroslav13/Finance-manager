using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Repository;

namespace FinanceManager.Domain.Services.Preferences;

public interface IPreferenceService
{
    public Task<IResult<UserPreferencesModel>> GetPreferencesOfUser(Guid userId);

    public Task<IResult<UserPreferencesModel>> AddPreferences(UserPreferencesModel preferences);

    public Task<IResult> UpdatePrefernces(UserPreferencesModel preferences);
}
