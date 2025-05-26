using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Infrastructure.Models.Authorization;

public class FinanceManagerUser : IdentityUser<Guid>, IIdentityEntity
{
    public string LastName { get; set; } = "";

    public string FirstName { get; set; } = "";

    public List<Wallet>? Wallets { get; set; }

    public string RefreshToken { get; set; } = "";

    public DateTime RefreshTokenExpiryTime { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? LastModifiedOn { get; set; }
}
