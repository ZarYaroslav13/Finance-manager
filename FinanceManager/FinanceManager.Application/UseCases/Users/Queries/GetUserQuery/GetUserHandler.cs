using AutoMapper;
using FinanceManager.Application.Models.Base;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Users;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Users.Queries.GetUserQuery;

public class GetUserHandler : BaseRequestHandler, IRequestHandler<GetUserQuery, Result<UserDTO>>
{
    private readonly IUserService _userService;
    public GetUserHandler(IUserService userService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    public async Task<Result<UserDTO>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
               async () => await Task.FromResult(_currentUserService.UserId == request.Id.ToString()));

            var response = await _userService.GetAsync(request.Id);

            return _mapper.Map<Result<UserDTO>>(response);
        });
    }
}
