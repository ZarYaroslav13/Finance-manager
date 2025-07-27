using AutoMapper;
using FinanceManager.Application.Models.Requests.Roles.Commands;
using FinanceManager.Domain.UseCases.Commons.Roles.Commands.CreateRoleCommand;
using FinanceManager.Domain.UseCases.Commons.Roles.Commands.UpdateRoleCommand;

namespace FinanceManager.Application.Mapping.Requests;

public class RolesRequestsProfile : Profile
{
    public RolesRequestsProfile()
    {
        CreateMap<CreateRoleRequest, CreateRoleCommand>();

        CreateMap<UpdateRoleRequest, UpdateRoleCommand>();
    }
}
