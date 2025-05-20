using AutoMapper;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Modelsl;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using MailKit;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Domain.Services.Users;

public class UserService : IUserService
{
    private readonly UserManager<FinanceManagerUser> _userManager;
    private readonly RoleManager<FinanceManagerRole> _roleManager;
    private readonly IMailService _mailService;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public UserService(
            UserManager<FinanceManagerUser> userManager,
            IMapper mapper,
            RoleManager<FinanceManagerRole> roleManager,
            IMailService mailService,
            ICurrentUserService currentUserService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _roleManager = roleManager;
        _mailService = mailService;
        _currentUserService = currentUserService;
    }

    public Task<IResult<string>> ConfirmEmailAsync(Guid userId, string code)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> ForgotPasswordAsync(string email, string origin)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> GetAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<IResult<UserRoleModel>> GetRolesAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> RegisterAsync(UserModel model, string password, string origin)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> ResetPasswordAsync(string email, string password, string token)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> UpdateRolesAsync(Guid id, List<UserRoleModel> roles)
    {
        throw new NotImplementedException();
    }
}
