using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Infrastructure.Authorization;

public interface IIdentityEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }
}
