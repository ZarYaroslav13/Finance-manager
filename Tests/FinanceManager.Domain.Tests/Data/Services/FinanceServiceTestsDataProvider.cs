using FinanceManager.Domain.Models;
using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Domain.Tests.Data.Services;

public static class FinanceServiceTestsDataProvider
{
    public static List<FinanceOperationType> FinanceOperationTypes = new()
    {
        new FinanceOperationType()
                {
                    Id = Guid.Parse("1"),
                    Name = "Salary",
                    Description = "Monthly salary",
                    EntryType = EntryType.Income,
                    WalletId = Guid.Parse("1")
                },
        new FinanceOperationType()
                {
                    Id = Guid.Parse("2"),
                    Name = "Groceries",
                    Description = "Weekly groceries",
                    EntryType = EntryType.Expense,
                    WalletId = Guid.Parse("1")
                },
        new FinanceOperationType()
                {
                    Id = Guid.Parse("3"),
                    Name = "Rent",
                    Description = "Monthly rent payment",
                    EntryType = EntryType.Expense,
                    WalletId = Guid.Parse("1")
                }
    };

    public static List<List<FinanceOperation>> FinanceOperations = new()
    {
        new List<FinanceOperation>
        {
            new FinanceOperation() { Id = Guid.Parse("1"), Amount = 500, Date = new DateTime(2024, 1, 1), TypeId = FinanceOperationTypes[0].Id, Type = FinanceOperationTypes[0] },
            new FinanceOperation() { Id = Guid.Parse("2"), Amount = 100, Date = new DateTime(2024, 1, 2), TypeId = FinanceOperationTypes[0].Id, Type = FinanceOperationTypes[0] },
            new FinanceOperation() { Id = Guid.Parse("3"), Amount = 750, Date = new DateTime(2024, 1, 3), TypeId = FinanceOperationTypes[0].Id, Type = FinanceOperationTypes[0] },
            new FinanceOperation() { Id = Guid.Parse("4"), Amount = 120, Date = new DateTime(2024, 1, 4), TypeId = FinanceOperationTypes[0].Id, Type = FinanceOperationTypes[0] }
        },
        new List<FinanceOperation>
        {
            new FinanceOperation() { Id = Guid.Parse("1"), Amount = 500, Date = new DateTime(2024, 1, 1), TypeId = FinanceOperationTypes[1].Id, Type = FinanceOperationTypes[1] },
            new FinanceOperation() { Id = Guid.Parse("2"), Amount = 100, Date = new DateTime(2024, 1, 2), TypeId = FinanceOperationTypes[1].Id, Type = FinanceOperationTypes[1] },
            new FinanceOperation() { Id = Guid.Parse("3"), Amount = 750, Date = new DateTime(2024, 1, 3), TypeId = FinanceOperationTypes[1].Id, Type = FinanceOperationTypes[1] },
            new FinanceOperation() { Id = Guid.Parse("4"), Amount = 120, Date = new DateTime(2024, 1, 4), TypeId = FinanceOperationTypes[1].Id, Type = FinanceOperationTypes[1] }
        },
        new List<FinanceOperation>
        {
            new FinanceOperation() { Id = Guid.Parse("1"), Amount = 500, Date = new DateTime(2024, 1, 1), TypeId = FinanceOperationTypes[2].Id, Type = FinanceOperationTypes[2] },
            new FinanceOperation() { Id = Guid.Parse("2"), Amount = 100, Date = new DateTime(2024, 1, 2), TypeId = FinanceOperationTypes[2].Id, Type = FinanceOperationTypes[2] },
            new FinanceOperation() { Id = Guid.Parse("3"), Amount = 750, Date = new DateTime(2024, 1, 3), TypeId = FinanceOperationTypes[2].Id, Type = FinanceOperationTypes[2] },
            new FinanceOperation() { Id = Guid.Parse("4"), Amount = 120, Date = new DateTime(2024, 1, 4), TypeId = FinanceOperationTypes[2].Id, Type = FinanceOperationTypes[2] }
        }
    };

