using FinanceManager.Infrastructure.Constants.Localization;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.Models.Base;

namespace FinanceManager.Infrastructure.Models;

public class UserPreference : Entity
{
    public bool DarkMode { get; set; } = false;

    public bool RightToLeft { get; set; } = false;

    public string LanguageCode { get; set; } = LocalizationConstants.EnglishLanguage.Code;

    public Guid UserId { get; set; }

    public FinanceManagerUser User { get; set; }
}
