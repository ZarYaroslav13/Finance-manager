using FinanceManager.Application.Models;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.Tests.Data.Models;

public static class WalletDTOTestDataProvider
{
    public static IEnumerable<object[]> MethodEqualsResultTrueData { get; } = new List<object[]>
    {
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new(), Incomes = new()},
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new(), Incomes = new()}
        },
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new()},
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new()}
        },
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), Incomes = new()},
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), Incomes = new()}
        },
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1"), FinanceOperationTypes = new(), Incomes = new()},
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1"), FinanceOperationTypes = new(), Incomes = new()}
        },
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, Expenses = new(), FinanceOperationTypes = new(), Incomes = new()},
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, Expenses = new(), FinanceOperationTypes = new(), Incomes = new()}
        },
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new(), Incomes = new()},
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new(), Incomes = new()}
        },
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new(), Incomes = new()},
            new WalletDTO(){ Id = Guid.Parse("1"), Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new(), Incomes = new()}
        },
        new object[]
        {
            new WalletDTO(){ Name = "Name", Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new(), Incomes = new()},
            new WalletDTO(){ Name = "Name", Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new(), Incomes = new()}
        }
    };

    public static IEnumerable<object[]> MethodEqualsResultFalseData { get; } = new List<object[]>
    {
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1")},
            new WalletDTO(){ Id = Guid.Parse("2"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1")}
        },
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1")},
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name1", Balance = 100, AccountId = Guid.Parse("1")}
        },
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1")},
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 200, AccountId = Guid.Parse("1")}
        },
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1")},
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("2")}
        },
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "fName", Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new(), Incomes = new()},
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "fName", Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new() { new FinanceOperationTypeDTO()}, Incomes = new()}
        },
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new(), Incomes = new()},
            null
        },
        new object[]
        {
            new WalletDTO(){ Id = Guid.Parse("1"), Name = "Name", Balance = 100, AccountId = Guid.Parse("1"), Expenses = new(), FinanceOperationTypes = new(), Incomes = new()},
            new UserModel()
        }
    };
}
