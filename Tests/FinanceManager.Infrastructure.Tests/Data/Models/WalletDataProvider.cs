using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Models.Authorization;

namespace FinanceManager.Infrastructure.Tests.Data.Models;

public class WalletDataProvider
{
    public static IEnumerable<object[]> MethodEqualsResultTrueData { get; } = new List<object[]>
    {
        new object[]
        {
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes },
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes }
        },
        new object[]
        {
            new Wallet() { Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes },
            new Wallet() { Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes }
        },
        new object[]
        {
            new Wallet() { Id = Guid.Parse("1"), Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes },
            new Wallet() { Id = Guid.Parse("1"), Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes }
        },
        new object[]
        {
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes },
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes }
        },
        new object[]
        {
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, FinanceOperationTypes = financeOperationTypes },
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, FinanceOperationTypes = financeOperationTypes }
        },
        new object[]
        {
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser()},
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser()}
        }
    };

    public static IEnumerable<object[]> MethodEqualsResultFalseData { get; } = new List<object[]>
    {
        new object[]
        {
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes },
            new Wallet() { Id = Guid.Parse("2"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes }
        },
        new object[]
        {
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes },
            new Wallet() { Id = Guid.Parse("1"), Name = "Name1", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes }
        },
        new object[]
        {
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 2000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes },
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes }
        },
        new object[]
        {
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes },
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("2"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes }
        },
        new object[]
        {
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes },
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser() }
        },
        new object[]
        {
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes },
            null
        },
        new object[]
        {
            new Wallet() { Id = Guid.Parse("1"), Name = "Name", Balance = 1000, UsertId = Guid.Parse("1"), User = new FinanceManagerUser(), FinanceOperationTypes = financeOperationTypes },
            new Wallet()
        }
    };

    private static List<FinanceOperationType> financeOperationTypes = EntitiesTestDataProvider
        .FinanceOperationTypes
        .Where(fot => fot.WalletId == Guid.Parse("1"))
        .ToList();
}
