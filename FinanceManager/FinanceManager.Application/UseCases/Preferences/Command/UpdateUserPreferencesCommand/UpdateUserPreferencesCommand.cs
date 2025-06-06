using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Preferences.Command.UpdateUserPreferencesCommand;

public class UpdateUserPreferencesCommand : IRequest<IResult>
{
    public UserPreferencesDTO UserPreferences { get; set; }
}
