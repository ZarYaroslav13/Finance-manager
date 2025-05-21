using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Users;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Users.Queries.ConfirmEmailQuery;

public class ConfirmEmailHandler : BaseRequestHandler, IRequestHandler<ConfirmEmailQuery, IResult>
{
    private readonly IUserService _userService;

    public ConfirmEmailHandler(IUserService userService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task<IResult> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)

    {
        return await HandleAsync(async () =>
        {
            return await _userService.ConfirmEmailAsync(request.UserId, request.Code);
        });
    }
}
