using AutoMapper;
using FinanceManager.Domain.Authorization;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Users.Commands.UpdateUserRolesCommand;

public class UpdateUserRolesHandler : BaseRequestHandler, IRequestHandler<UpdateUserRolesCommand, IResult>
{
    private readonly UserManager<FinanceManagerUser> _userManager;
    private readonly RoleManager<FinanceManagerRole> _roleManager;

    public UpdateUserRolesHandler(UserManager<FinanceManagerUser> userManager, RoleManager<FinanceManagerRole> roleManager,
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
    }

    public async Task<IResult> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
    {
        const string mainAdminEmail = "adminchick.FinanceManager@gmail.com";
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user.Email == mainAdminEmail)
        {
            return await Result.FailAsync("Not Allowed.");
        }

        var roles = await _userManager.GetRolesAsync(user);
        var selectedRoles = request.NewRoles.Where(x => x.Selected).ToList();

        var currentUser = await _userManager.FindByIdAsync(_currentUserService.UserId);
        if (!await _userManager.IsInRoleAsync(currentUser, PolicyManager.AdminRole))
        {
            var tryToAddAdministratorRole = selectedRoles
                .Any(x => x.RoleName == PolicyManager.AdminRole);
            var userHasAdministratorRole = roles.Any(x => x == PolicyManager.AdminRole);
            if (tryToAddAdministratorRole && !userHasAdministratorRole || !tryToAddAdministratorRole && userHasAdministratorRole)
            {
                return await Result.FailAsync("Not Allowed to add or delete Administrator Role if you have not this role.");
            }
        }

        return Result.Success("User roles updated successfully!");
    }
}
