using AutoMapper;
using FinanceManager.Domain.Authorization;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Domain.Services.Roles;

public class RoleService : IRoleService
{
    private readonly UserManager<FinanceManagerUser> _userManager;
    private readonly RoleManager<FinanceManagerRole> _roleManager;
    private readonly IMapper _mapper;

    public RoleService(UserManager<FinanceManagerUser> userManager, RoleManager<FinanceManagerRole> roleManager, IMapper mapper)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task<Result<List<RoleModel>>> GetAllAsync()
    {
        var roles = await _roleManager.Roles.ToListAsync();

        var rolesResponse = _mapper.Map<List<RoleModel>>(roles);

        return await Result<List<RoleModel>>.SuccessAsync(rolesResponse);
    }

    public async Task<Result<RoleModel>> GetByIdAsync(Guid id)
    {
        var roles = await _roleManager.Roles.SingleOrDefaultAsync(x => x.Id == id);

        var rolesResponse = _mapper.Map<RoleModel>(roles);

        return await Result<RoleModel>.SuccessAsync(rolesResponse);
    }

    public async Task<IResult> AddAsync(RoleModel request)
    {
        if (request.Id != Guid.Empty)
            return Result.Fail("Id must not to be specified");

        var existingRole = await _roleManager.FindByNameAsync(request.Name);

        if (existingRole != null)
            return await Result.FailAsync("Similar Role already exists.");

        var response = await _roleManager.CreateAsync(new FinanceManagerRole(request.Name, request.Description));
        if (response.Succeeded)
        {
            return Result.Success($"Role {request.Name} Created.");
        }

        return Result.Fail(response.Errors.Select(e => e.Description).ToList());
    }

    public async Task<IResult> UpdateAsync(RoleModel request)
    {
        if (request.Id == Guid.Empty)
            return Result.Fail("Id must to be specified");

        var existingRole = await _roleManager.FindByIdAsync(request.Id.ToString());

        if (existingRole.Name == PolicyManager.AdminRole || existingRole.Name == PolicyManager.CommonUserRole)
        {
            return Result.Fail($"Not allowed to modify {existingRole.Name} Role.");
        }

        existingRole.Name = request.Name;
        existingRole.NormalizedName = request.Name.ToUpper();
        existingRole.Description = request.Description;

        await _roleManager.UpdateAsync(existingRole);

        return Result.Success($"Role {existingRole} Updated.");
    }
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var existingRole = await _roleManager.FindByIdAsync(id.ToString());

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
    }

}
