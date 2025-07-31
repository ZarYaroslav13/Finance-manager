using AutoMapper;
using FinanceManager.Domain.API;
using FinanceManager.Domain.Authorization;
using FinanceManager.Domain.Models.Requests;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Email;
using FinanceManager.Domain.UseCases.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Text;

namespace FinanceManager.Domain.UseCases.Commons.Users.Commands.RegisterCommand;

public class RegisterHandler : BaseRequestHandler, IRequestHandler<RegisterCommand, IResult>
{
    private const bool UseEmailVerification = false;

    private readonly UserManager<FinanceManagerUser> _userManager;
    private readonly IEmailService _emailService;

    public RegisterHandler(
           UserManager<FinanceManagerUser> userManager,
           IEmailService mailService,
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {

        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _emailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
    }

    public async Task<IResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            var user = _mapper.Map<FinanceManagerUser>(request);

            var userWithSameEmail = await _userManager.FindByEmailAsync(user.Email);
            if (userWithSameEmail == null)
            {
                user.UserName = user.Email;

                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    var updateResult = await UpdateOtherTables(user);

                    if (!updateResult.Succeeded)
                        return updateResult;


                    if (UseEmailVerification)
                    {
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

                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);

                    return await Result<Guid>.SuccessAsync(user.Id, $"User {user.UserName} Registered!");
                }

                return await Result.FailAsync(result.Errors.Select(a => a.Description).ToList());
            }

            return await Result.FailAsync($"Email {user.UserName} is already registered.");
        });
    }

    public async Task<IResult> UpdateOtherTables(FinanceManagerUser user)
    {
        try
        {
            await _userManager.AddToRoleAsync(user, PolicyManager.CommonUserRole);

            _unitOfWork.GetRepository<UserPreference>().Insert(new() { UserId = user.Id });

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
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
        var verificationUri = QueryHelpers.AddQueryString(APIEndpoints.Users.ConfirmEmail, "userId", user.Id.ToString());
        verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
        return verificationUri;
    }
}
