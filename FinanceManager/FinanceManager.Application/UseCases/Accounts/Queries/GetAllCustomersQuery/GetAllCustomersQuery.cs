using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Application.UseCases.Accounts.Queries.GetAllCustomersQuery;

public class GetAllCustomersQuery : IRequest<BaseResponse<List<AccountDTO>>>
{
    [Required]
    public string UserRole { get; set; }

    public int skip { get; set; } = 0;

    public int take { get; set; } = 0;
}
