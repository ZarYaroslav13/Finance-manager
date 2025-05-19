using FinanceManager.Infrastructure.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Authorization;

public class APIUser : IdentityUser, IIdentityEntity
{
    public string LastName { get; set; } = "";

    public string FirstName { get; set; } = "";

    public override string? UserName { get => FirstName; set => FirstName = value; }

    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public DateTime CreatedOn { get; set; }

    public DateTime? LastModifiedOn { get; set; }

}
