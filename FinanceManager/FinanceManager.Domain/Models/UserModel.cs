using FinanceManager.Domain.Models.Base;

namespace FinanceManager.Domain.Models;

public class UserModel : Model
{
    public string LastName { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public List<WalletModel> Wallets { get; set; } = new();

    public List<string> Roles { get; set; } = new();

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj))
            return false;

        UserModel user = (UserModel)obj;

        return FirstName == user.FirstName
               && LastName == user.LastName
               && Email == user.Email
               && AreEqualLists(Wallets, user.Wallets);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), FirstName, LastName, Email, GetHashCodeOfList(Wallets));
    }
}
