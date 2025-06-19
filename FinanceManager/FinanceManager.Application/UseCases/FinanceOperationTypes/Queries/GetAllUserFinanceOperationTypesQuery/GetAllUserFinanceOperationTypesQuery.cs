using FinanceManager.Application.DataAnnotations.Attributes;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.FinanceOperationTypes.Queries.GetAllUserFinanceOperationTypesQuery;

public class GetAllUserFinanceOperationTypesQuery : IRequest<Result<List<FinanceOperationTypeDTO>>>
{
    [GuidRequired]
    public Guid userId { get; set; }
}
