using AutoMapper;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;

public class UpdateAccountHandler : BaseRequestHandler, IRequestHandler<UpdateAccountCommand, IResult>
{
    private readonly UserManager<FinanceManagerUser> _userManager;
    private readonly SignInManager<FinanceManagerUser> _signInManager;

    public UpdateAccountHandler(UserManager<FinanceManagerUser> userManager, SignInManager<FinanceManagerUser> signInManager,
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
    }

    public async Task<IResult> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await Task.FromResult(request.Id.ToString() == _currentUserService.UserId));

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null && userWithSameEmail.Id != request.Id)
            {
                return await Result.FailAsync($"Email {userWithSameEmail.Email} is already used.");
            }

            var user = userWithSameEmail ?? await _userManager.FindByIdAsync(request.Id.ToString());

            CopyProperities(user, _mapper.Map<FinanceManagerUser>(request));

            var identityResult = await _userManager.UpdateAsync(user);
            var errors = identityResult.Errors.Select(e => e.Description).ToList();
            await _signInManager.RefreshSignInAsync(user);
            return identityResult.Succeeded ? await Result.SuccessAsync("Account updated successfully!") : await Result.FailAsync(errors);
        });
    }

    private void CopyProperities(FinanceManagerUser user, FinanceManagerUser modifiedUser)
    {
        user.Email = modifiedUser.Email;
        user.LastName = modifiedUser.LastName;
        user.FirstName = modifiedUser.FirstName;
    }
}
