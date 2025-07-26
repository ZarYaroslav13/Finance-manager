using AutoMapper;
using FinanceManager.Domain.API;
using FinanceManager.Domain.Models.Requests;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Services.Email;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Encodings.Web;

namespace FinanceManager.Domain.UseCases.Users.Commands.ForgotPasswordCommand;

public class ForgotPasswordHandler : BaseRequestHandler, IRequestHandler<ForgotPasswordCommand, IResult>
{
    private readonly UserManager<FinanceManagerUser> _userManager;
    private readonly IEmailService _emailService;

    public ForgotPasswordHandler(
           UserManager<FinanceManagerUser> userManager,
           IEmailService mailService,
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {

        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _emailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
    }

    public async Task<IResult> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                // Don't reveal that the user does not exist or is not confirmed
                return await Result.FailAsync("An Error has occurred!");
            }
            // For more information on how to enable account confirmation and password reset please
            // visit https://go.microsoft.com/fwlink/?LinkID=532713
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var passwordResetURL = QueryHelpers.AddQueryString(APIEndpoints.Users.ResetPassword, "Token", code);
            var mailRequest = new MailRequest
            {
                Body = string.Format("Please reset your password by <a href='{0}'>clicking here</a>.", HtmlEncoder.Default.Encode(passwordResetURL)),
                Subject = "Reset Password",
                To = request.Email
            };
            BackgroundJob.Enqueue(() => _emailService.SendAsync(mailRequest));
            return await Result.SuccessAsync("Password Reset Mail has been sent to your authorized Email.");
        });
    }
}
