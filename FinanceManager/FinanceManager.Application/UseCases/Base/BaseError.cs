using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.Base;

public class BaseError
{
    public string? PropertyMessage { get; set; }
    public string? ErrorMessage { get; set; }
}
