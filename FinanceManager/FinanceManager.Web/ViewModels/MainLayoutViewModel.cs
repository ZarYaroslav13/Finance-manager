using FinanceManager.Web.Preferences;
using FinanceManager.Web.Services.Autorization;
using FinanceManager.Web.Settings;
using FinanceManager.Web.ViewModels.Pages;
using MudBlazor;

namespace FinanceManager.Web.ViewModels;

public class MainLayoutViewModel : IViewModel
{
    private readonly IPreferencesManager _preferencesManager;
    private readonly FinanceManagerStateProvider _stateProvider;
    public MudTheme CurrentTheme { get; set; }
    public bool RightToLeft { get; set; } = false;

    public MainLayoutViewModel(FinanceManagerStateProvider stateProvider, IPreferencesManager preferencesManager)
    {
        _preferencesManager = preferencesManager ?? throw new ArgumentNullException(nameof(preferencesManager));
        _stateProvider = stateProvider;
    }

    public async Task InitializationAsynk()
    {
        CurrentTheme = FinanceManagerThemes.DefaultTheme;
        CurrentTheme = await _preferencesManager.GetCurrentThemeAsync();
        RightToLeft = await _preferencesManager.IsRTL();

        await _stateProvider.GetAuthenticationStateProviderUserAsync();
    }

    public async Task RightToLeftToggle(bool value)
    {
        RightToLeft = value;
        await Task.CompletedTask;
    }

    public async Task OnInitializedAsync()
    {
        CurrentTheme = FinanceManagerThemes.DefaultTheme;
        CurrentTheme = await _preferencesManager.GetCurrentThemeAsync();
        RightToLeft = await _preferencesManager.IsRTL();
    }

    public async Task DarkMode()
    {
        bool isDarkMode = await _preferencesManager.ToggleDarkModeAsync();
        CurrentTheme = isDarkMode
            ? FinanceManagerThemes.DefaultTheme
            : FinanceManagerThemes.DarkTheme;
    }
}
