using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.Accounts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Accounts.Queries.GetAllCustomersQuery;

public class GetAllCustomersHandler : BaseHandler, IRequestHandler<GetAllCustomersQuery, BaseResponse<List<AccountDTO>>>
{
    private readonly IAccountService _accountService;

    public GetAllCustomersHandler(IAccountService accountService, IMapper mapper, ILogger<GetAllCustomersHandler> logger) : base(mapper, logger)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public async Task<BaseResponse<List<AccountDTO>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<List<AccountDTO>>();

        try
        {
            response.Data = (await _accountService.GetAccountsAsync(request.UserRole, request.skip, request.take))
                    .Select(_mapper.Map<AccountDTO>)
                    .ToList();

            response.MakeAsSuccess("Accounts retrieved successfully");
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}
