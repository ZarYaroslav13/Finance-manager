using System.Security.Claims;
using FinanceManager.Domain.Authorization;
using Microsoft.AspNetCore.Http;

namespace FinanceManager.Domain.Services.CurrentUserService;

public class CurrentUserService : ICurrentUserService
{
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        Roles = httpContextAccessor.HttpContext?.User?.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList();

        IsAdmin = Roles.Any(r => r == PolicyManager.AdminRole);

        Claims = httpContextAccessor.HttpContext?.User?.Claims.AsEnumerable().Select(item => new KeyValuePair<string, string>(item.Type, item.Value)).ToList();
    }

    public string UserId { get; }

    public List<string> Roles { get; }

    public bool IsAdmin { get; }

    public List<KeyValuePair<string, string>> Claims { get; set; }
}
