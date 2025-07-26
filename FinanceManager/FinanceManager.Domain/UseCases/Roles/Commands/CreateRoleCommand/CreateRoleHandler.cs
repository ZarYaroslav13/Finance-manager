using AutoMapper;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Roles.Commands.CreateRoleCommand;

public class CreateRoleHandler : BaseRequestHandler, IRequestHandler<CreateRoleCommand, IResult>
{
    private readonly RoleManager<FinanceManagerRole> _roleManager;

    public CreateRoleHandler(RoleManager<FinanceManagerRole> roleManager,
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
    }

    public async Task<IResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request);

            var existingRole = await _roleManager.FindByNameAsync(request.Name);

            if (existingRole != null)
                return await Result.FailAsync("Similar Role already exists.");

            var response = await _roleManager.CreateAsync(new FinanceManagerRole(request.Name, request.Description));
            if (response.Succeeded)
            {
                return Result.Success($"Role {request.Name} Created.");
            }

            return Result.Fail(response.Errors.Select(e => e.Description).ToList());
        });
    }
}
