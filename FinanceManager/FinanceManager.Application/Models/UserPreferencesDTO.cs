using FinanceManager.Application.Models.Base;
using FinanceManager.Infrastructure.Constants.Localization;

namespace FinanceManager.Application.Models;

public class UserPreferencesDTO : ModelDTO
{
    public bool DarkMode { get; set; }

    public bool RightToLeft { get; set; }

    public string LanguageCode { get; set; } = LocalizationConstants.EnglishLanguage.Code;

    public Guid UserId { get; set; }
}
