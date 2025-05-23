using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Roles;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Roles.Queries.GetRoleQuery;

public class GetRoleHandler : BaseRequestHandler, IRequestHandler<GetRoleQuery, Result<RoleDTO>>
{
    private readonly IRoleService _roleService;

    public GetRoleHandler(IRoleService roleService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
    }

    public async Task<Result<RoleDTO>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request);

            var result = await _roleService.GetByIdAsync(request.Id);

            return _mapper.Map<Result<RoleDTO>>(result);
        });
    }
}
