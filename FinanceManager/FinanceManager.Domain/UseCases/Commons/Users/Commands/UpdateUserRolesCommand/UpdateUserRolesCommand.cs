using FinanceManager.Domain.DataAnnotations.Attributes;
using FinanceManager.Domain.Modelsl;
using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Commons.Users.Commands.UpdateUserRolesCommand;

public class UpdateUserRolesCommand : IRequest<IResult>
{
    [GuidRequired]
    public Guid UserId;

    [Required]
    public List<UserRoleModel> NewRoles;
}
