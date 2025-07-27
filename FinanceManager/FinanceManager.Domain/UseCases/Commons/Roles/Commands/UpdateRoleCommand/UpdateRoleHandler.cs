using AutoMapper;
using FinanceManager.Domain.Authorization;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Commons.Roles.Commands.UpdateRoleCommand;

public class UpdateRoleHandler : BaseRequestHandler, IRequestHandler<UpdateRoleCommand, IResult>
{
    private readonly RoleManager<FinanceManagerRole> _roleManager;

    public UpdateRoleHandler(RoleManager<FinanceManagerRole> roleManager,
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
    }

    public async Task<IResult> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request);

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
        });
    }
}
