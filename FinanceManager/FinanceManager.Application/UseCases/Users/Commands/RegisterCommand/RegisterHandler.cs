using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Users;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Users.Commands.RegisterCommand;

public class RegisterHandler : BaseRequestHandler, IRequestHandler<RegisterCommand, IResult>
{
    private readonly IUserService _userService;

    public RegisterHandler(IUserService userService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task<IResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            return await _userService.RegisterAsync(_mapper.Map<UserModel>(request), request.Password);
        });
    }
}
