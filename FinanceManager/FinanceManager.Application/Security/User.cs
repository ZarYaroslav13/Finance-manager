 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Security;

public class User
{
    public static string AuthenticationType { get; } = "FinanceManager";

    public string Email { get; set; }
    public string Password { get; set; } = "";
    public int Id { get; set; }
    public List<string> Roles { get; set; } = new();

    public ClaimsPrincipal ToClaimsPrincipal() => new(new ClaimsIdentity(new Claim[]
    {
        new (ClaimTypes.Name, Email),
        new (ClaimTypes.Hash, Password),
        new (nameof(Id), Id.ToString())
    }.Concat(Roles.Select(r => new Claim(ClaimTypes.Role, r)).ToArray()),
    AuthenticationType));

    public static User FromClaimsPrincipal(ClaimsPrincipal principal) => new()
    {
        Email = principal.FindFirst(ClaimTypes.Name)?.Value ?? "",
        Password = principal.FindFirst(ClaimTypes.Hash)?.Value ?? "",
        Id = Convert.ToInt32(principal.FindFirst(nameof(Id))?.Value),
        Roles = principal.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList()
    };
}
