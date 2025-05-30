using AutoMapper;
using FinanceManager.Application.UseCases.Commons.Bases;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.Accounts;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Wrapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinanceManager.Application.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;

public class UpdateAccountCommandHandler : BaseRequestHandler, IRequestHandler<UpdateAccountCommand, IResult>
{
    private readonly IAccountService _accountService;

    public UpdateAccountCommandHandler(IAccountService accountService,
        ICurrentUserService currentUserService, IMapper mapper, ILogger<BaseRequestHandler> logger) : base(currentUserService, mapper, logger)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public async Task<IResult> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        return await HandleAsync(async () =>
        {
            await CheckIsUserHaveAccesToResourseAsync(request,
                async () => await Task.FromResult(request.Id.ToString() == _currentUserService.UserId));

            var result = await _accountService.UpdateAccountAsync(
                        _mapper.Map<UserModel>(request));

            return result;
        });
    }
}
