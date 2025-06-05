using FinanceManager.Infrastructure.Constants.Localization;

namespace FinanceManager.Web.Preferences.Client;

public class ClientPreferences : IPreferences
{
    public bool IsDarkMode { get; set; }
    public bool IsRTL { get; set; }
    public string LanguageCode { get; set; } = LocalizationConstants.EnglishLanguage.Code;
}
