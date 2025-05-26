using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Models.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Domain.Tests.Data;

public class DbEntitiesTestDataProvider

{
    public static List<FinanceManagerUser> Users { get { return _users; } }

    public static List<FinanceManagerRole> Roles { get { return _roles; } }

    public static List<IdentityUserRole<Guid>> UserRoles { get { return _userRoles; } }

    public static List<Wallet> Wallets { get { return _wallets; } }

    public static List<FinanceOperationType> FinanceOperationTypes { get { return _financeOperationTypes; } }

    public static List<FinanceOperation> FinanceOperations { get { return _fnanceOperations; } }

    private static List<FinanceManagerUser> _users = new()
    {
        new()
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PasswordHash = _passwordHasher.HashPassword(null, "saferPassword123"),
            CreatedOn = new DateTime(2024,1,3),
            LastModifiedOn = new DateTime(2025,3,8)
        },
        new()
        {
            Id = Guid.NewGuid(),
            FirstName = "Jane",
            LastName = "Smith",
            Email = "jane.smith@example.com",
            PasswordHash = _passwordHasher.HashPassword(null, "saferPassword456"),
            CreatedOn = new DateTime(2024,11,13),
            LastModifiedOn = new DateTime(2025,1,17)
        },
        new()
        {
            Id = Guid.NewGuid(),
            FirstName = "Michael",
            LastName = "Johnson",
            Email = "michael.johnson@example.com",
            PasswordHash = _passwordHasher.HashPassword(null, "saferPassword789"),
            CreatedOn = new DateTime(2024,2,8),
            LastModifiedOn = new DateTime(2025,2,21)
        },
        new()
        {
            Id = Guid.NewGuid(),
            FirstName = "Emily",
            LastName = "Davis",
            Email = "emily.davis@example.com",
            PasswordHash = _passwordHasher.HashPassword(null, "saferPassword101"),
            CreatedOn = new DateTime(2024,6,30),
            LastModifiedOn = new DateTime(2025,4,12)
        },
        new()
        {
            Id = Guid.NewGuid(),
            FirstName = "Chris",
            LastName = "Brown",
            Email = "chris.brown@example.com",
            PasswordHash = _passwordHasher.HashPassword(null, "saferPassword102"),
            CreatedOn = new DateTime(2024,8,1),
            LastModifiedOn = DateTime.Now.AddDays(-3)
        },
        new()
        {
            Id = Guid.NewGuid(),
            LastName = "Your best",
            FirstName = "Admin",
            Email = "mr.admin.number1@gmail.com",
            PasswordHash = _passwordHasher.HashPassword(null, "saferAdminParol124"),
            CreatedOn = new DateTime(2023,8,23),
            LastModifiedOn = DateTime.Now
        },
        new()
        {
            Id = Guid.NewGuid(),
            LastName = "Your second best",
            FirstName = "Admin",
            Email = "mr.admin.number2@gmail.com",
            PasswordHash = _passwordHasher.HashPassword(null, "saferPassword456"),
            CreatedOn = new DateTime(2023,5,13),
            LastModifiedOn = new DateTime(2025,1,1)
        }

    };

    private static List<FinanceManagerRole> _roles = new()
    {
        new(){ Id = Guid.NewGuid(), Name = "User", NormalizedName = "USER"},
        new(){ Id = Guid.NewGuid(), Name = "Admin", NormalizedName = "ADMIN"}
    };

    private static List<IdentityUserRole<Guid>> _userRoles = new()
    {
        new() { UserId = _users[0].Id, RoleId = _roles[0].Id},
        new() { UserId = _users[1].Id, RoleId = _roles[0].Id},
        new() { UserId = _users[2].Id, RoleId = _roles[0].Id},
        new() { UserId = _users[3].Id, RoleId = _roles[0].Id},
        new() { UserId = _users[4].Id, RoleId = _roles[0].Id},
        new() { UserId = _users[5].Id, RoleId = _roles[1].Id},
        new() { UserId = _users[6].Id, RoleId = _roles[1].Id}
    };

    private static PasswordHasher<FinanceManagerUser> _passwordHasher = new();

    private static List<Wallet> _wallets = new()
    {
        new Wallet()
    {
        Id = Guid.NewGuid(),
        Balance = 1000,
        UserId = _users[0].Id,
        Name = "Primary Wallet"
    },
        new Wallet()
    {
        Id = Guid.NewGuid(),
        Balance = 1500,
        UserId = _users[0].Id,
        Name = "Savings Wallet"
    },
        new Wallet()
    {
        Id = Guid.NewGuid(),
        Balance = 2000,
        UserId = _users[1].Id,
        Name = "Investment Wallet"
    },
        new Wallet()
    {
        Id = Guid.NewGuid(),
        Balance = 2500,
        UserId = _users[4].Id,
        Name = "Vacation Fund"
    },
        new Wallet()
    {
        Id = Guid.NewGuid(),
        Balance = 3000,
        UserId = _users[2].Id,
        Name = "Emergency Fund"
    },
        new Wallet()
    {
        Id = Guid.NewGuid(),
        Balance = 3500,
        UserId = _users[3].Id,
        Name = "Retirement Fund"
    },
        new Wallet()
    {
        Id = Guid.NewGuid(),
        Balance = 4000,
        UserId = _users[4].Id,
        Name = "Education Fund"
    }
    };

    private static List<FinanceOperationType> _financeOperationTypes = new()
    {
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Salary",
            Description = "Monthly salary",
            EntryType = EntryType.Income,
            WalletId = _wallets[0].Id,
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Groceries",
            Description = "Weekly groceries",
            EntryType = EntryType.Expense,
            WalletId = _wallets[0].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Rent",
            Description = "Monthly rent payment",
            EntryType = EntryType.Expense,
            WalletId = _wallets[1].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Electricity Bill",
            Description = "Monthly electricity bill",
            EntryType = EntryType.Expense,
            WalletId = _wallets[1].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Freelance",
            Description = "Freelance project payment",
            EntryType = EntryType.Income,
            WalletId = _wallets[2].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Dining Out",
            Description = "Dinner at restaurant",
            EntryType = EntryType.Expense,
            WalletId = _wallets[2].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Gym Membership",
            Description = "Monthly gym membership",
            EntryType = EntryType.Expense,
            WalletId = _wallets[3].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Gift",
            Description = "Birthday gift",
            EntryType = EntryType.Expense,
            WalletId = _wallets[3].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Consulting",
            Description = "Consulting services",
            EntryType = EntryType.Income,
            WalletId = _wallets[4].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Travel",
            Description = "Travel expenses",
            EntryType = EntryType.Expense,
            WalletId = _wallets[4].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Investment",
            Description = "Stock market investment",
            EntryType = EntryType.Expense,
            WalletId = _wallets[5].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Dividends",
            Description = "Stock dividends",
            EntryType = EntryType.Income,
            WalletId = _wallets[5].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Savings",
            Description = "Monthly savings",
            EntryType = EntryType.Income,
            WalletId = _wallets[6].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Car Maintenance",
            Description = "Car repair and maintenance",
            EntryType = EntryType.Expense,
            WalletId = _wallets[6].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Internet Bill",
            Description = "Monthly internet bill",
            EntryType = EntryType.Expense,
            WalletId = _wallets[0].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Bonus",
            Description = "Annual bonus",
            EntryType = EntryType.Income,
            WalletId = _wallets[0].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Insurance",
            Description = "Health insurance payment",
            EntryType = EntryType.Expense,
            WalletId = _wallets[1].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Book Sales",
            Description = "Income from book sales",
            EntryType = EntryType.Income,
            WalletId = _wallets[1].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Clothing",
            Description = "Purchase of clothing",
            EntryType = EntryType.Expense,
            WalletId = _wallets[2].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Interest",
            Description = "Bank account interest",
            EntryType = EntryType.Income,
            WalletId = _wallets[2].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Medical Bills",
            Description = "Payment for medical services",
            EntryType = EntryType.Expense,
            WalletId = _wallets[3].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Tuition",
            Description = "Payment for education",
            EntryType = EntryType.Expense,
            WalletId = _wallets[3].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Software Sales",
            Description = "Income from software sales",
            EntryType = EntryType.Income,
            WalletId = _wallets[4].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Household Supplies",
            Description = "Purchase of household supplies",
            EntryType = EntryType.Expense,
            WalletId = _wallets[4].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Freelance Writing",
            Description = "Income from freelance writing",
            EntryType = EntryType.Income,
            WalletId = _wallets[5].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Charity",
            Description = "Donation to charity",
            EntryType = EntryType.Expense,
            WalletId = _wallets[5].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Furniture",
            Description = "Purchase of furniture",
            EntryType = EntryType.Expense,
            WalletId = _wallets[6].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Music Sales",
            Description = "Income from music sales",
            EntryType = EntryType.Income,
            WalletId = _wallets[6].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Tax Refund",
            Description = "Income from tax refund",
            EntryType = EntryType.Income,
            WalletId = _wallets[0].Id
        },
        new FinanceOperationType()
        {
            Id = Guid.NewGuid(),
            Name = "Subscriptions",
            Description = "Monthly subscriptions",
            EntryType = EntryType.Expense,
            WalletId = _wallets[1].Id
        }
    };

    private static List<FinanceOperation> _fnanceOperations = new()
    {
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 500, Date = new DateTime(2025, 1, 1), TypeId = _financeOperationTypes[0].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 100, Date = new DateTime(2025, 1, 2), TypeId = _financeOperationTypes[1].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 750, Date = new DateTime(2025, 1, 3), TypeId = _financeOperationTypes[2].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 120, Date = new DateTime(2025, 1, 4), TypeId = _financeOperationTypes[3].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 1500, Date = new DateTime(2025, 1, 5), TypeId = _financeOperationTypes[4].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 60, Date = new DateTime(2025, 1, 6), TypeId = _financeOperationTypes[5].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 40, Date = new DateTime(2025, 1, 7), TypeId = _financeOperationTypes[6].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 100, Date = new DateTime(2025, 1, 8), TypeId = _financeOperationTypes[7].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 2000, Date = new DateTime(2025, 1, 9), TypeId = _financeOperationTypes[8].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 1, 10), TypeId = _financeOperationTypes[9].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 150, Date = new DateTime(2025, 1, 11), TypeId = _financeOperationTypes[10].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 200, Date = new DateTime(2025, 1, 12), TypeId = _financeOperationTypes[11].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 1, 13), TypeId = _financeOperationTypes[12].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 70, Date = new DateTime(2025, 1, 14), TypeId = _financeOperationTypes[13].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 50, Date = new DateTime(2025, 1, 15), TypeId = _financeOperationTypes[14].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 1000, Date = new DateTime(2025, 1, 16), TypeId = _financeOperationTypes[15].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 200, Date = new DateTime(2025, 1, 17), TypeId = _financeOperationTypes[16].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 250, Date = new DateTime(2025, 1, 18), TypeId = _financeOperationTypes[17].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 80, Date = new DateTime(2025, 1, 19), TypeId = _financeOperationTypes[18].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 50, Date = new DateTime(2025, 1, 20), TypeId = _financeOperationTypes[19].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 1, 21), TypeId = _financeOperationTypes[20].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 500, Date = new DateTime(2025, 1, 22), TypeId = _financeOperationTypes[21].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 1500, Date = new DateTime(2025, 1, 23), TypeId = _financeOperationTypes[22].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 40, Date = new DateTime(2025, 1, 24), TypeId = _financeOperationTypes[23].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 600, Date = new DateTime(2025, 1, 25), TypeId = _financeOperationTypes[24].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 100, Date = new DateTime(2025, 1, 26), TypeId = _financeOperationTypes[25].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 400, Date = new DateTime(2025, 1, 27), TypeId = _financeOperationTypes[26].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 1, 28), TypeId = _financeOperationTypes[27].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 500, Date = new DateTime(2025, 1, 29), TypeId = _financeOperationTypes[28].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 20, Date = new DateTime(2025, 1, 30), TypeId = _financeOperationTypes[29].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 500, Date = new DateTime(2025, 2, 1), TypeId = _financeOperationTypes[0].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 100, Date = new DateTime(2025, 2, 2), TypeId = _financeOperationTypes[1].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 750, Date = new DateTime(2025, 2, 3), TypeId = _financeOperationTypes[2].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 120, Date = new DateTime(2025, 2, 4), TypeId = _financeOperationTypes[3].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 1500, Date = new DateTime(2025, 2, 5), TypeId = _financeOperationTypes[4].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 60, Date = new DateTime(2025, 2, 6), TypeId = _financeOperationTypes[5].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 40, Date = new DateTime(2025, 2, 7), TypeId = _financeOperationTypes[6].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 100, Date = new DateTime(2025, 2, 8), TypeId = _financeOperationTypes[7].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 2000, Date = new DateTime(2025, 2, 9), TypeId = _financeOperationTypes[8].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 2, 10), TypeId = _financeOperationTypes[9].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 150, Date = new DateTime(2025, 2, 11), TypeId = _financeOperationTypes[10].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 200, Date = new DateTime(2025, 2, 12), TypeId = _financeOperationTypes[11].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 2, 13), TypeId = _financeOperationTypes[12].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 70, Date = new DateTime(2025, 2, 14), TypeId = _financeOperationTypes[13].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 50, Date = new DateTime(2025, 2, 15), TypeId = _financeOperationTypes[14].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 1000, Date = new DateTime(2025, 2, 16), TypeId = _financeOperationTypes[15].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 200, Date = new DateTime(2025, 2, 17), TypeId = _financeOperationTypes[16].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 250, Date = new DateTime(2025, 2, 18), TypeId = _financeOperationTypes[17].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 80, Date = new DateTime(2025, 2, 19), TypeId = _financeOperationTypes[18].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 50, Date = new DateTime(2025, 2, 20), TypeId = _financeOperationTypes[19].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 2, 21), TypeId = _financeOperationTypes[20].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 500, Date = new DateTime(2025, 2, 22), TypeId = _financeOperationTypes[21].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 1500, Date = new DateTime(2025, 2, 23), TypeId = _financeOperationTypes[22].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 40, Date = new DateTime(2025, 2, 24), TypeId = _financeOperationTypes[23].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 600, Date = new DateTime(2025, 2, 25), TypeId = _financeOperationTypes[24].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 100, Date = new DateTime(2025, 2, 26), TypeId = _financeOperationTypes[25].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 400, Date = new DateTime(2025, 2, 27), TypeId = _financeOperationTypes[26].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 2, 28), TypeId = _financeOperationTypes[27].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 500, Date = new DateTime(2025, 2, 29), TypeId = _financeOperationTypes[28].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 20, Date = new DateTime(2025, 3, 1), TypeId = _financeOperationTypes[29].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 500, Date = new DateTime(2025, 3, 2), TypeId = _financeOperationTypes[0].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 100, Date = new DateTime(2025, 3, 3), TypeId = _financeOperationTypes[1].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 750, Date = new DateTime(2025, 3, 4), TypeId = _financeOperationTypes[2].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 120, Date = new DateTime(2025, 3, 5), TypeId = _financeOperationTypes[3].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 1500, Date = new DateTime(2025, 3, 6), TypeId = _financeOperationTypes[4].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 60, Date = new DateTime(2025, 3, 7), TypeId = _financeOperationTypes[5].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 40, Date = new DateTime(2025, 3, 8), TypeId = _financeOperationTypes[6].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 100, Date = new DateTime(2025, 3, 9), TypeId = _financeOperationTypes[7].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 2000, Date = new DateTime(2025, 3, 10), TypeId = _financeOperationTypes[8].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 3, 11), TypeId = _financeOperationTypes[9].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 150, Date = new DateTime(2025, 3, 12), TypeId = _financeOperationTypes[10].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 200, Date = new DateTime(2025, 3, 13), TypeId = _financeOperationTypes[11].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 3, 14), TypeId = _financeOperationTypes[12].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 70, Date = new DateTime(2025, 3, 15), TypeId = _financeOperationTypes[13].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 50, Date = new DateTime(2025, 3, 16), TypeId = _financeOperationTypes[14].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 1000, Date = new DateTime(2025, 3, 17), TypeId = _financeOperationTypes[15].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 200, Date = new DateTime(2025, 3, 18), TypeId = _financeOperationTypes[16].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 250, Date = new DateTime(2025, 3, 19), TypeId = _financeOperationTypes[17].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 80, Date = new DateTime(2025, 3, 20), TypeId = _financeOperationTypes[18].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 50, Date = new DateTime(2025, 3, 21), TypeId = _financeOperationTypes[19].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 3, 22), TypeId = _financeOperationTypes[20].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 500, Date = new DateTime(2025, 3, 23), TypeId = _financeOperationTypes[21].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 1500, Date = new DateTime(2025, 3, 24), TypeId = _financeOperationTypes[22].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 40, Date = new DateTime(2025, 3, 25), TypeId = _financeOperationTypes[23].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 600, Date = new DateTime(2025, 3, 26), TypeId = _financeOperationTypes[24].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 100, Date = new DateTime(2025, 3, 27), TypeId = _financeOperationTypes[25].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 400, Date = new DateTime(2025, 3, 28), TypeId = _financeOperationTypes[26].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 3, 29), TypeId = _financeOperationTypes[27].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 500, Date = new DateTime(2025, 3, 30), TypeId = _financeOperationTypes[28].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 20, Date = new DateTime(2025, 3, 31), TypeId = _financeOperationTypes[29].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 500, Date = new DateTime(2025, 4, 1), TypeId = _financeOperationTypes[0].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 100, Date = new DateTime(2025, 4, 2), TypeId = _financeOperationTypes[1].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 750, Date = new DateTime(2025, 4, 3), TypeId = _financeOperationTypes[2].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 120, Date = new DateTime(2025, 4, 4), TypeId = _financeOperationTypes[3].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 1500, Date = new DateTime(2025, 4, 5), TypeId = _financeOperationTypes[4].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 60, Date = new DateTime(2025, 4, 6), TypeId = _financeOperationTypes[5].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 40, Date = new DateTime(2025, 4, 7), TypeId = _financeOperationTypes[6].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 100, Date = new DateTime(2025, 4, 8), TypeId = _financeOperationTypes[7].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 2000, Date = new DateTime(2025, 4, 9), TypeId = _financeOperationTypes[8].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 4, 10), TypeId = _financeOperationTypes[9].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 100, Date = new DateTime(2025, 4, 11, second: 24, minute: 11, hour: 03), TypeId = _financeOperationTypes[0].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 2000, Date = new DateTime(2025, 4, 11, second: 53, minute: 02, hour: 11), TypeId = _financeOperationTypes[0].Id },
        new FinanceOperation() { Id = Guid.NewGuid(), Amount = 300, Date = new DateTime(2025, 4, 11, second: 37, minute: 27, hour: 7), TypeId = _financeOperationTypes[0].Id }

    };
}
