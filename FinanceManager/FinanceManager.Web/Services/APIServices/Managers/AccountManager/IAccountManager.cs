using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdateAccountCommand;
using FinanceManager.Domain.UseCases.Accounts.Commands.Commands.UpdatePasswordAccountCommand;

namespace FinanceManager.Web.Services.APIServices.Managers.IAccountManager;

public interface IAccountManager : IManager
{
    Task<Domain.Wrapper.IResult> ChangePasswordAsync(ChangeUserPasswordCommand model);

    Task<Domain.Wrapper.IResult> UpdateProfileAsync(UpdateAccountCommand model);
}
