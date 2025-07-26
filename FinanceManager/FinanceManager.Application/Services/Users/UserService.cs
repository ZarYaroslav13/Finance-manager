using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Base;
using FinanceManager.Application.Models.Requests.Users.Commands;
using FinanceManager.Domain.UseCases.Users.Commands.DeleteAccountByIdCommand;
using FinanceManager.Domain.UseCases.Users.Commands.ForgotPasswordCommand;
using FinanceManager.Domain.UseCases.Users.Commands.RegisterCommand;
using FinanceManager.Domain.UseCases.Users.Commands.ResetPasswordCommand;
using FinanceManager.Domain.UseCases.Users.Commands.UpdateUserRolesCommand;
using FinanceManager.Domain.UseCases.Users.Queries.ConfirmEmailQuery;
using FinanceManager.Domain.UseCases.Users.Queries.GetAllUsersQuery;
using FinanceManager.Domain.UseCases.Users.Queries.GetUserQuery;
using FinanceManager.Domain.UseCases.Users.Queries.GetUserRolesQuery;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.Services.Users;

public class UserService : BaseService, IUserService
{
    public UserService(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }


    public async Task<IResult<List<RoleDTO>>> GetUserRolesAsync(Guid id)
    {
        var result = await _mediator.Send(new GetUserRolesQuery() { UserId = id });

        return _mapper.Map<Result<List<RoleDTO>>>(result);
    }

    public async Task<IResult> UpdateUserRolesAsync(UpdateUserRolesRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<UpdateUserRolesCommand>(request));

        return result;
    }

    public async Task<PaginatedResult<UserDTO>> GetAllAsync(int pageNumber, int pageSize)
    {
        var result = (await _mediator.Send(new GetAllUsersQuery() { PageNumber = pageNumber, PageSize = pageNumber }));

        return _mapper.Map<PaginatedResult<UserDTO>>(result);
    }

    public async Task<Result<UserDTO>> GetAsync(Guid userId)
    {
        var result = await _mediator.Send(new GetUserQuery() { Id = userId });

        return _mapper.Map<Result<UserDTO>>(result);
    }

    public async Task<IResult> RegisterAsync(RegisterRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<RegisterCommand>(request));

        return result;
    }

    public async Task<IResult<Guid>> ConfirmEmailAsync(Guid userId, string code)
    {
        var result = await _mediator.Send(new ConfirmEmailQuery() { UserId = userId, Code = code });

        return result;
    }

    public async Task<IResult> ForgotPasswordAsync(ForgotPasswordRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<ForgotPasswordCommand>(request));

        return result;
    }

    public async Task<IResult> ResetPasswordAsync(ResetPasswordRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<ResetPasswordCommand>(request));

        return result;
    }

    public async Task<IResult> DeleteUserAsync(Guid id)
    {
        var result = await _mediator.Send(new DeleteUserCommand() { Id = id });

        return result;
    }
}
