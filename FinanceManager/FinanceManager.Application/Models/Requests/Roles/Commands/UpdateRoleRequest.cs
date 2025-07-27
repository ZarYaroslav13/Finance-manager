using FinanceManager.Domain.DataAnnotations.Attributes;

namespace FinanceManager.Application.Models.Requests.Roles.Commands;

public class UpdateRoleRequest
{
    [GuidRequired]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
