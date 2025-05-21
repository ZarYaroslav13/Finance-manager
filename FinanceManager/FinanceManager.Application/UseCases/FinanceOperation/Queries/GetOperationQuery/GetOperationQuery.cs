using System.ComponentModel.DataAnnotations;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.FinanceOperation.Queries.GetOperationQuery;

public class GetOperationQuery : IRequest<Result<FinanceOperationDTO>>
{
    [Required]
    public string Id { get; set; }
}
