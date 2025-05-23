using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Roles;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Roles.Queries.GetAllRolesQuery;

public class GetAllRolesHandler : BaseRequestHandler, IRequestHandler<GetAllRolesQuery, Result<List<RoleDTO>>>
{
    private readonly IRoleService _roleService;

    public GetAllRolesHandler(IRoleService roleService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
    }

    public async Task<Result<List<RoleDTO>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request);

            var result = await _roleService.GetAllAsync();

            return _mapper.Map<Result<List<RoleDTO>>>(result);
        });
    }
}
