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
    /// Throw <exception cref="UnauthorizedAccessException"></exception> if user is not suit to permission conditions
    /// </summary>
    /// <param name="request"></param>
    /// <exception cref="UnauthorizedAccessException"></exception>
    protected void CheckIsUserResourceOwnerOrAdmin<Request>(
        Request request,
        string loggingMessage = "",
        Func<Request, int>? idSelector = null,
        Func<bool>? addinionallyCondition = null) where Request : BaseRequest
    {
        HandleLoggingMessage(request, loggingMessage);

        bool conditions = request.UserRole != AdminService.AdminRole
                    && (idSelector == null ? true : request.UserId != idSelector(request))
                    && (addinionallyCondition == null ? true : !addinionallyCondition());

        CheckIsUserSuitConditions(conditions, loggingMessage);
    }

    protected async Task CheckIsUserResourceOwnerOrAdminAsync<Request>(
    Request request,
    string loggingMessage = "",
    Func<Request, int>? idSelector = null,
    Func<Task<bool>>? addinionallyCondition = null) where Request : BaseRequest
    {
        HandleLoggingMessage(request, loggingMessage);

        bool additionalConditionResult = addinionallyCondition != null ? await addinionallyCondition() : true;

        bool conditions = request.UserRole != AdminService.AdminRole
                         && (idSelector == null || request.UserId != idSelector(request))
                         && !additionalConditionResult;


        CheckIsUserSuitConditions(conditions, loggingMessage);
    }

    private string HandleLoggingMessage<Request>(
        Request request,
        string loggingMessage) where Request : BaseRequest
    {
        if (string.IsNullOrWhiteSpace(loggingMessage))
        {
            loggingMessage = $"Unallowed access attempt to resource in request: {request.GetType()} by user with id: {request.UserId} and role {request.UserRole}";
        }

        return loggingMessage;
    }

    private void CheckIsUserSuitConditions(bool conditions, string loggingMessage)
    {
        if (conditions)
        {
            _logger.LogWarning(loggingMessage);
            throw new UnauthorizedAccessException($"Access denied");
        }
    }
}
