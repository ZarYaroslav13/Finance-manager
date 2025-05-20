using AutoMapper;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Domain.Services.Accounts;

public class AccountService : IAccountService
{
    private readonly UserManager<FinanceManagerUser> _userManager;
    private readonly SignInManager<FinanceManagerUser> _signInManager;
    private readonly IMapper _mapper;

    public AccountService(UserManager<FinanceManagerUser> userManager, SignInManager<FinanceManagerUser> signInManager, IMapper mapper)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IResult> UpdateAccountAsync(AccountModel updatedAccount)
    {
        ArgumentNullException.ThrowIfNull(updatedAccount);

        if (updatedAccount.Id == Guid.Empty)
            throw new ArgumentException(nameof(updatedAccount));

        var userWithSameEmail = await _userManager.FindByEmailAsync(updatedAccount.Email);
        if (userWithSameEmail == null || userWithSameEmail.Id == updatedAccount.Id)
        {
            var user = await _userManager.FindByIdAsync(updatedAccount.Id.ToString());

            user = _mapper.Map<FinanceManagerUser>(updatedAccount);

            var identityResult = await _userManager.UpdateAsync(user);
            var errors = identityResult.Errors.Select(e => e.Description).ToList();
            await _signInManager.RefreshSignInAsync(user);
            return identityResult.Succeeded ? await Result.SuccessAsync() : await Result.FailAsync(errors);
        }
        else
        {
            return await Result.FailAsync($"Email {userWithSameEmail.Email} is already used.");
        }
    }

    public async Task<IResult> UpdatePasswordAsync(Guid id, string oldPassword, string newPassword)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(oldPassword);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(newPassword);

        if (id == Guid.Empty)
            throw new ArgumentException(nameof(id));

        var user = await this._userManager.FindByIdAsync(id.ToString());
        if (user == null)
        {
            return await Result.FailAsync("User Not Found.");
        }

        var identityResult = await this._userManager.ChangePasswordAsync(
            user,
            oldPassword,
            newPassword);
        var errors = identityResult.Errors.Select(e => e.Description).ToList();
        return identityResult.Succeeded ? await Result.SuccessAsync() : await Result.FailAsync(errors);
    }
}
