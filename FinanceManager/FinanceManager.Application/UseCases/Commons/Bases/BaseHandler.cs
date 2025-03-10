using AutoMapper;
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
}
