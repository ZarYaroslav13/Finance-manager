using AutoMapper;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Commons.Bases;

public class BaseRequestHandler
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly ICurrentUserService _currentUserService;
    protected readonly ILogger<BaseRequestHandler> _logger;
    protected readonly IMapper _mapper;

    public BaseRequestHandler(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _currentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    protected async Task<IResult> HandleAsync(Func<Task<IResult>> handle)
    {
        try
        {
            return await handle();
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }

    protected async Task<Result<T>> HandleAsync<T>(Func<Task<Result<T>>> handle)
    {
        try
        {
            return await handle();
        }
        catch (Exception e)
        {
            return Result<T>.Fail(e.Message);
        }
    }

    protected async Task<PaginatedResult<T>> HandleAsync<T>(Func<Task<PaginatedResult<T>>> handle)
    {
        try
        {
            return await handle();
        }
        catch (Exception e)
        {
            return PaginatedResult<T>.Failure(e.Message);
        }
    }

    protected async Task CheckIsUserHaveAccesToResourseAsync<Request>(
        Request request,
        Func<Task<bool>> callerIsOwnerPredicate = null,
        string loggingMessage = "")
        where Request : class, IBaseRequest
    {
        HandleLoggingMessage(request, loggingMessage);

        bool IsCallerResourseOwner = true;

        if (callerIsOwnerPredicate != null)
        {
            IsCallerResourseOwner = await callerIsOwnerPredicate();
        }

        if (!_currentUserService.IsAdmin && !IsCallerResourseOwner)
        {
            _logger.LogWarning(loggingMessage);
            throw new UnauthorizedAccessException($"Access denied");
        }
    }

    protected void CheckIsUserHaveAccesToResourse<Request>(
        Request request,
        Func<bool> callerIsOwnerPredicate = null,
        string loggingMessage = "")
        where Request : class, IBaseRequest
    {
        HandleLoggingMessage(request, loggingMessage);

        bool IsCallerResourseOwner = true;

        if (callerIsOwnerPredicate != null)
        {
            IsCallerResourseOwner = callerIsOwnerPredicate();
        }

        if (!_currentUserService.IsAdmin && !IsCallerResourseOwner)
        {
            _logger.LogWarning(loggingMessage);
            throw new UnauthorizedAccessException($"Access denied");
        }
    }

    protected void CheckIsUserHaveAccesToResourse<Request>(
        Request request,
        bool? callerIsOwnerPredicate = null,
        string loggingMessage = "")
        where Request : class, IBaseRequest
    {
        HandleLoggingMessage(request, loggingMessage);

        bool IsCallerResourseOwner = true;

        if (callerIsOwnerPredicate != null)
        {
            IsCallerResourseOwner = callerIsOwnerPredicate ?? false;
        }

        if (!_currentUserService.IsAdmin && !IsCallerResourseOwner)
        {
            _logger.LogWarning(loggingMessage);
            throw new UnauthorizedAccessException($"Access denied");
        }
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
