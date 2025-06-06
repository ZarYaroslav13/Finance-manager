using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using MediatR;

namespace FinanceManager.Application.UseCases.Preferences.Query.GetUserPreferencesQuery;

public class GetUserPreferencesQuery : IRequest<Domain.Wrapper.Result<UserPreferencesDTO>>
{
    [GuidRequired]
    public Guid UserId { get; set; }
}
