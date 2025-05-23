using System.ComponentModel.DataAnnotations;
using FinanceManager.Domain.Wrapper;
using MediatR;

namespace FinanceManager.Application.UseCases.Roles.Commands.CreateRoleCommand;

public class CreateRoleCommand : IRequest<IResult>
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }
}
