using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Commons.Roles.Queries.GetRoleQuery;

public class GetRoleHandler : BaseRequestHandler, IRequestHandler<GetRoleQuery, Result<RoleModel>>
{
    private readonly RoleManager<FinanceManagerRole> _roleManager;
    public GetRoleHandler(RoleManager<FinanceManagerRole> roleManager,
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
    }

    public async Task<Result<RoleModel>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request);

            var roles = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == request.Id);

            return await Result<RoleModel>.SuccessAsync(
                                            _mapper.Map<RoleModel>(roles));
        });
    }
}
