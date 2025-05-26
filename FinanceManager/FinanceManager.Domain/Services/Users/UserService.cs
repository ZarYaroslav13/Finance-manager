using System.Text;
using System.Text.Encodings.Web;
using AutoMapper;
using FinanceManager.Domain.API;
using FinanceManager.Domain.Authorization;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Models.Requests;
using FinanceManager.Domain.Modelsl;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Email;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Domain.Services.Users;

public class UserService : IUserService
{
    private readonly UserManager<FinanceManagerUser> _userManager;
    private readonly RoleManager<FinanceManagerRole> _roleManager;
    private readonly IEmailService _emailService;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMapper _mapper;

    public UserService(
            UserManager<FinanceManagerUser> userManager,
            IMapper mapper,
            RoleManager<FinanceManagerRole> roleManager,
            IEmailService mailService,
            ICurrentUserService currentUserService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _roleManager = roleManager;
        _emailService = mailService;
        _currentUserService = currentUserService;
    }

    public async Task<IResult<Guid>> ConfirmEmailAsync(Guid userId, string code)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        var result = await _userManager.ConfirmEmailAsync(user, code);
        if (result.Succeeded)
        {
            return await Result<Guid>.SuccessAsync(user.Id, $"Account Confirmed for {user.Email}. You can now use the /api/token endpoint to generate JWT.");
        }
        else
        {
            throw new Exception($"An error occurred while confirming {user.Email}");
        }
    }

    public async Task<IResult> ForgotPasswordAsync(string email, string origin)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
        {
            // Don't reveal that the user does not exist or is not confirmed
            return await Result.FailAsync("An Error has occurred!");
        }
        // For more information on how to enable account confirmation and password reset please
        // visit https://go.microsoft.com/fwlink/?LinkID=532713
        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var route = "users/reset";
        var endpointUri = new Uri(string.Concat($"{origin}/", route));
        var passwordResetURL = QueryHelpers.AddQueryString(endpointUri.ToString(), "Token", code);
        var mailRequest = new MailRequest
        {
            Body = string.Format("Please reset your password by <a href='{0}'>clicking here</a>.", HtmlEncoder.Default.Encode(passwordResetURL)),
            Subject = "Reset Password",
            To = email
        };
        BackgroundJob.Enqueue(() => _emailService.SendAsync(mailRequest));
        return await Result.SuccessAsync("Password Reset Mail has been sent to your authorized Email.");
    }

    public async Task<Result<List<UserModel>>> GetAllAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        var result = _mapper.Map<List<UserModel>>(users);

        return await Result<List<UserModel>>.SuccessAsync(result, "Users retrived successfully!");
    }

    public async Task<Result<UserModel>> GetAsync(Guid userId)
    {
        var user = await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
        var result = _mapper.Map<UserModel>(user);

        result.Roles = (await _userManager.GetRolesAsync(user)).ToList();

        return await Result<UserModel>.SuccessAsync(result);
    }

    public async Task<IResult<List<UserRoleModel>>> GetRolesAsync(Guid id)
    {
        var viewModel = new List<UserRoleModel>();
        var user = await _userManager.FindByIdAsync(id.ToString());
        var roles = await _roleManager.Roles.ToListAsync();

        foreach (var role in roles)
        {
            var userRolesViewModel = new UserRoleModel
            {
                RoleName = role.Name,
                RoleDescription = role.Description
            };

            if (await _userManager.IsInRoleAsync(user, role.Name))
            {
                viewModel.Add(userRolesViewModel);
            }
        }
        var result = viewModel.Select(_mapper.Map<UserRoleModel>).ToList();
        return await Result<List<UserRoleModel>>.SuccessAsync(result);
    }

    public async Task<IResult> RegisterAsync(UserModel model, string password)
    {
        var user = _mapper.Map<FinanceManagerUser>(model);

        var userWithSameEmail = await _userManager.FindByEmailAsync(user.Email);
        if (userWithSameEmail == null)
        {
            user.UserName = user.Email;

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, PolicyManager.CommonUserRole);

                var verificationUri = await SendVerificationEmail(user);
                var mailRequest = new MailRequest
                {
                    From = "mail@codewithmukesh.com",
                    To = user.Email,
                    Body = $"Please confirm your account by <a href='{verificationUri}'>clicking here</a>.",
                    Subject = "Confirm Registration"
                };
                BackgroundJob.Enqueue(() => _emailService.SendAsync(mailRequest));
                return await Result<Guid>.SuccessAsync(user.Id, $"User {user.UserName} Registered. Please check your Emailbox to verify!");
            }

            return await Result.FailAsync(result.Errors.Select(a => a.Description).ToList());
        }

        return await Result.FailAsync($"Email {user.UserName} is already registered.");
    }

    public async Task<IResult> ResetPasswordAsync(string email, string password, string token)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            // Don't reveal that the user does not exist
            return await Result.FailAsync("An Error has occured!");
        }

        var result = await _userManager.ResetPasswordAsync(user, token, password);
        if (result.Succeeded)
        {
            return await Result.SuccessAsync("Password Reset Successful!");
        }
        else
        {
            return await Result.FailAsync("An Error has occured!");
        }
    }

    public async Task<IResult> UpdateRolesAsync(Guid id, List<UserRoleModel> newRroles)
    {
        const string mainAdminEmail = "adminchick.FinanceManager@gmail.com";
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user.Email == mainAdminEmail)
        {
            return await Result.FailAsync("Not Allowed.");
        }

        var roles = await _userManager.GetRolesAsync(user);
        var selectedRoles = newRroles.Where(x => x.Selected).ToList();

        var currentUser = await _userManager.FindByIdAsync(_currentUserService.UserId);
        if (!await _userManager.IsInRoleAsync(currentUser, PolicyManager.AdminRole))
        {
            var tryToAddAdministratorRole = selectedRoles
                .Any(x => x.RoleName == PolicyManager.AdminRole);
            var userHasAdministratorRole = roles.Any(x => x == PolicyManager.AdminRole);
            if (tryToAddAdministratorRole && !userHasAdministratorRole || !tryToAddAdministratorRole && userHasAdministratorRole)
            {
                return await Result.FailAsync("Not Allowed to add or delete Administrator Role if you have not this role.");
            }
        }

        var result = await _userManager.RemoveFromRolesAsync(user, roles);
        result = await _userManager.AddToRolesAsync(user, selectedRoles.Select(y => y.RoleName));
        return await Result.SuccessAsync("Roles Updated");
    }

    public async Task<IResult> DeleteUserAsync(Guid id)
    {
        if (id == Guid.Empty)
            return await Result.FailAsync("Id must be specified");

        try
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user);

            return Result.Success("Deleted successfully!");
        }
        catch (Exception e)
        {
            return Result.Fail(e.Message);
        }
    }

    private async Task<string> SendVerificationEmail(FinanceManagerUser user)
    {
        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var verificationUri = QueryHelpers.AddQueryString(ApiEndpoints.Users.ConfirmEmail, "userId", user.Id.ToString());
        verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
        return verificationUri;
    }
}
