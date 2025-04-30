using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Domain.Authorization;

public class PolicyManager
{
    public const string AdminRole = "Admin";
    public const string AdminPolicy = "OnlyForAdmins";

    public const string UserRoleName = "User";
}
