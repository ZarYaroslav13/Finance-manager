using AutoMapper;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.UseCases.Commons.Bases;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Text;

namespace FinanceManager.Domain.UseCases.Users.Queries.ConfirmEmailQuery;

public class ConfirmEmailHandler : BaseRequestHandler, IRequestHandler<ConfirmEmailQuery, IResult>
{
    private readonly UserManager<FinanceManagerUser> _userManager;

    public ConfirmEmailHandler(UserManager<FinanceManagerUser> userManager,
        IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(unitOfWork, currentUserService, mapper, logger)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task<IResult> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            request.Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code));
            var result = await _userManager.ConfirmEmailAsync(user, request.Code);
            if (result.Succeeded)
            {
                return await Result<Guid>.SuccessAsync(user.Id, $"Account Confirmed for {user.Email}. You can now use the /api/token endpoint to generate JWT.");
            }
            else
            {
                throw new Exception($"An error occurred while confirming {user.Email}");
            }
        });
    }
}
