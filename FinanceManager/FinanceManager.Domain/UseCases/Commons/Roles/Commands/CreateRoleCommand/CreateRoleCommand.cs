using FinanceManager.Domain.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Domain.UseCases.Commons.Roles.Commands.CreateRoleCommand;

public class CreateRoleCommand : IRequest<IResult>
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
}
