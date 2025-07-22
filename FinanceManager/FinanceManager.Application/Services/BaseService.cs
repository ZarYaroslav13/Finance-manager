using AutoMapper;
using MediatR;

namespace FinanceManager.Application.Services;

public abstract class BaseService
{
    protected readonly IMediator _mediator;
    protected readonly IMapper _mapper;

    public BaseService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mediator));
    }

    //protected async Task<IResult> SendRequestAsync<TCommand>(TCommand command)
    //where TCommand : IBaseRequest
    //{
    //    dynamic result = await _mediator.Send(command);

    //    return result.Succeeded ? Ok(result) : BadRequest(result);
    //}
}
