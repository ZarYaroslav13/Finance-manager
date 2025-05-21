using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Users;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Users.Commands.DeleteAccountByIdCommand;

public class DeleteAccountByIdHandler : BaseRequestHandler, IRequestHandler<DeleteAccountByIdCommand, IResult>
{
    private readonly IUserService _userService;

    public DeleteAccountByIdHandler(IUserService userService, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task<IResult> Handle(DeleteAccountByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            CheckIsUserHaveAccesToResourse(request, idSelector: r => r.Id);

            await _userService.DeleteUser(request.Id);

            return await Result.SuccessAsync("Delete succeed!");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }
}
