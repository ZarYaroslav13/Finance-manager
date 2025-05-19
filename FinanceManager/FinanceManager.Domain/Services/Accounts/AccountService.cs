using System.Net.Mail;
using AutoMapper;
using FinanceManager.Domain.Authorization;
using FinanceManager.Domain.Models;
using FinanceManager.Domain.Services.Admins;
using FinanceManager.Infrastructure.Models.Authorization;
using FinanceManager.Infrastructure.Repository;
using FinanceManager.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Domain.Services.Accounts;

public class AccountService : BaseService, IAccountService
{
    private const string _passwordErasor = "-";
    private readonly UserManager<FinanceManagerUser> _userManager;

    public AccountService(UserManager<FinanceManagerUser> userManager, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    //public async Task<List<AccountModel>> GetAccountsAsync(string userRole, int skip = 0, int take = 0)
    //{

    //    if (userRole != PolicyManager.AdminRole)
    //        throw new UnauthorizedAccessException();

    //    if (skip < 0 || take < 0)
    //        throw new ArgumentException("skip and take arguments cannot be less 0");

    //    var accounts = (await _repository.GetAllAsync(skip: skip, take: take))
    //            .Select(_mapper.Map<AccountModel>)
    //            .ToList();

    //    accounts.ForEach(a => a.Password = _passwordErasor);

    //    return accounts;
    //}

    //public async Task<AccountModel> AddAccountAsync(AccountModel account)
    //{
    //    ArgumentNullException.ThrowIfNull(account);

    //    if (account.Id != 0)
    //        throw new ArgumentException(nameof(account));

    //    await CanTakeThisEmailAsync(account.Id, account.Email);

    //    account.Password = _passwordCoder.ComputeSHA256Hash(account.Password);

    //    var result = _repository.Insert(_mapper.Map<Account>(account));
    //    await _unitOfWork.SaveChangesAsync();

    //    return _mapper.Map<AccountModel>(result);
    //}

    public async Task<AccountModel> UpdateAccountAsync(AccountModel updatedAccount)
    {
        ArgumentNullException.ThrowIfNull(updatedAccount);

        if (updatedAccount.Id == Guid.Empty)
            throw new ArgumentException(nameof(updatedAccount));

        var userWithSameEmail = await _userManager.FindByEmailAsync(updatedAccount.Email);
        if (userWithSameEmail == null || userWithSameEmail.Id == updatedAccount.Id)
        {
            var user = await _userManager.FindByIdAsync(updatedAccount.Id);
            if (user == null)
            {
                return await Result.FailAsync(_localizer["User Not Found."]);
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (request.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, request.PhoneNumber);
            }
            var identityResult = await _userManager.UpdateAsync(user);
            var errors = identityResult.Errors.Select(e => _localizer[e.Description].ToString()).ToList();
            await _signInManager.RefreshSignInAsync(user);
            return identityResult.Succeeded ? await Result.SuccessAsync() : await Result.FailAsync(errors);
        }
        else
        {
            return await Result.FailAsync(string.Format(_localizer["Email {0} is already used."], request.Email));
        }

        var account = await _repository.GetByIdAsync(updatedAccount.Id);

        updatedAccount.Password = account.Password;

        var repoResult = _repository.Update(
                _mapper.Map<Account>(updatedAccount));

        repoResult.Password = _passwordErasor;

        var result = _mapper.Map<AccountModel>(repoResult);
        await _unitOfWork.SaveChangesAsync();

        return result;
    }

    public async Task<AccountModel> UpdatePasswordAsync(int id, string oldPassword, string newPassword)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(oldPassword);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(newPassword);

        if (id == 0)
            throw new ArgumentException(nameof(id));

        var account = await _repository.GetByIdAsync(id);

        if (account.Password != _passwordCoder.ComputeSHA256Hash(oldPassword))
            throw new UnauthorizedAccessException("Incorrect old password.");

        account.Password = _passwordCoder.ComputeSHA256Hash(newPassword);

        var repoResult = _repository.Update(
                _mapper.Map<Account>(account));

        var result = _mapper.Map<AccountModel>(repoResult);
        await _unitOfWork.SaveChangesAsync();

        result.Password = _passwordErasor;

        return result;
    }

    //public void DeleteAccountWithId(int id)
    //{
    //    _repository.Delete(id);

    //    _unitOfWork.SaveChangesAsync();
    //}

    //public async Task<AccountModel> TrySignInAsync(string email, string password)
    //{
    //    ArgumentNullException.ThrowIfNullOrWhiteSpace(email);
    //    ArgumentNullException.ThrowIfNullOrWhiteSpace(password);

    //    string encodedPassword = _passwordCoder.ComputeSHA256Hash(password);

    //    var account = (await _repository
    //        .GetAllAsync(filter: a => a.Email == email
    //                                && a.Password == encodedPassword))
    //        .FirstOrDefault();

    //    var result = _mapper.Map<AccountModel>(account); ;

    //    return result;
    //}

    //public bool IsItEmail(string emailAddress)
    //{
    //    try
    //    {
    //        MailAddress m = new(emailAddress);

    //        return true;
    //    }
    //    catch (FormatException)
    //    {
    //        return false;
    //    }
    //}

    //public async Task<bool> CanTakeThisEmailAsync(int id, string emailAddress)
    //{
    //    if (!IsItEmail(emailAddress))
    //    {
    //        throw new FormatException("Email format is incorrect!");
    //    }

    //    var async = await _repository.GetAllAsync();

    //    if (async.Any(a => a.Email == emailAddress && a.Id != id))
    //    {
    //        throw new ArgumentException("An account with this email already exist!");
    //    }

    //    return true;
    //}
}
