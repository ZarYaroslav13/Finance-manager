using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Models.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Infrastructure;

public class DBFiller
{
    private static PasswordHasher<FinanceManagerUser> _passwordHasher = new();

    private static List<FinanceManagerUser> _users = new List<FinanceManagerUser>
{
    new()
    {
        Id = new Guid("06a12d9c-20a2-4f39-8c13-68e0bdddbadb"),
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com",
        NormalizedEmail = "JOHN.DOE@EXAMPLE.COM", // Added NormalizedEmail
        EmailConfirmed = true,
        PasswordHash = "AQAAAAIAAYagAAAAEIIxUvMVY6oY0tlAwFQ0HUNxuvIr69wfrlEBJ9f40ZruSVn5rMMO6DGsQXjnxpqd+w==", // protectedPassword123
        CreatedOn = new DateTime(2024, 1, 3),
        LastModifiedOn = new DateTime(2025, 3, 8),
        UserName = "john.doe@example.com",
        ConcurrencyStamp = "80d4821b-a1af-46c1-9f77-1a5944986781",
        SecurityStamp = "c97bbf70-a83e-473a-af00-04c15aa3cccb"
    },
    new()
    {
        Id = new Guid("6085ec7e-1cd3-4302-a51e-0a216c738b79"),
        FirstName = "Jane",
        LastName = "Smith",
        Email = "jane.smith@example.com",
        NormalizedEmail = "JANE.SMITH@EXAMPLE.COM", // Added NormalizedEmail
        EmailConfirmed = true,
        PasswordHash = "AQAAAAIAAYagAAAAEPDowkUQB13Knk1V4+rnruh2byGx8L8cqKvwQ2+UMOw3JCa9ShqTLmYmA/skAbhOKA==", // protectedPassword456
        CreatedOn = new DateTime(2024, 11, 13),
        LastModifiedOn = new DateTime(2025, 1, 17),
        UserName = "jane.smith@example.com",
        ConcurrencyStamp = "ac599c11-794f-467c-bf93-04f9ff4931dc",
        SecurityStamp = "60b771a0-af7e-4527-a114-dfb8b30e472b"

    },
    new()
    {
        Id = new Guid("b9d052fd-c677-4722-85ff-0a2a5aad4af1"),
        FirstName = "Michael",
        LastName = "Johnson",
        Email = "michael.johnson@example.com",
        NormalizedEmail = "MICHAEL.JOHNSON@EXAMPLE.COM", // Added NormalizedEmail
        EmailConfirmed = true,
        PasswordHash = "AQAAAAIAAYagAAAAECokPx1Uymcti3CW/v3fdFQTpVCOjd7iZT3Ksi5bMhhzgIKgfF2CFLYcwu9zMGjqJw==", // protectedPassword789
        CreatedOn = new DateTime(2024, 2, 8),
        LastModifiedOn = new DateTime(2025, 2, 21),
        UserName = "michael.johnson@example.com",
        ConcurrencyStamp = "8f5b3868-7240-436c-8483-0607bf9e935e",
        SecurityStamp = "3057898e-7200-475b-9083-9d1e7142268a"

    },
    new()
    {
        Id = new Guid("47b38d98-ee54-409b-bf0b-2821ca8a20b0"),
        FirstName = "Emily",
        LastName = "Davis",
        Email = "emily.davis@example.com",
        NormalizedEmail = "EMILY.DAVIS@EXAMPLE.COM", // Added NormalizedEmail
        EmailConfirmed = true,
        PasswordHash = "AQAAAAIAAYagAAAAEFV/CxCbKIxEXNYGpT6X7cIdakSqh1SVcXCGdHESZNH3XvRSdHbQCITRXUI4RbAm6g==", // protectedPassword012
        CreatedOn = new DateTime(2024, 6, 30),
        LastModifiedOn = new DateTime(2025, 4, 12),
        UserName = "emily.davis@example.com",
        ConcurrencyStamp = "7138a660-62c7-4ef9-87af-44d5a8550c37",
        SecurityStamp = "385b0441-84e4-4f0a-8752-495f2f4d005a"

    },
    new()
    {
        Id = new Guid("00039684-7db3-46ff-a0f5-b744f225c30e"),
        FirstName = "Chris",
        LastName = "Brown",
        Email = "chris.brown@example.com",
        NormalizedEmail = "CHRIS.BROWN@EXAMPLE.COM", // Added NormalizedEmail
        EmailConfirmed = true,
        PasswordHash = "AQAAAAIAAYagAAAAEJvOykoneIGxU88zwOYxNt96EkeAcPk7vG1xxISO/4rjfbFuctUXupCikXZlkJr8cQ==", // protectedPassword345
        CreatedOn = new DateTime(2024, 8, 1),
        LastModifiedOn = new DateTime(2025, 5, 19),
        UserName = "chris.brown@example.com",
        ConcurrencyStamp = "a890519d-223c-4045-b1b2-9f2cbdc19026",
        SecurityStamp = "a18de4ad-5064-49ac-b5ef-81cde6d2827a"

    },
    new()
    {
        Id = new Guid("0c2fb4ea-d631-4ce7-9f02-2f4c011c2160"),
        FirstName = "Admin",
        LastName = "Your best",
        Email = "mr.admin.number1@gmail.com",
        NormalizedEmail = "MR.ADMIN.NUMBER1@GMAIL.COM", // Added NormalizedEmail
        EmailConfirmed = true,
        PasswordHash = "AQAAAAIAAYagAAAAEOHpil2TDHMZFj4SOTBmZsHNlLXT8uPAItWOhVbI5DSNr3iUx3NArdiX9ibKVHbmVQ==", // protectedAdminPassword123
        CreatedOn = new DateTime(2023, 8, 23),
        LastModifiedOn = new DateTime(2025, 5, 22),
        UserName = "mr.admin.number1@gmail.com",
        ConcurrencyStamp = "33ebfde7-a6ce-4046-92b0-4685e201446a",
        SecurityStamp = "5a0b7512-1f5e-499e-af17-8cb21455020e"

    },
    new()
    {
        Id = new Guid("1749fadd-b32e-430d-80d4-68b041218bd3"),
        FirstName = "Admin",
        LastName = "Your second best",
        Email = "mr.admin.number2@gmail.com",
        NormalizedEmail = "MR.ADMIN.NUMBER2@GMAIL.COM", // Added NormalizedEmail
        EmailConfirmed = true,
        PasswordHash = "AQAAAAIAAYagAAAAEF+8duMuJjfQRTPUnVJetBaLU13SmWKUJVdqj/mvRY67feCA6542H0RCCqjjgRHSKw==", // protectedAdminPassword456
        CreatedOn = new DateTime(2023, 5, 13),
        LastModifiedOn = new DateTime(2025, 1, 1),
        UserName = "mr.admin.number2@gmail.com",
        ConcurrencyStamp = "4b9d5a46-bc36-4b59-85ec-1b7af917af1d",
        SecurityStamp = "02d399e5-bd6f-4d76-bde1-162e2b4c9074"
    }
};

