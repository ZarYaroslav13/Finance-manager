using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.Models.Requests.Roles.Commands;
using FinanceManager.Domain.UseCases.Commons.Roles.Commands.CreateRoleCommand;
using FinanceManager.Domain.UseCases.Commons.Roles.Commands.DeleteRoleCommand;
using FinanceManager.Domain.UseCases.Commons.Roles.Commands.UpdateRoleCommand;
using FinanceManager.Domain.UseCases.Commons.Roles.Queries.GetAllRolesQuery;
using FinanceManager.Domain.UseCases.Commons.Roles.Queries.GetRoleQuery;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.Services.Roles;

public class RoleService : BaseService, IRoleService
{
    public RoleService(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    public async Task<Result<List<RoleDTO>>> GetAllAsync()
    {
        var result = await _mediator.Send(new GetAllRolesQuery());

        return _mapper.Map<Result<List<RoleDTO>>>(result);
    }

    public async Task<Result<RoleDTO>> GetByIdAsync(Guid id)
    {
        var result = await _mediator.Send(new GetRoleQuery() { Id = id });

        return _mapper.Map<Result<RoleDTO>>(result);
    }

    public async Task<IResult> AddAsync(CreateRoleRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<CreateRoleCommand>(request));

        return result;
    }

    public async Task<IResult> UpdateAsync(UpdateRoleRequest request)
    {
        var result = await _mediator.Send(_mapper.Map<UpdateRoleCommand>(request));

        return result;
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var result = await _mediator.Send(new DeleteRoleCommand() { Id = id });

        return result;
    }
}
