namespace FinanceManager.Web.Preferences;

public interface IPreferencesManager
{
    Task<bool> ToggleDarkModeAsync();

    Task<Shared.Wrapper.IResult> ChangeLanguageAsync(string languageCode);

    Task SetPreference(IPreferences preference);

    Task<IPreferences> GetPreference();
}
