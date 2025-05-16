using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Accounts.Queries.GetCustomerQuery;

public class GetCustomerHandler : BaseRequestHandler, IRequestHandler<GetCustomerQuery, BaseResponse<AccountDTO>>
{
    public GetCustomerHandler(IMapper mapper, ILogger<BaseRequestHandler> logger) : base(mapper, logger)
    {
    }

    public Task<BaseResponse<AccountDTO>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
