using AutoMapper;
using FinanceManager.Domain.Models.Base;
using FinanceManager.Domain.Services.CurrentUserService;
using MediatR;
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

    protected async Task CheckIsUserHaveAccesToResourseAsync<Request, TResourse>(
        Request request,
        string resourseId,
        Func<TResourse, Guid> getCalleridFromResFunc,
        Func<Task<TResourse>> getResFunc,
        string loggingMessage = "")
        where Request : class, IBaseRequest
        where TResourse : Model
    {
        HandleLoggingMessage(request, loggingMessage);

        bool IsCallerResourseOwner = await CheckIsCallerResourseOwner(resourseId, getResFunc, getCalleridFromResFunc);

        if (!_currentUserService.IsAdmin && !IsCallerResourseOwner)
        {
            _logger.LogWarning(loggingMessage);
            throw new UnauthorizedAccessException($"Access denied");
        }
    }

    protected async Task<bool> CheckIsCallerResourseOwner<TResourse>(
        string resourseId,
        Func<Task<TResourse>> getResFunc,
        Func<TResourse, Guid> getCalleridFromResFunc)
        where TResourse : Model
    {
        string callerId = _currentUserService.UserId;

        if (string.IsNullOrEmpty(callerId) || string.IsNullOrEmpty(resourseId))
            throw new ArgumentOutOfRangeException("caller id and resourse id must be specified");

        var resourse = (await getResFunc());

        return getCalleridFromResFunc(resourse).ToString() == callerId;
    }

    private string HandleLoggingMessage<Request>(
        Request request,
        string loggingMessage) where Request : class, IBaseRequest
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
}
