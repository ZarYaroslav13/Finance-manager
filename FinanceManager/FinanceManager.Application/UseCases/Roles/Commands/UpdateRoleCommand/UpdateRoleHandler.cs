using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Roles;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Roles.Commands.UpdateRoleCommand;

public class UpdateRoleHandler : BaseRequestHandler, IRequestHandler<UpdateRoleCommand, IResult>
{
    private readonly IRoleService _roleService;

    public UpdateRoleHandler(IRoleService roleService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
    }

    public async Task<IResult> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request);

            var result = await _roleService.UpdateAsync(_mapper.Map<RoleModel>(request));

            return result;
        });
    }
}
