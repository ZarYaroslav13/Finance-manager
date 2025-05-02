namespace FinanceManager.Web.Preferences;

public interface IPreferencesManager
{
    Task SetPreference<T>(T preference) where T : class;

    Task<T> GetPreference<T>() where T : class;
}
