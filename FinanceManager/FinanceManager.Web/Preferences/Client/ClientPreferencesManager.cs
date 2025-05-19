using Blazored.LocalStorage;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Settings;
using FinanceManager.Web.Shared.Constants.Storage;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace FinanceManager.Web.Preferences.Client;

public class ClientPreferencesManager : IPreferencesManager
{
    private readonly ILocalStorageService _localStorageService;
    private readonly IStringLocalizer<ClientPreferencesManager> _localizer;

    public ClientPreferencesManager(
        ILocalStorageService localStorageService,
        IStringLocalizer<ClientPreferencesManager> localizer)
    {
        _localStorageService = localStorageService;
        _localizer = localizer;
    }

    public async Task<bool> ToggleDarkModeAsync()
    {
        var preferences = await GetPreference() as ClientPreferences;
        if (preferences != null)
        {
            preferences.IsDarkMode = !preferences.IsDarkMode;
            await SetPreference(preferences);
            return !preferences.IsDarkMode;
        }

        return false;
    }

    public async Task<bool> ToggleLayoutDirection()
    {
        var preference = await GetPreference() as ClientPreferences;
        if (preference != null)
        {
            preference.IsRTL = !preference.IsRTL;
            await SetPreference(preference);
            return preference.IsRTL;
        }
        return false;
    }

    public async Task<Shared.Wrapper.IResult> ChangeLanguageAsync(string languageCode)
    {
        var preference = await GetPreference() as ClientPreferences;
        if (preference != null)
        {
            preference.LanguageCode = languageCode;
            await SetPreference(preference);
            return new Result
            {
                Succeeded = true,
                Messages = new List<string> { _localizer["Client Language has been changed"] }
            };
        }

        return new Result
        {
            Succeeded = false,
            Messages = new List<string> { _localizer["Failed to get client preferences"] }
        };
    }

    public async Task<MudTheme> GetCurrentThemeAsync()
    {
        var preference = await GetPreference() as ClientPreferences;
        if (preference != null)
        {
            if (preference.IsDarkMode == true) return FinanceManagerThemes.DarkTheme;
        }
        return FinanceManagerThemes.DefaultTheme;
    }

    public async Task<IPreferences> GetPreference()
    {
        return await _localStorageService.GetItemAsync<ClientPreferences>(StorageConstants.Preferences) ?? new ClientPreferences();
    }

    public async Task SetPreference(IPreferences preference)
    {
        await _localStorageService.SetItemAsync(StorageConstants.Preferences, preference as ClientPreferences);
    }

    public async Task<bool> IsRTL()
    {
        var preference = await GetPreference() as ClientPreferences;
        if (preference != null)
        {
            if (preference.IsDarkMode == true) return false;
        }
        return preference.IsRTL;
    }
}
