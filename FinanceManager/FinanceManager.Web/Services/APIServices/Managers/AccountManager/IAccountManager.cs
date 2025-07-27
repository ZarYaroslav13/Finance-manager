using FinanceManager.Application.Models.Requests.Account.Commands;
using FinanceManager.Domain.UseCases.Commons.Accounts.Commands.ChangeUserPasswordCommand;
using FinanceManager.Domain.UseCases.Commons.Accounts.Commands.UpdateAccountCommand;

namespace FinanceManager.Web.Services.APIServices.Managers.IAccountManager;

public interface IAccountManager : IManager
{
    Task<Domain.Wrapper.IResult> UpdateProfileAsync(UpdateAccountRequest model);

    Task<Domain.Wrapper.IResult> ChangePasswordAsync(ChangeAccountPasswordRequest model);
}
