using AutoMapper;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Commons.Users.Commands.DeleteUserCommand;

public class DeleteUserHandler : BaseRequestHandler, IRequestHandler<DeleteUserCommand, IResult>
{
    private readonly UserManager<FinanceManagerUser> _userManager;

    public DeleteUserHandler(UserManager<FinanceManagerUser> userManager,
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task<IResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
               async () => await Task.FromResult(_currentUserService.UserId == request.Id.ToString()));

            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            await _userManager.DeleteAsync(user);

            return Result.Success("Deleted successfully!");
        });
    }
}
