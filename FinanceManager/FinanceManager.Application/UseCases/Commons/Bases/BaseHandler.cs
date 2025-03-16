using AutoMapper;
using FinanceManager.Domain.Services.Admins;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Commons.Bases;

public class BaseHandler
{
    protected readonly ILogger<BaseHandler> _logger;
    protected readonly IMapper _mapper;

    public BaseHandler(IMapper mapper, ILogger<BaseHandler> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Throw <exception cref="UnauthorizedAccessException"></exception> if user is not suit to permission condition
    /// </summary>
    /// <param name="request"></param>
    /// <exception cref="UnauthorizedAccessException"></exception>
    protected void AuthorizationCheck<Request>(Request request, Func<Request, int> idSelector, string loggingMessage = "") where Request : BaseRequest
    {
        if (string.IsNullOrWhiteSpace(loggingMessage))
        {
            loggingMessage = $"UnAllowed access attempt to send request: {request.GetType()} by user with id: {request.UserId} and role {request.UserRole}";
        }

        if (request.UserRole != AdminService.AdminRole && request.UserId != idSelector(request))
        {
            _logger.LogWarning(loggingMessage);
            throw new UnauthorizedAccessException($"Access denied");
        }
    }
}
