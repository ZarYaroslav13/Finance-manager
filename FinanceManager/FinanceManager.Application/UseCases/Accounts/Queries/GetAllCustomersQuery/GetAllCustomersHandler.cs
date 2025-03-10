using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Base;
using FinanceManager.Domain.Services.Accounts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Accounts.Queries.GetAllCustomersQuery;

public class GetAllCustomersHandler : BaseHandler, IRequestHandler<GetAllCustomersQuery, List<AccountDTO>>
{
    private readonly IAccountService _accountService;

    public GetAllCustomersHandler(IAccountService accountService, IMapper mapper, ILogger<GetAllCustomersHandler> logger) : base(mapper, logger)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public async Task<List<AccountDTO>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var response = new List<AccountDTO>();

        try
        {
            _logger.LogInformation("GetAllAsync called by admin with skip: {Skip}, take: {Take}", request.skip, request.take);

            response = (await _accountService.GetAccountsAsync(GetUserEmail(request.Identity), request.skip, request.take))
                    .Select(_mapper.Map<AccountDTO>)
                    .ToList();

            _logger.LogInformation("{Count} accounts retrieved successfully", response.Count);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }

        return response;
    }
}
