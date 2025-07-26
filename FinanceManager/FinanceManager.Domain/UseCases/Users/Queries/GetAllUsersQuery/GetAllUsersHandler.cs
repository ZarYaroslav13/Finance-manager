using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Domain.UseCases.Users.Queries.GetAllUsersQuery;

public class GetAllUsersHandler : BaseRequestHandler, IRequestHandler<GetAllUsersQuery, PaginatedResult<UserModel>>
{
    private readonly UserManager<FinanceManagerUser> _userManager;

    public GetAllUsersHandler(UserManager<FinanceManagerUser> userManager,
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task<PaginatedResult<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request);

            var users = await _userManager.Users.ToListAsync();
            var result = _mapper.Map<List<UserModel>>(users);

            return new PaginatedResult<UserModel>(true, result, new() { "Users retrived successfully!" });
        });
    }
}
