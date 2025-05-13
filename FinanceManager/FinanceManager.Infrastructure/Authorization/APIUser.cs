using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Authorization;

public class APIUser : IdentityUser
{
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}
