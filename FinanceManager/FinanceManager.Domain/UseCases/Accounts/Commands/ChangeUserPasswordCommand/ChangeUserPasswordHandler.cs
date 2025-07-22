using AutoMapper;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;

public class ChangeUserPasswordHandler : BaseRequestHandler, IRequestHandler<ChangeUserPasswordCommand, IResult>
{
    private readonly UserManager<FinanceManagerUser> _userManager;

    public ChangeUserPasswordHandler(UserManager<FinanceManagerUser> userManager,
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task<IResult> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await Task.FromResult(request.Id.ToString() == _currentUserService.UserId));

            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                return await Result.FailAsync("User Not Found.");
            }

            var identityResult = await this._userManager.ChangePasswordAsync(
                user,
                request.OldPassword,
                request.NewPassword);
            var errors = identityResult.Errors.Select(e => e.Description).ToList();
            return identityResult.Succeeded ? await Result.SuccessAsync("Password changed successfully!") : await Result.FailAsync(errors);
        });
    }
}
