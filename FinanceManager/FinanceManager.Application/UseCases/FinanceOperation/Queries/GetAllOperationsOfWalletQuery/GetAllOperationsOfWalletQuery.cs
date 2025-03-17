using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.FinanceOperation.Queries.GetAllOperationsOfWalletQuery;

public class GetAllOperationsOfWalletQuery : BaseRequest, IRequest<BaseResponse<List<FinanceOperationDTO>>>
{
    [Required]
    public int WalletId { get; set; }

    public int Index { get; set; } = 0;

    public int Count { get; set; } = 0;
}
