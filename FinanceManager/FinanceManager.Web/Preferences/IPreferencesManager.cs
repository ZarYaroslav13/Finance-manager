using MudBlazor;

namespace FinanceManager.Web.Preferences;

public interface IPreferencesManager
{
    Task<bool> ToggleLayoutDirection();

    Task<bool> ToggleDarkModeAsync();

    Task<Shared.Wrapper.IResult> ChangeLanguageAsync(string languageCode);

    Task SetPreference(IPreferences preference);

    Task<IPreferences> GetPreference();

    Task<MudTheme> GetCurrentThemeAsync();

    Task<bool> IsRTL();
}
