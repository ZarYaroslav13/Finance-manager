using FinanceManager.Application.Models;

namespace FinanceManager.Application.Tests.Data.Mapping;

public static class FinanceOperationProfileTestDataProvider
{
    public static IEnumerable<object[]> FinanceOperation { get; } = new List<object[]>
    {
        new object[]
        {
            new IncomeDTO()
            {
                Id = Guid.Parse("3"), Amount = 713, Date = DateTime.Now, Type = new FinanceOperationTypeDTO()
                {
                    Id = Guid.Parse("1"), Name = "TypeName", Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Income, WalletId = Guid.Parse("2"), WalletName = "WalletName"
                }
            }
        },
         new object[]
        {
            new ExpenseDTO()
            {
                Id = Guid.Parse("3"), Amount = 713, Date = DateTime.Now, Type = new FinanceOperationTypeDTO()
                {
                    Id = Guid.Parse("1"), Name = "TypeName", Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, WalletId = Guid.Parse("2"), WalletName = "WalletName"
                }
            }
        }
    };
}
