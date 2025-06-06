using System.Globalization;
using FinanceManager.Infrastructure.Constants.Localization;
using FinanceManager.Web.Preferences;
using FinanceManager.Web.Preferences.Client;
using FinanceManager.Web.Services.Autorization;
using FinanceManager.Web.Settings;
using MudBlazor;

namespace FinanceManager.Web.ViewModels;

public class MainLayoutViewModel : IViewModel
{
    private readonly IPreferencesManager _preferencesManager;
    private readonly FinanceManagerStateProvider _stateProvider;
    public MudTheme CurrentTheme { get; set; }
    public bool RightToLeft { get; set; } = false;

    public string ThemeIcon { get; set; }

    public MainLayoutViewModel(FinanceManagerStateProvider stateProvider, IPreferencesManager preferencesManager)
    {
        _preferencesManager = preferencesManager ?? throw new ArgumentNullException(nameof(preferencesManager));
        _stateProvider = stateProvider;
    }

    public async Task InitializationAsync()
    {
        await SetPreferences();

        await _stateProvider.GetAuthenticationStateProviderUserAsync();
    }

    public async Task RightToLeftToggle(bool value)
    {
        RightToLeft = value;
        await Task.CompletedTask;
    }

    public async Task DarkMode()
    {
        bool isDarkMode = await _preferencesManager.ToggleDarkModeAsync();
        CurrentTheme = isDarkMode
            ? FinanceManagerThemes.DefaultTheme
            : FinanceManagerThemes.DarkTheme;

        ThemeIcon = !isDarkMode ?
            Icons.Material.Filled.Brightness2 :
            Icons.Material.Filled.BrightnessLow;
    }

    private async Task SetPreferences()
    {
        CurrentTheme = FinanceManagerThemes.DefaultTheme;
        CurrentTheme = await _preferencesManager.GetCurrentThemeAsync();
        RightToLeft = await _preferencesManager.IsRTL();

        ThemeIcon = CurrentTheme == FinanceManagerThemes.DarkTheme ? 
            Icons.Material.Filled.Brightness2 :
            Icons.Material.Filled.BrightnessLow;

        CultureInfo culture;
        var preference = await _preferencesManager.GetPreference() as ClientPreferences;
        if (preference != null)
            culture = new CultureInfo(preference.LanguageCode);
        else
            culture = new CultureInfo(LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? LocalizationConstants.EnglishLanguage.Code);
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}
