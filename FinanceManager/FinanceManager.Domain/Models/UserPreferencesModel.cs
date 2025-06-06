using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManager.Domain.Models.Base;
using FinanceManager.Infrastructure.Constants.Localization;

namespace FinanceManager.Domain.Models;

public class UserPreferencesModel : Model
{
    public bool DarkMode { get; set; }

    public bool RightToLeft { get; set; }

    public string LanguageCode { get; set; } = LocalizationConstants.EnglishLanguage.Code;

    public Guid UserId { get; set; }
}
