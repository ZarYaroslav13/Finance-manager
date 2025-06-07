using FinanceManager.Application.Models;
using MudBlazor;

namespace FinanceManager.Web.Preferences;

public interface IPreferencesManager
{
    Task<bool> ToggleLayoutDirection();

    Task<bool> ToggleDarkModeAsync();

    Task<Domain.Wrapper.IResult> ChangeLanguageAsync(string languageCode);

    Task SetPreference(UserPreferencesDTO preference);

    Task<UserPreferencesDTO> GetPreference();

    Task<MudTheme> GetCurrentThemeAsync();

    Task<bool> IsRTL();
}
