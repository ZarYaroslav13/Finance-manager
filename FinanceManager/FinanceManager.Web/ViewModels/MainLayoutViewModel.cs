using FinanceManager.Infrastructure.Constants.Localization;
using FinanceManager.Web.Preferences;
using FinanceManager.Web.Services.Autorization;
using FinanceManager.Web.Settings;
using Microsoft.Extensions.Localization;
using MudBlazor;
using System.Globalization;

namespace FinanceManager.Web.ViewModels;

public class MainLayoutViewModel : IViewModel
{
    private readonly IPreferencesManager _preferencesManager;
    private readonly FinanceManagerStateProvider _stateProvider;
    public MudTheme CurrentTheme { get; set; }
    public bool RightToLeft { get; set; } = false;

    public string ThemeIcon { get; set; }

    public IStringLocalizer<MainLayoutViewModel> Localizer { get; set; }

    public MainLayoutViewModel(FinanceManagerStateProvider stateProvider, IPreferencesManager preferencesManager, IStringLocalizer<MainLayoutViewModel> localizer)
    {
        _preferencesManager = preferencesManager ?? throw new ArgumentNullException(nameof(preferencesManager));
        _stateProvider = stateProvider;

        Localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
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

        ThemeIcon = isDarkMode ?
            Icons.Material.Filled.WbSunny :
            Icons.Material.Filled.Brightness2;
    }

    private async Task SetPreferences()
    {
        CurrentTheme = FinanceManagerThemes.DefaultTheme;
        CurrentTheme = await _preferencesManager.GetCurrentThemeAsync();
        RightToLeft = await _preferencesManager.IsRTL();

        ThemeIcon = CurrentTheme == FinanceManagerThemes.DefaultTheme ?
            Icons.Material.Filled.WbSunny :
           Icons.Material.Filled.Brightness2;

        CultureInfo culture;
        var preference = await _preferencesManager.GetPreference();
        if (preference != null)
            culture = new CultureInfo(preference.LanguageCode);
        else
            culture = new CultureInfo(LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? LocalizationConstants.EnglishLanguage.Code);
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}
