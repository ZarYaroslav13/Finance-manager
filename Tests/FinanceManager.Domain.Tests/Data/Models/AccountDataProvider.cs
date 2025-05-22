using FinanceManager.Domain.Models;

namespace FinanceManager.Domain.Tests.Data.Models;

public class AccountDataProvider
{
    public static IEnumerable<object[]> MethodEqualsResultTrueData { get; } = new List<object[]>
    {
        new object[]
        {
            new UserModel(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", Wallets = new()},
            new UserModel(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", Wallets = new()}
        },
        new object[]
        {
            new UserModel(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName"},
            new UserModel(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName"}
        },
        new object[]
        {
            new UserModel(){ Id = Guid.Parse("1"), FirstName = "FirstName", Email = "Email"},
            new UserModel(){ Id = Guid.Parse("1"), FirstName = "FirstName", Email = "Email"}
        }
    };

    public static IEnumerable<object[]> MethodEqualsResultFalseData { get; } = new List<object[]>
    {
        new object[]
        {
            new UserModel(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"},
            new UserModel(){ Id = Guid.Parse("2"), LastName = "LastName", FirstName = "FirstName", Email = "Email"}
        },
        new object[]
        {
            new UserModel(){ Id = Guid.Parse("1"), FirstName = "FirstName", Email = "Email"},
            new UserModel(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"}
        },
        new object[]
        {
            new UserModel(),
            new UserModel(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"}
        },
        new object[]
        {
            new UserModel(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"},
            new UserModel()
        },
        new object[]
        {
            new UserModel(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"},
            new UserModel(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", }
        },
        new object[]
        {
            new UserModel(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"},
            null
        },
        new object[]
        {
            new UserModel(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email"},
            new WalletModel()
        }
    };
}
