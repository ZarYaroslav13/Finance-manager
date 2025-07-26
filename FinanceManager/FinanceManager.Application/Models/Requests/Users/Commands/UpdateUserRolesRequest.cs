using FinanceManager.Domain.DataAnnotations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.Users.Commands;

public class UpdateUserRolesRequest
{
    [GuidRequired]
    public Guid UserId;

    [Required]
    public List<RoleDTO> NewRoles;
}
