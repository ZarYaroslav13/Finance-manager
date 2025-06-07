using FinanceManager.Infrastructure.Constants.Localization;

namespace FinanceManager.Web.Preferences.Client;

public class ClientPreferences : IPreferences
{
    public bool DarkMode { get; set; }
    public bool RightToLeft { get; set; }
    public string LanguageCode { get; set; } = LocalizationConstants.EnglishLanguage.Code;
}
