using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Domain.UseCases.FinanceOperationTypes.Queries.IsCallerTypeOwnerQuery;

public class IsCallerTypeOwnerQuery : IRequest<IResult<bool>>
{
    [GuidRequired]
    public Guid Id { get; set; }
}
