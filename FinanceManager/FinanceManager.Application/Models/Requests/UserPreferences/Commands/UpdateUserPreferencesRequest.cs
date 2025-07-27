using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Infrastructure.Constants.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Models.Requests.UserPreferences.Commands;

public class UpdateUserPreferencesRequest
{
    [Required]
    public bool DarkMode { get; set; }

    [Required]
    public bool RightToLeft { get; set; }

    [Required]
    public string LanguageCode { get; set; } = LocalizationConstants.EnglishLanguage.Code;

    [GuidRequired]
    public Guid UserId { get; set; }
}
