using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Users;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Users.Commands.DeleteAccountByIdCommand;

public class DeleteUserHandler : BaseRequestHandler, IRequestHandler<DeleteUserCommand, IResult>
{
    private readonly IUserService _userService;

    public DeleteUserHandler(IUserService userService, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task<IResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
               async () => await Task.FromResult(_currentUserService.UserId == request.Id.ToString()));

            return await _userService.DeleteUserAsync(request.Id);
        });
    }
}
