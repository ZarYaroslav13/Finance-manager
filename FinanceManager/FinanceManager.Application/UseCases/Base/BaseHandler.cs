using AutoMapper;
using FinanceManager.Application.Models;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace FinanceManager.Application.UseCases.Base;

public class BaseHandler
{
    protected readonly ILogger<BaseHandler> _logger;
    protected readonly IMapper _mapper;

    public BaseHandler(IMapper mapper, ILogger<BaseHandler> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    protected string GetUserRole(ClaimsIdentity identity)
    {
        ArgumentNullException.ThrowIfNull(identity);

        return identity.FindFirst(identity.RoleClaimType).Value;
    }

    protected int GetUserId(ClaimsIdentity identity)
    {
        ArgumentNullException.ThrowIfNull(identity);

        string stringId = identity.FindFirst(nameof(AccountDTO.Id)).Value;

        int id = 0;

        if (!int.TryParse(stringId, out id))
            throw new InvalidOperationException(nameof(stringId));
        return id;
    }

    protected string GetUserEmail(ClaimsIdentity identity)
    {
        ArgumentNullException.ThrowIfNull(identity);

        return identity.Name;
    }
}
