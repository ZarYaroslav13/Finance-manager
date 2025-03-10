
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.Commons.Bases;

public class BaseResponse<T>
{
    public bool Success { get; set; }

    public T? Data { get; set; }

    public string? Message { get; set; }

    public IEnumerable<BaseError>? Errors { get; set; }
}
