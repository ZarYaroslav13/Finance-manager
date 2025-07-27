using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.Models.Requests.Roles.Commands;

public class CreateRoleRequest
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
}
