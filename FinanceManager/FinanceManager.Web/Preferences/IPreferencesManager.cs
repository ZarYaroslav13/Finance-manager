namespace FinanceManager.Web.Preferences;

public interface IPreferencesManager
{
    Task SetPreference(IPreferences preference);

    Task<IPreferences> GetPreference();
}
