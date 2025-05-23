using AutoMapper;
using FinanceManager.Application.Models;
using FinanceManager.Application.UseCases.Roles.Commands.CreateRoleCommand;
using FinanceManager.Application.UseCases.Roles.Commands.UpdateRoleCommand;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.UseCases.Commons.Mapping;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<RoleDTO, RoleModel>().ReverseMap();

        CreateMap<CreateRoleCommand, RoleModel>();

        CreateMap<UpdateRoleCommand, RoleModel>();
    }
}
