using AutoMapper;
using FinanceManager.Domain.Authorization;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Roles.Commands.DeleteRoleCommand;

public class DeleteRoleHandler : BaseRequestHandler, IRequestHandler<DeleteRoleCommand, IResult>
{
    private readonly RoleManager<FinanceManagerRole> _roleManager;
    private readonly UserManager<FinanceManagerUser> _userManager;

    public DeleteRoleHandler(RoleManager<FinanceManagerRole> roleManager, UserManager<FinanceManagerUser> userManager,
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task<IResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request);

            var existingRole = await _roleManager.FindByIdAsync(request.Id.ToString());

            if (existingRole.Name != PolicyManager.AdminRole && existingRole.Name != PolicyManager.CommonUserRole)
            {
                bool roleIsNotUsed = true;
                var allUsers = await _userManager.Users.ToListAsync();
                foreach (var user in allUsers)
                {
                    if (await _userManager.IsInRoleAsync(user, existingRole.Name))
                    {
                        roleIsNotUsed = false;
                        break;
                    }
                }

                if (roleIsNotUsed)
                {
                    await _roleManager.DeleteAsync(existingRole);

                    return Result.Success($"Role {existingRole.Name} Deleted.");
                }

                return Result.Fail($"Not allowed to delete {existingRole.Name} Role as it is being used.");
            }

            return Result.Fail($"Not allowed to delete {existingRole.Name} Role.");
        });
    }
}
