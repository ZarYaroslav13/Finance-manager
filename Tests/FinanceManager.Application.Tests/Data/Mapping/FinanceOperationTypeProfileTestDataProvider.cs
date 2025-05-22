using FinanceManager.Domain.Models;

namespace FinanceManager.Application.Tests.Data.Mapping;

public static class FinanceOperationTypeProfileTestDataProvider
{
    public static IEnumerable<object[]> DomainFinanceOperationTypeModel { get; } = new List<object[]>
    {
        new object[]
        {
            new FinanceOperationTypeModel()
            {
                Id = Guid.Parse("1"),
                Name = "Name",
                Description = "Description",
                EntryType = FinanceManager.Infrastructure.Models.EntryType.Income,
                WalletId = Guid.Parse("1"),
                WalletName = "WalletName"
            }
        }
    };
}
