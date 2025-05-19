using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Infrastructure.Authorization;

public class APIRole : IdentityRole, IIdentityEntity
{
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }

    public APIRole(string roleName, string roleDescription = null) : base(roleName)
    {
        Description = roleDescription;
    }
}