    public static IEnumerable<object[]> GetAllFinanceOperationTypesOfWalletTestData { get; } = new List<object[]>
    {
        new object[]
        {
            FinanceOperationTypes, 1
        }
    };

    public static IEnumerable<object[]> AddFinanceOperationTypeTestData { get; } = new List<object[]>
    {
        new object[]
        {
            new FinanceOperationTypeModel()
            {
                Id = Guid.Parse("0"),
                Description = "Description",
                EntryType = EntryType.Income,
                Name = "Name"
            },
            new FinanceOperationType()
            {
                Id = Guid.Parse("0"),
                Description = "Description",
                EntryType = EntryType.Income,
                Name = "Name"
            }
        }
    };

    public static IEnumerable<object[]> UpdateFinanceOperationTypeTestData { get; } = new List<object[]>
    {
        new object[]
        {
            new FinanceOperationTypeModel()
            {
                Id = Guid.Parse("1"),
                Description = "Description",
                EntryType = EntryType.Income,
                Name = "Name"
            },
            new FinanceOperationType()
            {
                Id = Guid.Parse("1"),
                Description = "Description",
                EntryType = EntryType.Income,
                Name = "Name"
            }
        }
    };

    public static IEnumerable<object[]> DeleteFinanceOperationTypeTestData { get; } = new List<object[]>
    {
        new object[]
        {
            1,
            new List<FinanceOperation>
            {
                new FinanceOperation() { Id = Guid.Parse("1"), Amount = 500, Date = new DateTime(2024, 1, 1), TypeId = FinanceOperationTypes[0].Id, Type = FinanceOperationTypes[0] },
                new FinanceOperation() { Id = Guid.Parse("2"), Amount = 100, Date = new DateTime(2024, 1, 2), TypeId = FinanceOperationTypes[1].Id, Type = FinanceOperationTypes[1] },
                new FinanceOperation() { Id = Guid.Parse("3"), Amount = 750, Date = new DateTime(2024, 1, 3), TypeId = FinanceOperationTypes[2].Id, Type = FinanceOperationTypes[2] }
            }
        }
    };

    public static IEnumerable<object[]> GetAllFinanceOperationsOfTypeTestData { get; } = new List<object[]>
    {
        new object[]
        {
            new List<FinanceOperation>()
            {
                new FinanceOperation() { Id = Guid.Parse("1"), Amount = 500, Date = new DateTime(2024, 1, 1), TypeId = FinanceOperationTypes[1].Id, Type = FinanceOperationTypes[1] },
                new FinanceOperation() { Id = Guid.Parse("2"), Amount = 100, Date = new DateTime(2024, 1, 2), TypeId = FinanceOperationTypes[1].Id, Type = FinanceOperationTypes[1] },
                new FinanceOperation() { Id = Guid.Parse("3"), Amount = 750, Date = new DateTime(2024, 1, 3), TypeId = FinanceOperationTypes[1].Id, Type = FinanceOperationTypes[1] },
                new FinanceOperation() { Id = Guid.Parse("4"), Amount = 120, Date = new DateTime(2024, 1, 4), TypeId = FinanceOperationTypes[1].Id, Type = FinanceOperationTypes[1] }
            },
            FinanceOperationTypes[1].Id
        }
    };

    public static IEnumerable<object[]> AddFinanceOperationTestData { get; } = new List<object[]>
    {
        new object[]
        {
            new IncomeModel(new FinanceOperationTypeModel()
            {
                Id = Guid.Parse("2"),
                Description = "Description",
                EntryType = EntryType.Income,
                Name = "Name"
            })
            {
                Id = Guid.Parse("0"), Amount = 100, Date = DateTime.MinValue
            },
            new FinanceOperation()
            {
                Id = Guid.Parse("0"), Amount = 100, Date = DateTime.MinValue, TypeId = Guid.Parse("2"), Type = new FinanceOperationType()
                {
                    Id = Guid.Parse("2"),
                    Description = "Description",
                    EntryType = EntryType.Income,
                    Name = "Name"
                }
            }
        }
    };

