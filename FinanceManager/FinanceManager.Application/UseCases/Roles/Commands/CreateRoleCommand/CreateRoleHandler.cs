using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Roles;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Roles.Commands.CreateRoleCommand;

public class CreateRoleHandler : BaseRequestHandler, IRequestHandler<CreateRoleCommand, IResult>
{
    private readonly IRoleService _roleService;

    public CreateRoleHandler(IRoleService roleService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
    }

    public async Task<IResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request);

            var result = await _roleService.AddAsync(_mapper.Map<RoleModel>(request));

            return result;
        });
    }
}
