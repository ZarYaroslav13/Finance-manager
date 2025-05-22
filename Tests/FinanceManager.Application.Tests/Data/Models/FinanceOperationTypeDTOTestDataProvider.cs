using FinanceManager.Application.Models;
using FinanceManager.Domain.Models;

namespace FinanceManager.Application.Tests.Data.Models;

public static class FinanceOperationTypeDTOTestDataProvider
{
    public static IEnumerable<object[]> MethodEqualsResultTrueData { get; } = new List<object[]>
    {
        new object[]
        {
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"), WalletName = "WalletName"},
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"), WalletName = "WalletName"}
        },
        new object[]
        {
            new FinanceOperationTypeDTO(){
                Id = Guid.Parse("1"),
                Description = "Description",
                EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense,
                Name = "Name",
                WalletId = Guid.Parse("2")},
            new FinanceOperationTypeDTO(){
                Id = Guid.Parse("1"),
                Description = "Description",
                EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense,
                Name = "Name",
                WalletId = Guid.Parse("2")}
        },
        new object[]
        {
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name"},
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name"}
        },
        new object[]
        {
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),},
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),}
        },
        new object[]
        {
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, WalletId = Guid.Parse("2"),},
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, WalletId = Guid.Parse("2"),}
        }
    };

    public static IEnumerable<object[]> MethodEqualsResultFalseData { get; } = new List<object[]>
    {
        new object[]
        {
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description1", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),},
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),}
        },
        new object[]
        {
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name1", WalletId = Guid.Parse("2"),},
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),}
        },
        new object[]
        {
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),},
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Income, Name = "Name", WalletId = Guid.Parse("2"),}
        },
        new object[]
        {
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),},
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name", WalletId = Guid.Parse("3"),}
        },
        new object[]
        {
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2"),},
            null
        },
        new object[]
        {
            new FinanceOperationTypeDTO(){ Id = Guid.Parse("1"), Description = "Description", EntryType = FinanceManager.Infrastructure.Models.EntryType.Expense, Name = "Name", WalletId = Guid.Parse("2")},
            new WalletModel()
        }
    };
}
