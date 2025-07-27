using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Models;
using MediatR;

namespace FinanceManager.Domain.UseCases.Commons.Preferences.Query.GetUserPreferencesQuery;

public class GetUserPreferencesQuery : IRequest<Wrapper.Result<UserPreferencesModel>>
{
    [GuidRequired]
    public Guid UserId { get; set; }
}
