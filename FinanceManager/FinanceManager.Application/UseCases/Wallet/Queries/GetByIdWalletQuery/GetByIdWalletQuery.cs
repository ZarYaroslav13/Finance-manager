using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.Wallet.Queries.GetByIdWalletQuery;

public class GetByIdWalletQuery : IRequest<BaseResponse<WalletDTO>>
{
    public int UserId { get; set; }

    public string UserRole { get; set; }

    public int WalletId { get; set; }
}
