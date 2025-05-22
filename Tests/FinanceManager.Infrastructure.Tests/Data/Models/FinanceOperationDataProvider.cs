using FinanceManager.Infrastructure.Models;

namespace FinanceManager.Infrastructure.Tests.Data.Models;

public class FinanceOperationDataProvider
{
    public static IEnumerable<object[]> MethodEqualsResultTrueData { get; } = new List<object[]>
    {
        new object[]
        {
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            },
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            }
        },
        new object[]
        {
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3")
            },
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3")
            }
        },
        new object[]
        {
            new FinanceOperation(){
                Amount = 1000,
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            },
            new FinanceOperation(){
                Amount = 1000,
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            }
        },
        new object[]
        {
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            },
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            }
        },
        new object[]
        {
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            },
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            }
        }
    };

    public static IEnumerable<object[]> MethodEqualsResultFalseData { get; } = new List<object[]>
    {
        new object[]
        {
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            },
            new FinanceOperation(){
                Id = Guid.Parse("2"),
                Amount = 1000,
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            }
        },
        new object[]
        {
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            },
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 2000,
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            }
        },
        new object[]
        {
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            },
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                Date =  DateTime.MaxValue,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            }
        },
        new object[]
        {
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            },
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                Date =  DateTime.MinValue,
                TypeId = Guid.Parse("4"),
                Type = DBFiller.FinanceOperationTypes.FirstOrDefault(fo => fo.Id == Guid.Parse("4"))
            }
        },
        new object[]
        {
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            },
            null
        },
        new object[]
        {
            new FinanceOperation(){
                Id = Guid.Parse("1"),
                Amount = 1000,
                TypeId = Guid.Parse("3"),
                Type = randomFinanceOperationType
            },
            new Wallet()
        }
    };

    private static FinanceOperationType randomFinanceOperationType = EntitiesTestDataProvider.FinanceOperationTypes.FirstOrDefault();
}