    public static IEnumerable<object[]> UpdateFinanceOperationTestData { get; } = new List<object[]>
    {
        new object[]
        {
            new IncomeModel(new FinanceOperationTypeModel()
            {
                Id = Guid.Parse("2"),
                Description = "Description",
                EntryType = EntryType.Income,
                Name = "Name"
            })
            {
                Id = Guid.Parse("1"), Amount = 100, Date = DateTime.MinValue
            },
            new FinanceOperation()
            {
                Id = Guid.Parse("1"), Amount = 100, Date = DateTime.MinValue, TypeId = Guid.Parse("2"), Type = new FinanceOperationType()
                {
                    Id = Guid.Parse("2"),
                    Description = "Description",
                    EntryType = EntryType.Income,
                    Name = "Name"
                }
            }
        }
    };

    public static IEnumerable<object[]> GetAllFinanceOperationOfWalletArgumentsAreLessThenZeroTestData { get; } = new List<object[]>
    {
        new object[] { -1, 1, 1 },
        new object[] { 0, 1, 1 },
        new object[] { 1, -1, 1 },
        new object[] { 1, 1, -1 }
    };

    public static IEnumerable<object[]> GetAllFinanceOperationOfWalletWithCountAndIndexTestData { get; } = new List<object[]>
    {
        new object[]
        {
            new List<FinanceOperation>
            {
                new FinanceOperation() { Id = Guid.Parse("1"), TypeId = Guid.Parse("1"), Type = new(){ Id = Guid.Parse("1"), WalletId = Guid.Parse("2") } },
                new FinanceOperation() { Id = Guid.Parse("2"), TypeId = Guid.Parse("2"), Type = new(){ Id = Guid.Parse("2"), WalletId = Guid.Parse("2") } },
                new FinanceOperation() { Id = Guid.Parse("3"), TypeId = Guid.Parse("3"), Type = new(){ Id = Guid.Parse("3"), WalletId = Guid.Parse("2") } }
            },
            2,
            0, 3
        },
        new object[]
        {
            new List<FinanceOperation>
            {
                new FinanceOperation() { Id = Guid.Parse("3"), TypeId = Guid.Parse("3"), Type = new(){ Id = Guid.Parse("3"), WalletId = Guid.Parse("2") } },
                new FinanceOperation() { Id = Guid.Parse("4"), TypeId = Guid.Parse("4"), Type = new(){ Id = Guid.Parse("4"), WalletId = Guid.Parse("2") } },
                new FinanceOperation() { Id = Guid.Parse("5"), TypeId = Guid.Parse("5"), Type = new(){ Id = Guid.Parse("5"), WalletId = Guid.Parse("2") } },
                new FinanceOperation() { Id = Guid.Parse("6"), TypeId = Guid.Parse("6"), Type = new(){ Id = Guid.Parse("6"), WalletId = Guid.Parse("2") } },
                new FinanceOperation() { Id = Guid.Parse("7"), TypeId = Guid.Parse("7"), Type = new(){ Id = Guid.Parse("7"), WalletId = Guid.Parse("2") } }
            },
            2,
            2, 0
        },
        new object[]
        {
            new List<FinanceOperation>
            {
                new FinanceOperation() { Id = Guid.Parse("3"), TypeId = Guid.Parse("3"), Type = new(){ Id = Guid.Parse("3"), WalletId = Guid.Parse("2") } },
                new FinanceOperation() { Id = Guid.Parse("4"), TypeId = Guid.Parse("4"), Type = new(){ Id = Guid.Parse("4"), WalletId = Guid.Parse("2") } },
                new FinanceOperation() { Id = Guid.Parse("5"), TypeId = Guid.Parse("5"), Type = new(){ Id = Guid.Parse("5"), WalletId = Guid.Parse("2") } }
            },
            2,
            2, 3
        },
    };

    public static IEnumerable<object[]> IdAreLessOrEqualZeroThrowsArgumentOutOfRangeExceptionTestData { get; } = new List<object[]>
    {
        new object[]{ -1, -1 },
        new object[]{ -1, 1 },
        new object[]{ 1, -1 },
        new object[]{ 0, 0 },
        new object[]{ 1, 0 },
        new object[]{ 0, 1 },
        new object[]{ -1, 0 },
        new object[]{ 0, -1 },
    };
}
