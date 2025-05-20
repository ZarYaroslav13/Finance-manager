using FinanceManager.Domain.Models.Requests;

namespace FinanceManager.Domain.Services.Email;

public interface IEmailService
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}
