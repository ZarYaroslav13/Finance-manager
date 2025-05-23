using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Roles;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Roles.Commands.DeleteRoleCommand;

public class DeleteRoleHandler : BaseRequestHandler, IRequestHandler<DeleteRoleCommand, IResult>
{
    private readonly IRoleService _roleService;

    public DeleteRoleHandler(IRoleService roleService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<DeleteRoleHandler> logger) : base(currentUserService, mapper, logger)
    {
        _roleService = roleService ?? throw new ArgumentNullException(nameof(roleService));
    }

    public async Task<IResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request);

            var result = await _roleService.DeleteAsync(request.Id);

            return result;
        });
    }
}
