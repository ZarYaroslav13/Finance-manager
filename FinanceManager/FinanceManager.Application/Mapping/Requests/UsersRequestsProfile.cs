using AutoMapper;
using FinanceManager.Application.Models.Requests.Users.Commands;
using FinanceManager.Application.Models.Requests.Users.Queries;
using FinanceManager.Domain.UseCases.Commons.Users.Commands.ForgotPasswordCommand;
using FinanceManager.Domain.UseCases.Commons.Users.Commands.RegisterCommand;
using FinanceManager.Domain.UseCases.Commons.Users.Commands.ResetPasswordCommand;
using FinanceManager.Domain.UseCases.Commons.Users.Commands.UpdateUserRolesCommand;
using FinanceManager.Domain.UseCases.Commons.Users.Queries.GetAllUsersQuery;

namespace FinanceManager.Application.Mapping.Requests;

public class UsersRequestsProfile : Profile
{
    public UsersRequestsProfile()
    {
        CreateMap<GetAllUsersRequest, GetAllUsersQuery>();

        CreateMap<ForgotPasswordRequest, ForgotPasswordCommand>();
        CreateMap<RegisterRequest, RegisterCommand>();
        CreateMap<ResetPasswordRequest, ResetPasswordCommand>();
        CreateMap<UpdateUserRolesRequest, UpdateUserRolesCommand>();
    }
}
