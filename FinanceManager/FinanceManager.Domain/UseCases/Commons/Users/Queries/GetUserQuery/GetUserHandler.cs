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

namespace FinanceManager.Domain.UseCases.Commons.Users.Queries.GetUserQuery;

public class GetUserHandler : BaseRequestHandler, IRequestHandler<GetUserQuery, Result<UserModel>>
{
    private readonly UserManager<FinanceManagerUser> _userManager;
    private readonly RoleManager<FinanceManagerRole> _roleManager;

    public GetUserHandler(
           UserManager<FinanceManagerUser> userManager,
           RoleManager<FinanceManagerRole> roleManager,
           IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
    }

    public async Task<Result<UserModel>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            CheckIsUserHaveAccesToResourse(request, _currentUserService.UserId == request.Id.ToString());

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.Id);
            var result = _mapper.Map<UserModel>(user);

            result.Roles = (await _userManager.GetRolesAsync(user)).ToList();

            return await Result<UserModel>.SuccessAsync(result);
        });
    }
}
