using FinanceManager.Domain.Wrapper;
using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.Managers;

public abstract class BaseManager
{
    protected readonly IFinanceManagerApiHttpClient _apiHttpClient;
    protected readonly ILogger<BaseManager> _logger;

    public BaseManager(IFinanceManagerApiHttpClient httpClient, ILogger<BaseManager> logger)
    {
        _apiHttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    protected async Task<Domain.Wrapper.IResult> SendRequest(Func<Task<Domain.Wrapper.IResult>> request)
    {
        try
        {
            return await request();
        }
        catch (Refit.ValidationApiException validationEx)
        {
            List<string> messages = new();
            string message = "";
            foreach (var error in validationEx.Content.Errors)
            {
                message = "key: " + error.Key.ToString() + " value: " + error.Value.Aggregate((error, next) => error += next) + "\n";
                messages.Add(message);
                _logger.Log(LogLevel.Error, message);
            }

            return Result.Fail(messages);
        }
        catch (Refit.ApiException apiEx)
        {
            _logger.LogError(apiEx.Message);
            return Result.Fail(apiEx.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Result.Fail(ex.Message);
        }
    }

    protected async Task<Result<T>> SendRequest<T>(Func<Task<Result<T>>> request)
    {
        try
        {
            return await request();
        }
        catch (Refit.ValidationApiException validationEx)
        {
            List<string> messages = new();
            string message = "";
            foreach (var error in validationEx.Content.Errors)
            {
                message = "key: " + error.Key.ToString() + " value: " + error.Value.Aggregate((error, next) => error += next) + "\n";
                messages.Add(message);
                _logger.Log(LogLevel.Error, message);
            }

            return Result<T>.Fail(messages);
        }
        catch (Refit.ApiException apiEx)
        {
            _logger.LogError(apiEx.Message);
            return Result<T>.Fail(apiEx.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Result<T>.Fail(ex.Message);
        }
    }
    protected async Task<PaginatedResult<T>> SendRequest<T>(Func<Task<PaginatedResult<T>>> request)
    {
        try
        {
            return await request();
        }
        catch (Refit.ValidationApiException validationEx)
        {
            List<string> messages = new();
            string message = "";
            foreach (var error in validationEx.Content.Errors)
            {
                message = "key: " + error.Key.ToString() + " value: " + error.Value.Aggregate((error, next) => error += next) + "\n";
                messages.Add(message);
                _logger.Log(LogLevel.Error, message);
            }

            return PaginatedResult<T>.Failure(messages);
        }
        catch (Refit.ApiException apiEx)
        {
            _logger.LogError(apiEx.Message);
            return PaginatedResult<T>.Failure(apiEx.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return PaginatedResult<T>.Failure(ex.Message);
        }
    }
}