    private static List<UserPreference> _userPreferencess = new List<UserPreference>
    {
        new() {Id = _users[0].Id, UserId=_users[0].Id, DarkMode = true, LanguageCode = Constants.Localization.LocalizationConstants.EnglishLanguage.Code, RightToLeft = false },
        new() {Id = _users[1].Id, UserId=_users[1].Id, DarkMode = true, LanguageCode = Constants.Localization.LocalizationConstants.UkrainianLanguage.Code, RightToLeft = false },
        new() {Id = _users[2].Id, UserId=_users[2].Id, DarkMode = true, LanguageCode = Constants.Localization.LocalizationConstants.FrenchLanguage.Code, RightToLeft = false },
        new() {Id = _users[3].Id, UserId=_users[3].Id, DarkMode = false, LanguageCode = Constants.Localization.LocalizationConstants.EnglishLanguage.Code, RightToLeft = false },
        new() {Id = _users[4].Id, UserId=_users[4].Id, DarkMode = false, LanguageCode = Constants.Localization.LocalizationConstants.ItalianLanguage.Code, RightToLeft = false },
        new() {Id = _users[5].Id, UserId=_users[5].Id, DarkMode = false, LanguageCode = Constants.Localization.LocalizationConstants.KhmerLanguage.Code, RightToLeft = true },
        new() {Id = _users[6].Id, UserId=_users[6].Id, DarkMode = false, LanguageCode = Constants.Localization.LocalizationConstants.GermanLanguage.Code, RightToLeft = false },
    };

