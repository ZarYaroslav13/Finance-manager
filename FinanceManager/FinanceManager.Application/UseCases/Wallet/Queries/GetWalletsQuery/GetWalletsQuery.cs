using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.Wallet.Queries.GetWalletsQuery;

public class GetWalletsQuery : IRequest<BaseResponse<List<WalletDTO>>>
{
    public int UserId { get; set; }
    
    public string UserRole { get; set; }

    public int AccountId { get; set; }
}
