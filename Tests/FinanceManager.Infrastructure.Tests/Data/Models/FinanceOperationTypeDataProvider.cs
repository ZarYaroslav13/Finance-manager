using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Infrastructure.Tests.Data.Models;

public class FinanceOperationTypeDataProvider
{
    public static IEnumerable<object[]> MethodEqualsResultTrueData { get; } = new List<object[]>
    {
        new object[]
        {
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),},
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),}
        },
        new object[]
        {
            new FinanceOperationType(){
                Id =  Guid.Parse("1"),
                Description = "Description",
                EntryType = EntryType.Expense,
                FinanceOperations = EntitiesTestDataProvider.FinanceOperations
                    .Where(fo => fo.TypeId == Guid.Parse("1"))
                    .ToList(),
                Name = "Name",
                WalletId = Guid.Parse("2"),},
            new FinanceOperationType(){
                Id = Guid.Parse("1"),
                Description = "Description",
                EntryType = EntryType.Expense,
                FinanceOperations = EntitiesTestDataProvider.FinanceOperations
                    .Where(fo => fo.TypeId == Guid.Parse("1"))
                    .ToList(),
                Name = "Name",
                WalletId = Guid.Parse("2")}
        },
        new object[]
        {
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, Name = "Name"},
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, Name = "Name"}
        },
        new object[]
        {
            new FinanceOperationType(){ Id = Guid.Parse("1"), EntryType = EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),},
            new FinanceOperationType(){ Id = Guid.Parse("1"), EntryType = EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),}
        },
        new object[]
        {
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, WalletId = Guid.Parse("2"),},
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, WalletId = Guid.Parse("2"),}
        }
    };

    public static IEnumerable<object[]> MethodEqualsResultFalseData { get; } = new List<object[]>
    {
        new object[]
        {
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description1", EntryType = EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),},
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),}
        },
        new object[]
        {
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, Name = "Name1", WalletId = Guid.Parse("2"),},
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),}
        },
        new object[]
        {
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),},
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Income, Name = "Name", WalletId = Guid.Parse("2"),}
        },
        new object[]
        {
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),},
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, Name = "Name", WalletId = Guid.Parse("3"),}
        },
        new object[]
        {
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),},
            null
        },
        new object[]
        {
            new FinanceOperationType(){ Id = Guid.Parse("1"), Description = "Description", EntryType = EntryType.Expense, FinanceOperations = null, Name = "Name", WalletId = Guid.Parse("2"),},
            new Wallet()
        }
    };
}
