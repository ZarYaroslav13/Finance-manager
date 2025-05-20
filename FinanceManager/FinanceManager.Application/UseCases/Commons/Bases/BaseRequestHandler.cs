using AutoMapper;
using FinanceManager.Domain.Authorization;
using FinanceManager.Domain.Services.CurrentUserService;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Commons.Bases;

public class BaseRequestHandler
{
    protected readonly ICurrentUserService _currentUserService;
    protected readonly ILogger<BaseRequestHandler> _logger;
    protected readonly IMapper _mapper;

    public BaseRequestHandler(ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger)
    {
        _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Throw <exception cref="UnauthorizedAccessException"></exception> if user is not suit to permission conditions
    /// </summary>
    /// <param name="request"></param>
    /// <exception cref="UnauthorizedAccessException"></exception>
    protected void CheckIsUserHaveAccesToResourse<Request>(
        Request request,
        string loggingMessage = "",
        Func<Request, string>? idSelector = null,
        Func<bool>? addinionallyCondition = null) where Request : BaseRequest
    {
        HandleLoggingMessage(request, loggingMessage);

        bool conditions = !_currentUserService.IsAdmin
                    && (idSelector == null ? true : _currentUserService.UserId != idSelector(request))
                    && (addinionallyCondition == null ? true : !addinionallyCondition());

        CheckIsUserMustBeDenied(conditions, loggingMessage);
    }

    protected async Task CheckIsUserHaveAccesToResourseAsync<Request>(
    Request request,
    string loggingMessage = "",
    Func<Request, string>? idSelector = null,
    Func<Task<bool>>? addinionallyCondition = null) where Request : BaseRequest
    {
        HandleLoggingMessage(request, loggingMessage);

        bool additionalConditionResult = addinionallyCondition != null ? await addinionallyCondition() : true;

        bool conditions = !_currentUserService.IsAdmin
                         && (idSelector == null || _currentUserService.UserId != idSelector(request))
                         && !additionalConditionResult;


        CheckIsUserMustBeDenied(conditions, loggingMessage);
    }

    private string HandleLoggingMessage<Request>(
        Request request,
        string loggingMessage) where Request : BaseRequest
    {
        if (string.IsNullOrWhiteSpace(loggingMessage))
        {
            loggingMessage = 
                $"Unallowed access attempt to resource in request: {request.GetType()} " +
                $"by user with id: {_currentUserService.UserId} and " +
                $"roles {_currentUserService.Roles.Aggregate((acc, r) => acc += r + ", ")}";
        }

        return loggingMessage;
    }

    private void CheckIsUserMustBeDenied(bool conditions, string loggingMessage)
    {
        if (conditions)
        {
            _logger.LogWarning(loggingMessage);
            throw new UnauthorizedAccessException($"Access denied");
        }
    }
}
