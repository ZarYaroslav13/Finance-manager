using Blazored.LocalStorage;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Extentions;
using FinanceManager.Web.Services.APIServices.APIHttpClient;
using FinanceManager.Web.Settings;
using FinanceManager.Web.Shared.Constants.Storage;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using MudBlazor;
using System.Globalization;

namespace FinanceManager.Web.Preferences.Client;

public class ClientPreferencesManager : IPreferencesManager
{
    private readonly IFinanceManagerApiHttpClient _apiClient;
    private readonly ILocalStorageService _localStorageService;
    private readonly IStringLocalizer<ClientPreferencesManager> _localizer;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IJSRuntime _jSRuntime;

    public ClientPreferencesManager(
        ILocalStorageService localStorageService,
        IStringLocalizer<ClientPreferencesManager> localizer,
        IHttpContextAccessor contextAccessor,
        IJSRuntime jSRuntime,
        IFinanceManagerApiHttpClient apiClient)
    {
        _localStorageService = localStorageService;
        _localizer = localizer;
        _contextAccessor = contextAccessor;
        _jSRuntime = jSRuntime;
        _apiClient = apiClient;
    }

    public async Task<bool> ToggleDarkModeAsync()
    {
        var preferences = await GetPreference() as UserPreferencesDTO;
        if (preferences != null)
        {
            preferences.DarkMode = !preferences.DarkMode;
            await SetPreference(preferences);
            return !preferences.DarkMode;
        }

        return false;
    }

    public async Task<bool> ToggleLayoutDirection()
    {
        var preference = await GetPreference() as UserPreferencesDTO;
        if (preference != null)
        {
            preference.RightToLeft = !preference.RightToLeft;
            await SetPreference(preference);
            return preference.RightToLeft;
        }
        return false;
    }

    public async Task<Domain.Wrapper.IResult> ChangeLanguageAsync(string languageCode)
    {
        var preference = await GetPreference() as UserPreferencesDTO;
        if (preference != null)
        {
            var cultureInfo = new CultureInfo(languageCode);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


            await _jSRuntime.InvokeVoidAsync("setCultureCookie", languageCode);

            preference.LanguageCode = languageCode;
            await SetPreference(preference);
            return Result.Success(_localizer["Client Language has been changed"]);
        }

        return Result.Fail(_localizer["Failed to get client preferences"]);
    }

    public async Task<MudTheme> GetCurrentThemeAsync()
    {
        var preference = await GetPreference() as UserPreferencesDTO;
        if (preference != null)
        {
            if (preference.DarkMode == true) return FinanceManagerThemes.DarkTheme;
        }
        return FinanceManagerThemes.DefaultTheme;
    }

    public async Task<UserPreferencesDTO> GetPreference()
    {
        var preferences = await _localStorageService.GetItemAsync<UserPreferencesDTO>(StorageConstants.Preferences) ?? new UserPreferencesDTO();

        if (preferences == null)
        {
            var storedPreferences = await _apiClient.GetUserPreferences(new Guid(_contextAccessor.HttpContext.User.GetUserId()));

            if (storedPreferences.Succeeded)
            {
                preferences = storedPreferences.Data;
                await _localStorageService.SetItemAsync(StorageConstants.Preferences, preferences);
            }
        }

        return preferences;
    }

    public async Task SetPreference(UserPreferencesDTO preference)
    {
        await _localStorageService.SetItemAsync(StorageConstants.Preferences, preference);
        await _apiClient.UpdateUserPreferences(new()
        {
            UserId = preference.UserId,
            DarkMode = preference.DarkMode,
            LanguageCode = preference.LanguageCode,
            RightToLeft = preference.RightToLeft
        });
    }

    public async Task<bool> IsRTL()
    {
        var preference = await GetPreference() as UserPreferencesDTO;
        if (preference != null)
        {
            if (preference.DarkMode == true) return false;
        }
        return preference.RightToLeft;
    }
}
