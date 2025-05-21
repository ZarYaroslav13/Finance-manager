using AutoMapper;
using FinanceManager.Application.Extentions;
using FinanceManager.Application.Models.Base;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Users;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Users.Queries.GetAllUsersQuery;

public class GetAllUsersHandler : BaseRequestHandler, IRequestHandler<GetAllUsersQuery, PaginatedResult<UserDTO>>
{
    private readonly IUserService _userService;

    public GetAllUsersHandler(IUserService userService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<GetAllUsersHandler> logger) : base(currentUserService, mapper, logger)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task<PaginatedResult<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request);

            var response = await _userService.GetAllAsync();

            if (!response.Succeeded)
                return PaginatedResult<UserDTO>.Failure(response.Messages);

            var result = response.Data
                        .Select(_mapper.Map<UserDTO>)
                        .ToPaginatedList(request.pageNumber, request.take);
            result.Messages = response.Messages;

            return result;
        });
    }
}
