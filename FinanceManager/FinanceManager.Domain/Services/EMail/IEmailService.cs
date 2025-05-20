using FinanceManager.Domain.Models.Requests;

namespace FinanceManager.Domain.Services.Email;

public interface IEmailService
{
    Task SendAsync(MailRequest request);
}
