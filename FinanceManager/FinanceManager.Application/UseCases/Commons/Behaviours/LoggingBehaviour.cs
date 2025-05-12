using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Commons.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private const string _passwordPropertyString = "password";
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
    private readonly JsonSerializerOptions _serializationOption;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _serializationOption = new() { WriteIndented = true };
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        LoggingInvokedRequest(request);

        var response = await next();

        _logger.LogInformation("FinanceManagerApi Response Handling: {Name} \n{Response}", typeof(TResponse).Name, JsonSerializer.Serialize(response, _serializationOption));

        return response;
    }

    private void LoggingInvokedRequest(TRequest request)
    {
        if (IsHavePassword(request.GetType()))
        {
            _logger.LogInformation("FinanceManagerApi Request Handling: {Name}", typeof(TRequest).Name);
            return;
        }
        _logger.LogInformation("FinanceManagerApi Request Handling: {Name} \n{Request}", typeof(TRequest).Name, JsonSerializer.Serialize(request, _serializationOption));
    }

    private bool IsHavePassword(Type type)
    {
        return type.GetProperties().Any(prop => prop.Name.ToLower().Contains(_passwordPropertyString));
    }
}
