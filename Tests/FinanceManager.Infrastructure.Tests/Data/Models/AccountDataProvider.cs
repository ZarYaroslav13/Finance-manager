using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Models.Authorization;

namespace FinanceManager.Infrastructure.Tests.Data.Models;

public class FinanceManagerUserDataProvider
{
    public static IEnumerable<object[]> MethodEqualsResultTrueData { get; } = new List<object[]>
    {
        new object[]
        {
            new FinanceManagerUser(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", },
            new FinanceManagerUser(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", }
        },
        new object[]
        {
            new FinanceManagerUser(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", },
            new FinanceManagerUser(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", }
        },
        new object[]
        {
            new FinanceManagerUser(){ Id = Guid.Parse("1"), FirstName = "FirstName", Email = "Email", },
            new FinanceManagerUser(){ Id = Guid.Parse("1"), FirstName = "FirstName", Email = "Email", }
        }
    };

    public static IEnumerable<object[]> MethodEqualsResultFalseData { get; } = new List<object[]>
    {
        new object[]
        {
            new FinanceManagerUser(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", },
            new FinanceManagerUser(){ Id = Guid.Parse("2"), LastName = "LastName", FirstName = "FirstName", Email = "Email", }
        },
        new object[]
        {
            new FinanceManagerUser(){ Id = Guid.Parse("1"), FirstName = "FirstName", Email = "Email", },
            new FinanceManagerUser(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", }
        },
        new object[]
        {
            new FinanceManagerUser(),
            new FinanceManagerUser(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", }
        },
        new object[]
        {
            new FinanceManagerUser(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", },
            new FinanceManagerUser()
        },
        new object[]
        {
            new FinanceManagerUser(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", },
            new FinanceManagerUser(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", }
        },
        new object[]
        {
            new FinanceManagerUser(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", },
            null
        },
        new object[]
        {
            new FinanceManagerUser(){ Id = Guid.Parse("1"), LastName = "LastName", FirstName = "FirstName", Email = "Email", },
            new Wallet()
        }
    };
}
