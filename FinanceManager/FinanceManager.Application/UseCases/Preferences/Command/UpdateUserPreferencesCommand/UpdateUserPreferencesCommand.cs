using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Constants.Localization;
using MediatR;

namespace FinanceManager.Application.UseCases.Preferences.Command.UpdateUserPreferencesCommand;

public class UpdateUserPreferencesCommand : IRequest<IResult>
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
