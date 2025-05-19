using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Infrastructure.Models.Authorization;

public class FinanceManagerRole : IdentityRole<Guid>, IIdentityEntity
{
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }

    public FinanceManagerRole()
    {

    }

    public FinanceManagerRole(string roleName, string roleDescription = null) : base(roleName)
    {
        Description = roleDescription;
    }
}