    private static List<FinanceManagerRole> _roles = new List<FinanceManagerRole>
        {
            new()
            {
                Id = new Guid("2da1dfa4-5d4d-45eb-895c-1c82b5971b85"),
                Name = "User",
                NormalizedName = "USER"
            },
            new()
            {
                Id = new Guid("db3e695c-2f84-47ec-8a36-8e2c51b7a53f"),
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
        };

    private static List<IdentityUserRole<Guid>> _userRoles = new List<IdentityUserRole<Guid>>
        {
            new() { UserId = _users[0].Id, RoleId = _roles[0].Id },
            new() { UserId = _users[1].Id, RoleId = _roles[0].Id },
            new() { UserId = _users[2].Id, RoleId = _roles[0].Id },
            new() { UserId = _users[3].Id, RoleId = _roles[0].Id },
            new() { UserId = _users[4].Id, RoleId = _roles[0].Id },
            new() { UserId = _users[5].Id, RoleId = _roles[1].Id },
            new() { UserId = _users[6].Id, RoleId = _roles[1].Id }
        };

    private static List<Wallet> _wallets = new List<Wallet>
        {
            new() { Id = new Guid("d8d6f6da-cd32-4c0c-9f16-d9c362f2f4c1"), Name = "Primary Wallet", Balance = 1000, UserId = _users[0].Id },
            new() { Id = new Guid("2dd4c61c-b85b-48d7-a746-da3f67900aaf"), Name = "Savings Wallet", Balance = 1500, UserId = _users[0].Id },
            new() { Id = new Guid("9d536894-4aca-4df0-bdf4-8096fd142de9"), Name = "Investment Wallet", Balance = 2000, UserId = _users[1].Id  },
            new() { Id = new Guid("2cdd231c-4fc1-47ef-be64-c93e2b6aa842"), Name = "Emergency Fund", Balance = 3000, UserId = _users[2].Id  },
            new() { Id = new Guid("537e8323-bdba-41f2-a141-5a3f024978ea"), Name = "Retirement Fund", Balance = 3500, UserId = _users[3].Id  },
            new() { Id = new Guid("ccb6d53b-ae14-44a4-ab75-525b838786fe"), Name = "Education Fund", Balance = 4000, UserId =_users[4].Id },
            new() { Id = new Guid("d3d06754-3f13-4cd1-ae8b-4bc95db7490d"), Name = "Vacation Fund", Balance = 2500, UserId = _users[4].Id}
        };

    private static List<FinanceOperationType> _financeOperationTypes = new()
{
        // Wallet 0 (Primary Wallet)
        new FinanceOperationType() { Id = new Guid("f20e1cd9-84e1-4fc0-be9d-0b830d1be20b"), Name = "Salary", Description = "Monthly salary", EntryType = EntryType.Income, WalletId = _wallets[0].Id },
        new FinanceOperationType() { Id = new Guid("b9bf0cdb-2390-4f19-9955-db8bad50574f"), Name = "Tax Refund", Description = "Income from tax refund", EntryType = EntryType.Income, WalletId = _wallets[0].Id },
        new FinanceOperationType() { Id = new Guid("e7d6760c-92d3-4130-b4d6-5ad459880399"), Name = "Groceries", Description = "Weekly groceries", EntryType = EntryType.Expense, WalletId = _wallets[0].Id },
        new FinanceOperationType() { Id = new Guid("3d033511-8700-4f2a-a6f2-e47ce51e2bf3"), Name = "Internet Bill", Description = "Monthly internet bill", EntryType = EntryType.Expense, WalletId = _wallets[0].Id },
        new FinanceOperationType() { Id = new Guid("0ebd2a28-9726-4f28-b5a9-707410ef2ad2"), Name = "Bonus", Description = "Annual bonus", EntryType = EntryType.Income, WalletId = _wallets[0].Id },

        // Wallet 1 (Savings Wallet)
        new FinanceOperationType() { Id = new Guid("b924b2e9-f504-4bc6-a611-ce856b2b1fdd"), Name = "Rent", Description = "Monthly rent payment", EntryType = EntryType.Expense, WalletId = _wallets[1].Id },
        new FinanceOperationType() { Id = new Guid("07833ef4-9b71-4457-92f1-8cd3ea331630"), Name = "Electricity Bill", Description = "Monthly electricity bill", EntryType = EntryType.Expense, WalletId = _wallets[1].Id },
        new FinanceOperationType() { Id = new Guid("2b9da575-54ea-4689-bae0-cfe923ac47b2"), Name = "Book Sales", Description = "Income from book sales", EntryType = EntryType.Income, WalletId = _wallets[1].Id },
        new FinanceOperationType() { Id = new Guid("76dda505-b8db-4980-8156-ce3056018b97"), Name = "Insurance", Description = "Health insurance payment", EntryType = EntryType.Expense, WalletId = _wallets[1].Id },
        new FinanceOperationType() { Id = new Guid("820daebd-f027-4a39-bbcb-289b2d161933"), Name = "Subscriptions", Description = "Monthly subscriptions", EntryType = EntryType.Expense, WalletId = _wallets[1].Id },

        // Wallet 2 (Investment Wallet) - Based on your previous Wallet 2, which is _wallets[2] in the _wallets list
        new FinanceOperationType() { Id = new Guid("d8179f7e-9789-4be3-a1c2-5c536c5d384b"), Name = "Freelance", Description = "Freelance project payment", EntryType = EntryType.Income, WalletId = _wallets[2].Id },
        new FinanceOperationType() { Id = new Guid("02261ce9-14ba-478b-b522-2cc28790ecf7"), Name = "Interest", Description = "Bank account interest", EntryType = EntryType.Income, WalletId = _wallets[2].Id },
        new FinanceOperationType() { Id = new Guid("629021c3-fe72-447a-b80a-33670d2f8bbd"), Name = "Clothing", Description = "Purchase of clothing", EntryType = EntryType.Expense, WalletId = _wallets[2].Id },
        new FinanceOperationType() { Id = new Guid("663171ac-1ac1-461d-b45a-469e644c9ae4"), Name = "Dining Out", Description = "Dinner at restaurant", EntryType = EntryType.Expense, WalletId = _wallets[2].Id },

        // Wallet 3 (Vacation Fund) - Based on your previous Wallet 3, which is _wallets[3] in the _wallets list
        new FinanceOperationType() { Id = new Guid("4b3af6df-8abe-42a1-82e0-ae861a9a33ed"), Name = "Gift", Description = "Birthday gift", EntryType = EntryType.Expense, WalletId = _wallets[3].Id },
        new FinanceOperationType() { Id = new Guid("e95da595-58b3-4726-97b7-d752323d594e"), Name = "Gym Membership", Description = "Monthly gym membership", EntryType = EntryType.Expense, WalletId = _wallets[3].Id },
        new FinanceOperationType() { Id = new Guid("f51e1eb6-539a-4e71-9e12-4d8c50fd92b2"), Name = "Medical Bills", Description = "Payment for medical services", EntryType = EntryType.Expense, WalletId = _wallets[3].Id },
        new FinanceOperationType() { Id = new Guid("afd56f2e-2660-4363-9321-645d93fa0520"), Name = "Tuition", Description = "Payment for education", EntryType = EntryType.Expense, WalletId = _wallets[3].Id },

        // Wallet 4 (Emergency Fund) - Based on your previous Wallet 4, which is _wallets[4] in the _wallets list
        new FinanceOperationType() { Id = new Guid("eb00cc66-2104-4bc4-9d6b-fc20f2cdc935"), Name = "Software Sales", Description = "Income from software sales", EntryType = EntryType.Income, WalletId = _wallets[4].Id },
        new FinanceOperationType() { Id = new Guid("b3b31e78-aeaf-468e-baca-3367045ae65b"), Name = "Consulting", Description = "Consulting services", EntryType = EntryType.Income, WalletId = _wallets[4].Id },
        new FinanceOperationType() { Id = new Guid("4af51eea-e862-4caf-8ce5-9ad6737dbd7b"), Name = "Household Supplies", Description = "Purchase of household supplies", EntryType = EntryType.Expense, WalletId = _wallets[4].Id },
        new FinanceOperationType() { Id = new Guid("5fd4afed-3409-4e18-8118-d0bcf847f11f"), Name = "Travel", Description = "Travel expenses", EntryType = EntryType.Expense, WalletId = _wallets[4].Id },

        // Wallet 5 (Retirement Fund) - Based on your previous Wallet 5, which is _wallets[5] in the _wallets list
        new FinanceOperationType() { Id = new Guid("e1941e45-3981-454d-af77-46be20eb8f90"), Name = "Dividends", Description = "Stock dividends", EntryType = EntryType.Income, WalletId = _wallets[5].Id },
        new FinanceOperationType() { Id = new Guid("3cd3e963-5f1c-4026-8cac-f8b097d2be02"), Name = "Freelance Writing", Description = "Income from freelance writing", EntryType = EntryType.Income, WalletId = _wallets[5].Id },
        new FinanceOperationType() { Id = new Guid("ce0b9d6d-d470-4cc2-8d3e-5ad21aca29a4"), Name = "Investment", Description = "Stock market investment", EntryType = EntryType.Expense, WalletId = _wallets[5].Id },
        new FinanceOperationType() { Id = new Guid("d849a3fd-5e3a-4365-92df-79e59b732247"), Name = "Charity", Description = "Donation to charity", EntryType = EntryType.Expense, WalletId = _wallets[5].Id },

        // Wallet 6 (Education Fund) - Based on your previous Wallet 6, which is _wallets[6] in the _wallets list
        new FinanceOperationType() { Id = new Guid("e21e180c-29e3-412a-99f3-b7254a6c6a1b"), Name = "Savings", Description = "Monthly savings", EntryType = EntryType.Income, WalletId = _wallets[6].Id },
        new FinanceOperationType() { Id = new Guid("cc488c25-5e5d-4ae1-9cca-7842effad853"), Name = "Music Sales", Description = "Income from music sales", EntryType = EntryType.Income, WalletId = _wallets[6].Id },
        new FinanceOperationType() { Id = new Guid("6ae5a115-3361-4b6f-84cb-61fd53f18358"), Name = "Car Maintenance", Description = "Car repair and maintenance", EntryType = EntryType.Expense, WalletId = _wallets[6].Id },
        new FinanceOperationType() { Id = new Guid("adcbf657-efee-4666-a179-e5a105a1b99d"), Name = "Furniture", Description = "Purchase of furniture", EntryType = EntryType.Expense, WalletId = _wallets[6].Id }
    };

    private static List<FinanceOperation> _financeOperations = new List<FinanceOperation>
    {
        new FinanceOperation() { Id = new Guid("53f8ff92-eb4f-477c-8958-57242e4f86d6"), Amount = 500, Date = new DateTime(2025, 1, 1), TypeId = _financeOperationTypes[0].Id }, // Salary
        new FinanceOperation() { Id = new Guid("53f6f158-150b-4236-b990-b532ac7e8fc2"), Amount = 100, Date = new DateTime(2025, 1, 2), TypeId = _financeOperationTypes[2].Id }, // Groceries
        new FinanceOperation() { Id = new Guid("18cb485c-03ea-4def-a07b-d7ca43621a4f"), Amount = 750, Date = new DateTime(2025, 1, 3), TypeId = _financeOperationTypes[5].Id }, // Rent
        new FinanceOperation() { Id = new Guid("2ee651a3-c5fd-4ddc-8d1d-8d05c2aeb72e"), Amount = 120, Date = new DateTime(2025, 1, 4), TypeId = _financeOperationTypes[6].Id }, // Electricity Bill
        new FinanceOperation() { Id = new Guid("add52289-1be1-481c-845a-c6b041f3737c"), Amount = 1500, Date = new DateTime(2025, 1, 5), TypeId = _financeOperationTypes[10].Id }, // Freelance
        new FinanceOperation() { Id = new Guid("96d4e692-c511-4d3d-97a8-2d45e49d67db"), Amount = 60, Date = new DateTime(2025, 1, 6), TypeId = _financeOperationTypes[13].Id }, // Dining Out
        new FinanceOperation() { Id = new Guid("685c6761-473a-44e1-aafb-431eb7ff4daa"), Amount = 40, Date = new DateTime(2025, 1, 7), TypeId = _financeOperationTypes[27].Id }, // Gym Membership
        new FinanceOperation() { Id = new Guid("de48d422-feb0-4dd3-a4ca-5e85e4f23bfc"), Amount = 100, Date = new DateTime(2025, 1, 8), TypeId = _financeOperationTypes[26].Id }, // Gift
        new FinanceOperation() { Id = new Guid("18f2a06f-9155-47ac-8a94-51ee0a6f5c55"), Amount = 2000, Date = new DateTime(2025, 1, 9), TypeId = _financeOperationTypes[15].Id }, // Consulting
        new FinanceOperation() { Id = new Guid("491bb2df-bb14-43a7-93a7-b8cba9d8a486"), Amount = 300, Date = new DateTime(2025, 1, 10), TypeId = _financeOperationTypes[17].Id }, // Travel
        new FinanceOperation() { Id = new Guid("4b8a4859-6712-4ee9-91b1-1502d20e8a55"), Amount = 150, Date = new DateTime(2025, 1, 11), TypeId = _financeOperationTypes[20].Id }, // Investment
        new FinanceOperation() { Id = new Guid("01f3819a-7ba0-419f-95f0-0ac3417b79d4"), Amount = 200, Date = new DateTime(2025, 1, 12), TypeId = _financeOperationTypes[18].Id }, // Dividends
        new FinanceOperation() { Id = new Guid("43b9ab73-31bd-468b-87e7-ccf6c13cf2ba"), Amount = 300, Date = new DateTime(2025, 1, 13), TypeId = _financeOperationTypes[22].Id }, // Savings
        new FinanceOperation() { Id = new Guid("a649dea4-79bc-4f2d-bec9-9046b4e5638f"), Amount = 70, Date = new DateTime(2025, 1, 14), TypeId = _financeOperationTypes[24].Id }, // Car Maintenance
        new FinanceOperation() { Id = new Guid("6cb00bb9-29a0-4a8b-ad8d-9e5f2f5f1f4a"), Amount = 50, Date = new DateTime(2025, 1, 15), TypeId = _financeOperationTypes[3].Id }, // Internet Bill
        new FinanceOperation() { Id = new Guid("46ca599b-0a4a-417b-bc15-863426782ec1"), Amount = 1000, Date = new DateTime(2025, 1, 16), TypeId = _financeOperationTypes[4].Id }, // Bonus
        new FinanceOperation() { Id = new Guid("f40357b5-4cfa-48ea-a221-b7b1476ebcf9"), Amount = 200, Date = new DateTime(2025, 1, 17), TypeId = _financeOperationTypes[8].Id }, // Insurance
        new FinanceOperation() { Id = new Guid("09eb8091-6a30-4455-a845-ae36868da876"), Amount = 250, Date = new DateTime(2025, 1, 18), TypeId = _financeOperationTypes[7].Id }, // Book Sales
        new FinanceOperation() { Id = new Guid("18c66de8-0ef7-4ecc-98b2-e4e0b2c79deb"), Amount = 80, Date = new DateTime(2025, 1, 19), TypeId = _financeOperationTypes[12].Id }, // Clothing
        new FinanceOperation() { Id = new Guid("ee8e2b8b-2284-42e7-8291-dd0516e54135"), Amount = 50, Date = new DateTime(2025, 1, 20), TypeId = _financeOperationTypes[11].Id }, // Interest
        new FinanceOperation() { Id = new Guid("79b7b04f-135f-4c22-8c03-c36951b7ebce"), Amount = 300, Date = new DateTime(2025, 1, 21), TypeId = _financeOperationTypes[28].Id }, // Medical Bills
        new FinanceOperation() { Id = new Guid("02cda2d7-4b3e-4ef9-a842-69ed5ec00513"), Amount = 500, Date = new DateTime(2025, 1, 22), TypeId = _financeOperationTypes[29].Id }, // Tuition
        new FinanceOperation() { Id = new Guid("ce9a4ba0-d603-4f07-bf55-aa5019dddc8d"), Amount = 1500, Date = new DateTime(2025, 1, 23), TypeId = _financeOperationTypes[14].Id }, // Software Sales
        new FinanceOperation() { Id = new Guid("2c547dc3-9c98-4206-abe7-83610daa04d4"), Amount = 40, Date = new DateTime(2025, 1, 24), TypeId = _financeOperationTypes[16].Id }, // Household Supplies
        new FinanceOperation() { Id = new Guid("c57eae65-99d3-45cc-96e3-85d430cb28e7"), Amount = 600, Date = new DateTime(2025, 1, 25), TypeId = _financeOperationTypes[19].Id }, // Freelance Writing
        new FinanceOperation() { Id = new Guid("1e49d023-ff93-460c-9701-bbdba9499956"), Amount = 100, Date = new DateTime(2025, 1, 26), TypeId = _financeOperationTypes[21].Id }, // Charity
        new FinanceOperation() { Id = new Guid("abedd12b-bc63-4045-8209-4775f1cd36eb"), Amount = 400, Date = new DateTime(2025, 1, 27), TypeId = _financeOperationTypes[25].Id }, // Furniture
        new FinanceOperation() { Id = new Guid("0067dff5-a986-43f4-8868-ac9b16f2a606"), Amount = 300, Date = new DateTime(2025, 1, 28), TypeId = _financeOperationTypes[23].Id }, // Music Sales
        new FinanceOperation() { Id = new Guid("a7fe2858-ea78-46e2-a57f-c16cdb1d3e8b"), Amount = 500, Date = new DateTime(2025, 1, 29), TypeId = _financeOperationTypes[1].Id }, // Tax Refund
        new FinanceOperation() { Id = new Guid("7220f6cf-915e-4e5e-a038-ca30824f5819"), Amount = 20, Date = new DateTime(2025, 1, 30), TypeId = _financeOperationTypes[9].Id }, // Subscriptions

        new FinanceOperation() { Id = new Guid("f0978cee-bf2a-4c34-b561-bbe11a448696"), Amount = 500, Date = new DateTime(2025, 2, 1), TypeId = _financeOperationTypes[0].Id }, // Salary
        new FinanceOperation() { Id = new Guid("845d05ac-9021-4d5b-98a3-f847480204e6"), Amount = 100, Date = new DateTime(2025, 2, 2), TypeId = _financeOperationTypes[2].Id }, // Groceries
        new FinanceOperation() { Id = new Guid("2e310c71-f84f-4fbf-94b4-b637e255714a"), Amount = 750, Date = new DateTime(2025, 2, 3), TypeId = _financeOperationTypes[5].Id }, // Rent
        new FinanceOperation() { Id = new Guid("634462d1-a699-4e0c-b5e1-cd60a69d9c83"), Amount = 120, Date = new DateTime(2025, 2, 4), TypeId = _financeOperationTypes[6].Id }, // Electricity Bill
        new FinanceOperation() { Id = new Guid("b80550d8-6fc3-455a-8cee-c3494bc61b77"), Amount = 1500, Date = new DateTime(2025, 2, 5), TypeId = _financeOperationTypes[10].Id }, // Freelance
        new FinanceOperation() { Id = new Guid("b59cf982-b578-45a9-a23b-6b45d2bd7692"), Amount = 60, Date = new DateTime(2025, 2, 6), TypeId = _financeOperationTypes[13].Id }, // Dining Out
        new FinanceOperation() { Id = new Guid("ad7a768d-48d7-4205-a867-4c8a22793d2e"), Amount = 40, Date = new DateTime(2025, 2, 7), TypeId = _financeOperationTypes[27].Id }, // Gym Membership
        new FinanceOperation() { Id = new Guid("bc670c6d-6bc8-4636-b6aa-191a888d08ed"), Amount = 100, Date = new DateTime(2025, 2, 8), TypeId = _financeOperationTypes[26].Id }, // Gift
        new FinanceOperation() { Id = new Guid("c4fb9e32-8e3c-4e04-b2e8-8a65b9e6b790"), Amount = 2000, Date = new DateTime(2025, 2, 9), TypeId = _financeOperationTypes[15].Id }, // Consulting
        new FinanceOperation() { Id = new Guid("89e1888d-977c-4f8a-aa6f-7bbe5b6c249e"), Amount = 300, Date = new DateTime(2025, 2, 10), TypeId = _financeOperationTypes[17].Id }, // Travel
        new FinanceOperation() { Id = new Guid("a6aff005-135d-49d3-8fad-48da11781fb8"), Amount = 150, Date = new DateTime(2025, 2, 11), TypeId = _financeOperationTypes[20].Id }, // Investment
        new FinanceOperation() { Id = new Guid("491af7ec-1020-4fbd-8986-54d8bbd83b26"), Amount = 200, Date = new DateTime(2025, 2, 12), TypeId = _financeOperationTypes[18].Id }, // Dividends
        new FinanceOperation() { Id = new Guid("e55f6c51-07c5-4fd6-8a4c-b01ba99146dd"), Amount = 300, Date = new DateTime(2025, 2, 13), TypeId = _financeOperationTypes[22].Id }, // Savings
        new FinanceOperation() { Id = new Guid("c55d9f3c-887e-4ce5-9058-e6d28d357fa5"), Amount = 70, Date = new DateTime(2025, 2, 14), TypeId = _financeOperationTypes[24].Id }, // Car Maintenance
        new FinanceOperation() { Id = new Guid("f7120ee1-8f4b-49c5-876f-b212e283e95d"), Amount = 50, Date = new DateTime(2025, 2, 15), TypeId = _financeOperationTypes[3].Id }, // Internet Bill
        new FinanceOperation() { Id = new Guid("6564de83-6c2b-4830-ae07-a81820de0283"), Amount = 1000, Date = new DateTime(2025, 2, 16), TypeId = _financeOperationTypes[4].Id }, // Bonus
        new FinanceOperation() { Id = new Guid("fa521fcc-3fc5-4952-9a88-3eddb8e40d5d"), Amount = 200, Date = new DateTime(2025, 2, 17), TypeId = _financeOperationTypes[8].Id }, // Insurance
        new FinanceOperation() { Id = new Guid("ed909415-0823-4a3d-9113-6ce38ffccdd9"), Amount = 250, Date = new DateTime(2025, 2, 18), TypeId = _financeOperationTypes[7].Id }, // Book Sales
        new FinanceOperation() { Id = new Guid("45abda13-29a3-48af-ac99-67df7de3aaeb"), Amount = 80, Date = new DateTime(2025, 2, 19), TypeId = _financeOperationTypes[12].Id }, // Clothing
        new FinanceOperation() { Id = new Guid("404a2a3c-4862-4dbe-a6e4-8a9891e94406"), Amount = 50, Date = new DateTime(2025, 2, 20), TypeId = _financeOperationTypes[11].Id }, // Interest
        new FinanceOperation() { Id = new Guid("1c926c88-a80c-4850-a341-56cab0bc259f"), Amount = 300, Date = new DateTime(2025, 2, 21), TypeId = _financeOperationTypes[28].Id }, // Medical Bills
        new FinanceOperation() { Id = new Guid("b492ea09-2c11-4933-8eb6-e51442b390d7"), Amount = 500, Date = new DateTime(2025, 2, 22), TypeId = _financeOperationTypes[29].Id }, // Tuition
        new FinanceOperation() { Id = new Guid("964a41ef-194e-4df6-88ca-4f215de12c5c"), Amount = 1500, Date = new DateTime(2025, 2, 23), TypeId = _financeOperationTypes[14].Id }, // Software Sales
        new FinanceOperation() { Id = new Guid("06bc9f56-a0af-4f33-9ec2-f8a51b293b3c"), Amount = 40, Date = new DateTime(2025, 2, 24), TypeId = _financeOperationTypes[16].Id }, // Household Supplies
        new FinanceOperation() { Id = new Guid("0f3952ab-f050-45d6-a28b-2a371881f9da"), Amount = 600, Date = new DateTime(2025, 2, 25), TypeId = _financeOperationTypes[19].Id }, // Freelance Writing
        new FinanceOperation() { Id = new Guid("8180b6f9-c0b0-4145-a99c-81ad7d78375a"), Amount = 100, Date = new DateTime(2025, 2, 26), TypeId = _financeOperationTypes[21].Id }, // Charity
        new FinanceOperation() { Id = new Guid("10ab94e4-7d92-4c40-bae9-201eca72dce5"), Amount = 400, Date = new DateTime(2025, 2, 27), TypeId = _financeOperationTypes[25].Id }, // Furniture
        new FinanceOperation() { Id = new Guid("e67638bc-c719-4c96-9817-fa933522f1e9"), Amount = 300, Date = new DateTime(2025, 2, 28), TypeId = _financeOperationTypes[23].Id }, // Music Sales

        new FinanceOperation() { Id = new Guid("7d944af6-f97b-4907-b0a3-e32624bc1da9"), Amount = 20, Date = new DateTime(2025, 3, 1), TypeId = _financeOperationTypes[9].Id }, // Subscriptions
        new FinanceOperation() { Id = new Guid("cd6231f8-8446-4655-b0a8-3626ace08224"), Amount = 500, Date = new DateTime(2025, 3, 2), TypeId = _financeOperationTypes[0].Id }, // Salary
        new FinanceOperation() { Id = new Guid("bfcb2175-4b9e-4518-8508-adfc30b31e1b"), Amount = 100, Date = new DateTime(2025, 3, 3), TypeId = _financeOperationTypes[2].Id }, // Groceries
        new FinanceOperation() { Id = new Guid("54d692ac-36c7-47fd-b006-ee80ccee1f23"), Amount = 750, Date = new DateTime(2025, 3, 4), TypeId = _financeOperationTypes[5].Id }, // Rent
        new FinanceOperation() { Id = new Guid("e149ab0a-887c-4a0f-b344-ebcf878376fa"), Amount = 120, Date = new DateTime(2025, 3, 5), TypeId = _financeOperationTypes[6].Id }, // Electricity Bill
        new FinanceOperation() { Id = new Guid("39ec7582-af93-419b-9996-f9fadf1c98af"), Amount = 1500, Date = new DateTime(2025, 3, 6), TypeId = _financeOperationTypes[10].Id }, // Freelance
        new FinanceOperation() { Id = new Guid("f1ed0d67-df89-4713-b579-267c19fe9b14"), Amount = 60, Date = new DateTime(2025, 3, 7), TypeId = _financeOperationTypes[13].Id }, // Dining Out
        new FinanceOperation() { Id = new Guid("c57af14d-06b2-47c0-8d43-3f33af46881f"), Amount = 40, Date = new DateTime(2025, 3, 8), TypeId = _financeOperationTypes[27].Id }, // Gym Membership
        new FinanceOperation() { Id = new Guid("e9ddf285-8fd4-4d66-8a46-dae1d7648820"), Amount = 100, Date = new DateTime(2025, 3, 9), TypeId = _financeOperationTypes[26].Id }, // Gift
        new FinanceOperation() { Id = new Guid("a7276103-8168-4f79-98f5-81f8bd87b626"), Amount = 2000, Date = new DateTime(2025, 3, 10), TypeId = _financeOperationTypes[15].Id }, // Consulting
        new FinanceOperation() { Id = new Guid("a903f194-9377-4329-9158-ead5073a837d"), Amount = 300, Date = new DateTime(2025, 3, 11), TypeId = _financeOperationTypes[17].Id }, // Travel
        new FinanceOperation() { Id = new Guid("7f9a8913-7f3f-4bb0-9d70-a6e41df6a4ef"), Amount = 150, Date = new DateTime(2025, 3, 12), TypeId = _financeOperationTypes[20].Id }, // Investment
        new FinanceOperation() { Id = new Guid("ba18b0e2-f166-4bb8-bc1d-48354b409b85"), Amount = 200, Date = new DateTime(2025, 3, 13), TypeId = _financeOperationTypes[18].Id }, // Dividends
        new FinanceOperation() { Id = new Guid("4b9d9ac3-2d50-42ce-bea4-530dd276b061"), Amount = 300, Date = new DateTime(2025, 3, 14), TypeId = _financeOperationTypes[22].Id }, // Savings
        new FinanceOperation() { Id = new Guid("78d9c3d5-7f48-47a0-9aec-af9d1da592bc"), Amount = 70, Date = new DateTime(2025, 3, 15), TypeId = _financeOperationTypes[24].Id }, // Car Maintenance
        new FinanceOperation() { Id = new Guid("c849eab5-1af0-4c40-b3fa-68cd7c46bfb0"), Amount = 50, Date = new DateTime(2025, 3, 16), TypeId = _financeOperationTypes[3].Id }, // Internet Bill
        new FinanceOperation() { Id = new Guid("443acc27-6474-476d-b8eb-5ea42ddac004"), Amount = 1000, Date = new DateTime(2025, 3, 17), TypeId = _financeOperationTypes[4].Id }, // Bonus
        new FinanceOperation() { Id = new Guid("12892252-a531-4c15-80ea-2a4b7b4862e3"), Amount = 200, Date = new DateTime(2025, 3, 18), TypeId = _financeOperationTypes[8].Id }, // Insurance
        new FinanceOperation() { Id = new Guid("798aa941-fcc3-4337-bd00-8b4ae7c5b7a3"), Amount = 250, Date = new DateTime(2025, 3, 19), TypeId = _financeOperationTypes[7].Id }, // Book Sales
        new FinanceOperation() { Id = new Guid("600f4589-9337-402f-8c18-c755e9717ff2"), Amount = 80, Date = new DateTime(2025, 3, 20), TypeId = _financeOperationTypes[12].Id }, // Clothing
        new FinanceOperation() { Id = new Guid("6ba9a10b-c1df-4ad0-94dd-c7f1a84a0a28"), Amount = 50, Date = new DateTime(2025, 3, 21), TypeId = _financeOperationTypes[11].Id }, // Interest
        new FinanceOperation() { Id = new Guid("9d56b370-dc8a-427c-bbbb-697e1cb846a8"), Amount = 300, Date = new DateTime(2025, 3, 22), TypeId = _financeOperationTypes[28].Id }, // Medical Bills
        new FinanceOperation() { Id = new Guid("a686b4a8-70d5-48be-89b5-7e1b7fabe0cc"), Amount = 500, Date = new DateTime(2025, 3, 23), TypeId = _financeOperationTypes[29].Id }, // Tuition
        new FinanceOperation() { Id = new Guid("7895034f-9c3e-4583-be3d-de3ded0ad5cc"), Amount = 1500, Date = new DateTime(2025, 3, 24), TypeId = _financeOperationTypes[14].Id }, // Software Sales
        new FinanceOperation() { Id = new Guid("548050b8-0f48-49e4-af12-5b2e5c78d3a1"), Amount = 40, Date = new DateTime(2025, 3, 25), TypeId = _financeOperationTypes[16].Id }, // Household Supplies
        new FinanceOperation() { Id = new Guid("a0ac6ed0-425e-4afc-9cf2-fb5c46a8d690"), Amount = 20, Date = new DateTime(2025, 3, 25), TypeId = _financeOperationTypes[9].Id }, // Subscriptions
        new FinanceOperation() { Id = new Guid("6df9fe8c-81f6-4012-9cd1-770db162194c"), Amount = 600, Date = new DateTime(2025, 3, 26), TypeId = _financeOperationTypes[19].Id }, // Freelance Writing
        new FinanceOperation() { Id = new Guid("b6725f2b-1a51-4725-ba39-00cd383cddd4"), Amount = 100, Date = new DateTime(2025, 3, 27), TypeId = _financeOperationTypes[21].Id }, // Charity
        new FinanceOperation() { Id = new Guid("5540ed12-0723-4860-8c7b-dc6d6be1476b"), Amount = 400, Date = new DateTime(2025, 3, 28), TypeId = _financeOperationTypes[25].Id }, // Furniture
        new FinanceOperation() { Id = new Guid("7de6ee59-d547-4b16-a8a4-3ca184ef4cee"), Amount = 300, Date = new DateTime(2025, 3, 29), TypeId = _financeOperationTypes[23].Id }, // Music Sales
        new FinanceOperation() { Id = new Guid("cb4fb4fe-092f-4f6a-8ccd-068f8b69abbc"), Amount = 500, Date = new DateTime(2025, 3, 30), TypeId = _financeOperationTypes[1].Id }, // Tax Refund

        new FinanceOperation() { Id = new Guid("8949a8d2-fe81-429e-8646-c4741b1cf8d8"), Amount = 500, Date = new DateTime(2025, 4, 1), TypeId = _financeOperationTypes[0].Id }, // Salary
        new FinanceOperation() { Id = new Guid("2ecb9915-51d2-48ed-a796-8b46f250274b"), Amount = 100, Date = new DateTime(2025, 4, 2), TypeId = _financeOperationTypes[2].Id }, // Groceries
        new FinanceOperation() { Id = new Guid("7c5e3fb9-a937-41e7-a783-cb8eb3c099aa"), Amount = 750, Date = new DateTime(2025, 4, 3), TypeId = _financeOperationTypes[5].Id }, // Rent
        new FinanceOperation() { Id = new Guid("bb64640b-9caa-4561-ade6-4411d8669369"), Amount = 120, Date = new DateTime(2025, 4, 4), TypeId = _financeOperationTypes[6].Id }, // Electricity Bill
        new FinanceOperation() { Id = new Guid("2aa80a14-7db2-4d10-9735-f4b6e41c9b4c"), Amount = 1500, Date = new DateTime(2025, 4, 5), TypeId = _financeOperationTypes[10].Id }, // Freelance
        new FinanceOperation() { Id = new Guid("69acb819-94f8-4c83-98f2-74d9cced9982"), Amount = 60, Date = new DateTime(2025, 4, 6), TypeId = _financeOperationTypes[13].Id }, // Dining Out
        new FinanceOperation() { Id = new Guid("9012c5a2-50db-4b0a-a542-d00f350e0858"), Amount = 40, Date = new DateTime(2025, 4, 7), TypeId = _financeOperationTypes[27].Id }, // Gym Membership
        new FinanceOperation() { Id = new Guid("88cdf2aa-af1b-48e1-a8d3-706aaebe25bf"), Amount = 100, Date = new DateTime(2025, 4, 8), TypeId = _financeOperationTypes[26].Id }, // Gift
        new FinanceOperation() { Id = new Guid("232c889e-917a-4224-8e11-c420326ba1bc"), Amount = 2000, Date = new DateTime(2025, 4, 9), TypeId = _financeOperationTypes[15].Id }, // Consulting
        new FinanceOperation() { Id = new Guid("0da8a758-6b04-4a19-8cca-899c0c69e168"), Amount = 300, Date = new DateTime(2025, 4, 10), TypeId = _financeOperationTypes[17].Id }, // Travel
        new FinanceOperation() { Id = new Guid("431411c3-7aea-438f-b6f8-4be16a0a0d38"), Amount = 2000, Date = new DateTime(2025, 4, 11), TypeId = _financeOperationTypes[0].Id }, // Salary
        new FinanceOperation() { Id = new Guid("2b451831-90df-4fc3-91a2-471855873ba6"), Amount = 300, Date = new DateTime(2025, 4, 11), TypeId = _financeOperationTypes[0].Id }, // Salary
        new FinanceOperation() { Id = new Guid("83290696-5e39-4f2b-9fac-daa092452f03"), Amount = 100, Date = new DateTime(2025, 4, 11), TypeId = _financeOperationTypes[0].Id }  // Salary
    };

    public static List<FinanceManagerUser> Users { get { return _users; } }
    public static List<UserPreference> UserPreferencess { get { return _userPreferencess; } }

    public static List<FinanceManagerRole> Roles { get { return _roles; } }

    public static List<IdentityUserRole<Guid>> UserRoles { get { return _userRoles; } }

    public static List<Wallet> Wallets { get { return _wallets; } }

    public static List<FinanceOperationType> FinanceOperationTypes { get { return _financeOperationTypes; } }

    public static List<FinanceOperation> FinanceOperations { get { return _financeOperations; } }
}
