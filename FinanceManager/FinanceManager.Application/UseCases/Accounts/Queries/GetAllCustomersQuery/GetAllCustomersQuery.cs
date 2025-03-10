using FinanceManager.Application.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace FinanceManager.Application.UseCases.Accounts.Queries.GetAllCustomersQuery;

public class GetAllCustomersQuery : IRequest<List<AccountDTO>>
{
    [Required]
    public string UserRole {  get; set; }

    public int skip { get; set; } = 0;

    public int take { get; set; } = 0;
}
