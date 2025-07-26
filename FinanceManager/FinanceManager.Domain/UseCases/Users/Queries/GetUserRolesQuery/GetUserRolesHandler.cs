using AutoMapper;
using FinanceManager.Domain.Modelsl;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Users.Queries.GetUserRolesQuery;

public class GetUserRolesHandler : BaseRequestHandler, IRequestHandler<GetUserRolesQuery, Result<List<UserRoleModel>>>
{
    private readonly UserManager<FinanceManagerUser> _userManager;
    private readonly RoleManager<FinanceManagerRole> _roleManager;
    public GetUserRolesHandler(UserManager<FinanceManagerUser> userManager, RoleManager<FinanceManagerRole> roleManager,
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
    }

    public async Task<Result<List<UserRoleModel>>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
    {
        var viewModel = new List<UserRoleModel>();
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        var roles = await _roleManager.Roles.ToListAsync();

        foreach (var role in roles)
        {
            var userRolesViewModel = new UserRoleModel
            {
                RoleName = role.Name,
                RoleDescription = role.Description
            };

            if (await _userManager.IsInRoleAsync(user, role.Name))
            {
                viewModel.Add(userRolesViewModel);
            }
        }
        var result = viewModel.Select(_mapper.Map<UserRoleModel>).ToList();
        return await Result<List<UserRoleModel>>.SuccessAsync(result);
    }
}
