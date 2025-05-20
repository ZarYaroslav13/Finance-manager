using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Domain.Modelsl;

public class UserRoleModel
{
    public string RoleName { get; set; }
    public string RoleDescription { get; set; }
    public bool Selected { get; set; }
}
