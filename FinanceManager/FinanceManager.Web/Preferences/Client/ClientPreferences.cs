using FinanceManager.Web.Shared.Constants.Localization;

namespace FinanceManager.Web.Preferences.Client;

public class ClientPreferences : IPreferences
{
    public bool IsDarkMode { get; set; }
    public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";
}
