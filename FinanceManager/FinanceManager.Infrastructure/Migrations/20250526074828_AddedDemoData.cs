using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedDemoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "Description", "LastModifiedOn", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2da1dfa4-5d4d-45eb-895c-1c82b5971b85"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, "User", "USER" },
                    { new Guid("db3e695c-2f84-47ec-8a36-8e2c51b7a53f"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "LastModifiedOn", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("00039684-7db3-46ff-a0f5-b744f225c30e"), 0, "a890519d-223c-4045-b1b2-9f2cbdc19026", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chris.brown@example.com", true, "Chris", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", false, null, "CHRIS.BROWN@EXAMPLE.COM", null, "AQAAAAIAAYagAAAAEJvOykoneIGxU88zwOYxNt96EkeAcPk7vG1xxISO/4rjfbFuctUXupCikXZlkJr8cQ==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "a18de4ad-5064-49ac-b5ef-81cde6d2827a", false, "chris.brown@example.com" },
                    { new Guid("06a12d9c-20a2-4f39-8c13-68e0bdddbadb"), 0, "80d4821b-a1af-46c1-9f77-1a5944986781", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", true, "John", new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", false, null, "JOHN.DOE@EXAMPLE.COM", null, "AQAAAAIAAYagAAAAEIIxUvMVY6oY0tlAwFQ0HUNxuvIr69wfrlEBJ9f40ZruSVn5rMMO6DGsQXjnxpqd+w==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "c97bbf70-a83e-473a-af00-04c15aa3cccb", false, "john.doe@example.com" },
                    { new Guid("0c2fb4ea-d631-4ce7-9f02-2f4c011c2160"), 0, "33ebfde7-a6ce-4046-92b0-4685e201446a", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "mr.admin.number1@gmail.com", true, "Admin", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Your best", false, null, "MR.ADMIN.NUMBER1@GMAIL.COM", null, "AQAAAAIAAYagAAAAEOHpil2TDHMZFj4SOTBmZsHNlLXT8uPAItWOhVbI5DSNr3iUx3NArdiX9ibKVHbmVQ==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "5a0b7512-1f5e-499e-af17-8cb21455020e", false, "mr.admin.number1@gmail.com" },
                    { new Guid("1749fadd-b32e-430d-80d4-68b041218bd3"), 0, "4b9d5a46-bc36-4b59-85ec-1b7af917af1d", new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "mr.admin.number2@gmail.com", true, "Admin", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Your second best", false, null, "MR.ADMIN.NUMBER2@GMAIL.COM", null, "AQAAAAIAAYagAAAAEF+8duMuJjfQRTPUnVJetBaLU13SmWKUJVdqj/mvRY67feCA6542H0RCCqjjgRHSKw==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "02d399e5-bd6f-4d76-bde1-162e2b4c9074", false, "mr.admin.number2@gmail.com" },
                    { new Guid("47b38d98-ee54-409b-bf0b-2821ca8a20b0"), 0, "7138a660-62c7-4ef9-87af-44d5a8550c37", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.davis@example.com", true, "Emily", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Davis", false, null, "EMILY.DAVIS@EXAMPLE.COM", null, "AQAAAAIAAYagAAAAEFV/CxCbKIxEXNYGpT6X7cIdakSqh1SVcXCGdHESZNH3XvRSdHbQCITRXUI4RbAm6g==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "385b0441-84e4-4f0a-8752-495f2f4d005a", false, "emily.davis@example.com" },
                    { new Guid("6085ec7e-1cd3-4302-a51e-0a216c738b79"), 0, "ac599c11-794f-467c-bf93-04f9ff4931dc", new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", true, "Jane", new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", false, null, "JANE.SMITH@EXAMPLE.COM", null, "AQAAAAIAAYagAAAAEPDowkUQB13Knk1V4+rnruh2byGx8L8cqKvwQ2+UMOw3JCa9ShqTLmYmA/skAbhOKA==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "60b771a0-af7e-4527-a114-dfb8b30e472b", false, "jane.smith@example.com" },
                    { new Guid("b9d052fd-c677-4722-85ff-0a2a5aad4af1"), 0, "8f5b3868-7240-436c-8483-0607bf9e935e", new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.johnson@example.com", true, "Michael", new DateTime(2025, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", false, null, "MICHAEL.JOHNSON@EXAMPLE.COM", null, "AQAAAAIAAYagAAAAECokPx1Uymcti3CW/v3fdFQTpVCOjd7iZT3Ksi5bMhhzgIKgfF2CFLYcwu9zMGjqJw==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3057898e-7200-475b-9083-9d1e7142268a", false, "michael.johnson@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2da1dfa4-5d4d-45eb-895c-1c82b5971b85"), new Guid("00039684-7db3-46ff-a0f5-b744f225c30e") },
                    { new Guid("2da1dfa4-5d4d-45eb-895c-1c82b5971b85"), new Guid("06a12d9c-20a2-4f39-8c13-68e0bdddbadb") },
                    { new Guid("db3e695c-2f84-47ec-8a36-8e2c51b7a53f"), new Guid("0c2fb4ea-d631-4ce7-9f02-2f4c011c2160") },
                    { new Guid("db3e695c-2f84-47ec-8a36-8e2c51b7a53f"), new Guid("1749fadd-b32e-430d-80d4-68b041218bd3") },
                    { new Guid("2da1dfa4-5d4d-45eb-895c-1c82b5971b85"), new Guid("47b38d98-ee54-409b-bf0b-2821ca8a20b0") },
                    { new Guid("2da1dfa4-5d4d-45eb-895c-1c82b5971b85"), new Guid("6085ec7e-1cd3-4302-a51e-0a216c738b79") },
                    { new Guid("2da1dfa4-5d4d-45eb-895c-1c82b5971b85"), new Guid("b9d052fd-c677-4722-85ff-0a2a5aad4af1") }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "Name", "UsertId" },
                values: new object[,]
                {
                    { new Guid("2cdd231c-4fc1-47ef-be64-c93e2b6aa842"), 3000, "Emergency Fund", new Guid("b9d052fd-c677-4722-85ff-0a2a5aad4af1") },
                    { new Guid("2dd4c61c-b85b-48d7-a746-da3f67900aaf"), 1500, "Savings Wallet", new Guid("06a12d9c-20a2-4f39-8c13-68e0bdddbadb") },
                    { new Guid("537e8323-bdba-41f2-a141-5a3f024978ea"), 3500, "Retirement Fund", new Guid("47b38d98-ee54-409b-bf0b-2821ca8a20b0") },
                    { new Guid("9d536894-4aca-4df0-bdf4-8096fd142de9"), 2000, "Investment Wallet", new Guid("6085ec7e-1cd3-4302-a51e-0a216c738b79") },
                    { new Guid("ccb6d53b-ae14-44a4-ab75-525b838786fe"), 4000, "Education Fund", new Guid("00039684-7db3-46ff-a0f5-b744f225c30e") },
                    { new Guid("d3d06754-3f13-4cd1-ae8b-4bc95db7490d"), 2500, "Vacation Fund", new Guid("00039684-7db3-46ff-a0f5-b744f225c30e") },
                    { new Guid("d8d6f6da-cd32-4c0c-9f16-d9c362f2f4c1"), 1000, "Primary Wallet", new Guid("06a12d9c-20a2-4f39-8c13-68e0bdddbadb") }
                });

            migrationBuilder.InsertData(
                table: "FinanceOperationTypes",
                columns: new[] { "Id", "Description", "EntryType", "Name", "WalletId" },
                values: new object[,]
                {
                    { new Guid("02261ce9-14ba-478b-b522-2cc28790ecf7"), "Bank account interest", 0, "Interest", new Guid("9d536894-4aca-4df0-bdf4-8096fd142de9") },
                    { new Guid("07833ef4-9b71-4457-92f1-8cd3ea331630"), "Monthly electricity bill", 1, "Electricity Bill", new Guid("2dd4c61c-b85b-48d7-a746-da3f67900aaf") },
                    { new Guid("0ebd2a28-9726-4f28-b5a9-707410ef2ad2"), "Annual bonus", 0, "Bonus", new Guid("d8d6f6da-cd32-4c0c-9f16-d9c362f2f4c1") },
                    { new Guid("2b9da575-54ea-4689-bae0-cfe923ac47b2"), "Income from book sales", 0, "Book Sales", new Guid("2dd4c61c-b85b-48d7-a746-da3f67900aaf") },
                    { new Guid("3cd3e963-5f1c-4026-8cac-f8b097d2be02"), "Income from freelance writing", 0, "Freelance Writing", new Guid("ccb6d53b-ae14-44a4-ab75-525b838786fe") },
                    { new Guid("3d033511-8700-4f2a-a6f2-e47ce51e2bf3"), "Monthly internet bill", 1, "Internet Bill", new Guid("d8d6f6da-cd32-4c0c-9f16-d9c362f2f4c1") },
                    { new Guid("4af51eea-e862-4caf-8ce5-9ad6737dbd7b"), "Purchase of household supplies", 1, "Household Supplies", new Guid("537e8323-bdba-41f2-a141-5a3f024978ea") },
                    { new Guid("4b3af6df-8abe-42a1-82e0-ae861a9a33ed"), "Birthday gift", 1, "Gift", new Guid("2cdd231c-4fc1-47ef-be64-c93e2b6aa842") },
                    { new Guid("5fd4afed-3409-4e18-8118-d0bcf847f11f"), "Travel expenses", 1, "Travel", new Guid("537e8323-bdba-41f2-a141-5a3f024978ea") },
                    { new Guid("629021c3-fe72-447a-b80a-33670d2f8bbd"), "Purchase of clothing", 1, "Clothing", new Guid("9d536894-4aca-4df0-bdf4-8096fd142de9") },
                    { new Guid("663171ac-1ac1-461d-b45a-469e644c9ae4"), "Dinner at restaurant", 1, "Dining Out", new Guid("9d536894-4aca-4df0-bdf4-8096fd142de9") },
                    { new Guid("6ae5a115-3361-4b6f-84cb-61fd53f18358"), "Car repair and maintenance", 1, "Car Maintenance", new Guid("d3d06754-3f13-4cd1-ae8b-4bc95db7490d") },
                    { new Guid("76dda505-b8db-4980-8156-ce3056018b97"), "Health insurance payment", 1, "Insurance", new Guid("2dd4c61c-b85b-48d7-a746-da3f67900aaf") },
                    { new Guid("820daebd-f027-4a39-bbcb-289b2d161933"), "Monthly subscriptions", 1, "Subscriptions", new Guid("2dd4c61c-b85b-48d7-a746-da3f67900aaf") },
                    { new Guid("adcbf657-efee-4666-a179-e5a105a1b99d"), "Purchase of furniture", 1, "Furniture", new Guid("d3d06754-3f13-4cd1-ae8b-4bc95db7490d") },
                    { new Guid("afd56f2e-2660-4363-9321-645d93fa0520"), "Payment for education", 1, "Tuition", new Guid("2cdd231c-4fc1-47ef-be64-c93e2b6aa842") },
                    { new Guid("b3b31e78-aeaf-468e-baca-3367045ae65b"), "Consulting services", 0, "Consulting", new Guid("537e8323-bdba-41f2-a141-5a3f024978ea") },
                    { new Guid("b924b2e9-f504-4bc6-a611-ce856b2b1fdd"), "Monthly rent payment", 1, "Rent", new Guid("2dd4c61c-b85b-48d7-a746-da3f67900aaf") },
                    { new Guid("b9bf0cdb-2390-4f19-9955-db8bad50574f"), "Income from tax refund", 0, "Tax Refund", new Guid("d8d6f6da-cd32-4c0c-9f16-d9c362f2f4c1") },
                    { new Guid("cc488c25-5e5d-4ae1-9cca-7842effad853"), "Income from music sales", 0, "Music Sales", new Guid("d3d06754-3f13-4cd1-ae8b-4bc95db7490d") },
                    { new Guid("ce0b9d6d-d470-4cc2-8d3e-5ad21aca29a4"), "Stock market investment", 1, "Investment", new Guid("ccb6d53b-ae14-44a4-ab75-525b838786fe") },
                    { new Guid("d8179f7e-9789-4be3-a1c2-5c536c5d384b"), "Freelance project payment", 0, "Freelance", new Guid("9d536894-4aca-4df0-bdf4-8096fd142de9") },
                    { new Guid("d849a3fd-5e3a-4365-92df-79e59b732247"), "Donation to charity", 1, "Charity", new Guid("ccb6d53b-ae14-44a4-ab75-525b838786fe") },
                    { new Guid("e1941e45-3981-454d-af77-46be20eb8f90"), "Stock dividends", 0, "Dividends", new Guid("ccb6d53b-ae14-44a4-ab75-525b838786fe") },
                    { new Guid("e21e180c-29e3-412a-99f3-b7254a6c6a1b"), "Monthly savings", 0, "Savings", new Guid("d3d06754-3f13-4cd1-ae8b-4bc95db7490d") },
                    { new Guid("e7d6760c-92d3-4130-b4d6-5ad459880399"), "Weekly groceries", 1, "Groceries", new Guid("d8d6f6da-cd32-4c0c-9f16-d9c362f2f4c1") },
                    { new Guid("e95da595-58b3-4726-97b7-d752323d594e"), "Monthly gym membership", 1, "Gym Membership", new Guid("2cdd231c-4fc1-47ef-be64-c93e2b6aa842") },
                    { new Guid("eb00cc66-2104-4bc4-9d6b-fc20f2cdc935"), "Income from software sales", 0, "Software Sales", new Guid("537e8323-bdba-41f2-a141-5a3f024978ea") },
                    { new Guid("f20e1cd9-84e1-4fc0-be9d-0b830d1be20b"), "Monthly salary", 0, "Salary", new Guid("d8d6f6da-cd32-4c0c-9f16-d9c362f2f4c1") },
                    { new Guid("f51e1eb6-539a-4e71-9e12-4d8c50fd92b2"), "Payment for medical services", 1, "Medical Bills", new Guid("2cdd231c-4fc1-47ef-be64-c93e2b6aa842") }
                });

            migrationBuilder.InsertData(
                table: "FinanceOperations",
                columns: new[] { "Id", "Amount", "Date", "TypeId" },
                values: new object[,]
                {
                    { new Guid("0067dff5-a986-43f4-8868-ac9b16f2a606"), 300L, new DateTime(2025, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3cd3e963-5f1c-4026-8cac-f8b097d2be02") },
                    { new Guid("01f3819a-7ba0-419f-95f0-0ac3417b79d4"), 200L, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eb00cc66-2104-4bc4-9d6b-fc20f2cdc935") },
                    { new Guid("02cda2d7-4b3e-4ef9-a842-69ed5ec00513"), 500L, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("adcbf657-efee-4666-a179-e5a105a1b99d") },
                    { new Guid("06bc9f56-a0af-4f33-9ec2-f8a51b293b3c"), 40L, new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f51e1eb6-539a-4e71-9e12-4d8c50fd92b2") },
                    { new Guid("09eb8091-6a30-4455-a845-ae36868da876"), 250L, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b9da575-54ea-4689-bae0-cfe923ac47b2") },
                    { new Guid("0da8a758-6b04-4a19-8cca-899c0c69e168"), 300L, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("afd56f2e-2660-4363-9321-645d93fa0520") },
                    { new Guid("0f3952ab-f050-45d6-a28b-2a371881f9da"), 600L, new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b3b31e78-aeaf-468e-baca-3367045ae65b") },
                    { new Guid("10ab94e4-7d92-4c40-bae9-201eca72dce5"), 400L, new DateTime(2025, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d849a3fd-5e3a-4365-92df-79e59b732247") },
                    { new Guid("12892252-a531-4c15-80ea-2a4b7b4862e3"), 200L, new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("76dda505-b8db-4980-8156-ce3056018b97") },
                    { new Guid("18c66de8-0ef7-4ecc-98b2-e4e0b2c79deb"), 80L, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("629021c3-fe72-447a-b80a-33670d2f8bbd") },
                    { new Guid("18cb485c-03ea-4def-a07b-d7ca43621a4f"), 750L, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b924b2e9-f504-4bc6-a611-ce856b2b1fdd") },
                    { new Guid("18f2a06f-9155-47ac-8a94-51ee0a6f5c55"), 2000L, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e95da595-58b3-4726-97b7-d752323d594e") },
                    { new Guid("1c926c88-a80c-4850-a341-56cab0bc259f"), 300L, new DateTime(2025, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6ae5a115-3361-4b6f-84cb-61fd53f18358") },
                    { new Guid("1e49d023-ff93-460c-9701-bbdba9499956"), 100L, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5fd4afed-3409-4e18-8118-d0bcf847f11f") },
                    { new Guid("232c889e-917a-4224-8e11-c420326ba1bc"), 2000L, new DateTime(2025, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e95da595-58b3-4726-97b7-d752323d594e") },
                    { new Guid("2aa80a14-7db2-4d10-9735-f4b6e41c9b4c"), 1500L, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8179f7e-9789-4be3-a1c2-5c536c5d384b") },
                    { new Guid("2b451831-90df-4fc3-91a2-471855873ba6"), 300L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f20e1cd9-84e1-4fc0-be9d-0b830d1be20b") },
                    { new Guid("2c547dc3-9c98-4206-abe7-83610daa04d4"), 40L, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f51e1eb6-539a-4e71-9e12-4d8c50fd92b2") },
                    { new Guid("2e310c71-f84f-4fbf-94b4-b637e255714a"), 750L, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b924b2e9-f504-4bc6-a611-ce856b2b1fdd") },
                    { new Guid("2ecb9915-51d2-48ed-a796-8b46f250274b"), 100L, new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7d6760c-92d3-4130-b4d6-5ad459880399") },
                    { new Guid("2ee651a3-c5fd-4ddc-8d1d-8d05c2aeb72e"), 120L, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("07833ef4-9b71-4457-92f1-8cd3ea331630") },
                    { new Guid("39ec7582-af93-419b-9996-f9fadf1c98af"), 1500L, new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8179f7e-9789-4be3-a1c2-5c536c5d384b") },
                    { new Guid("404a2a3c-4862-4dbe-a6e4-8a9891e94406"), 50L, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("02261ce9-14ba-478b-b522-2cc28790ecf7") },
                    { new Guid("431411c3-7aea-438f-b6f8-4be16a0a0d38"), 2000L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f20e1cd9-84e1-4fc0-be9d-0b830d1be20b") },
                    { new Guid("43b9ab73-31bd-468b-87e7-ccf6c13cf2ba"), 300L, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e1941e45-3981-454d-af77-46be20eb8f90") },
                    { new Guid("443acc27-6474-476d-b8eb-5ea42ddac004"), 1000L, new DateTime(2025, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0ebd2a28-9726-4f28-b5a9-707410ef2ad2") },
                    { new Guid("45abda13-29a3-48af-ac99-67df7de3aaeb"), 80L, new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("629021c3-fe72-447a-b80a-33670d2f8bbd") },
                    { new Guid("46ca599b-0a4a-417b-bc15-863426782ec1"), 1000L, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0ebd2a28-9726-4f28-b5a9-707410ef2ad2") },
                    { new Guid("491af7ec-1020-4fbd-8986-54d8bbd83b26"), 200L, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eb00cc66-2104-4bc4-9d6b-fc20f2cdc935") },
                    { new Guid("491bb2df-bb14-43a7-93a7-b8cba9d8a486"), 300L, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("afd56f2e-2660-4363-9321-645d93fa0520") },
                    { new Guid("4b8a4859-6712-4ee9-91b1-1502d20e8a55"), 150L, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4af51eea-e862-4caf-8ce5-9ad6737dbd7b") },
                    { new Guid("4b9d9ac3-2d50-42ce-bea4-530dd276b061"), 300L, new DateTime(2025, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e1941e45-3981-454d-af77-46be20eb8f90") },
                    { new Guid("53f6f158-150b-4236-b990-b532ac7e8fc2"), 100L, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7d6760c-92d3-4130-b4d6-5ad459880399") },
                    { new Guid("53f8ff92-eb4f-477c-8958-57242e4f86d6"), 500L, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f20e1cd9-84e1-4fc0-be9d-0b830d1be20b") },
                    { new Guid("548050b8-0f48-49e4-af12-5b2e5c78d3a1"), 40L, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f51e1eb6-539a-4e71-9e12-4d8c50fd92b2") },
                    { new Guid("54d692ac-36c7-47fd-b006-ee80ccee1f23"), 750L, new DateTime(2025, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b924b2e9-f504-4bc6-a611-ce856b2b1fdd") },
                    { new Guid("5540ed12-0723-4860-8c7b-dc6d6be1476b"), 400L, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d849a3fd-5e3a-4365-92df-79e59b732247") },
                    { new Guid("600f4589-9337-402f-8c18-c755e9717ff2"), 80L, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("629021c3-fe72-447a-b80a-33670d2f8bbd") },
                    { new Guid("634462d1-a699-4e0c-b5e1-cd60a69d9c83"), 120L, new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("07833ef4-9b71-4457-92f1-8cd3ea331630") },
                    { new Guid("6564de83-6c2b-4830-ae07-a81820de0283"), 1000L, new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0ebd2a28-9726-4f28-b5a9-707410ef2ad2") },
                    { new Guid("685c6761-473a-44e1-aafb-431eb7ff4daa"), 40L, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc488c25-5e5d-4ae1-9cca-7842effad853") },
                    { new Guid("69acb819-94f8-4c83-98f2-74d9cced9982"), 60L, new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("663171ac-1ac1-461d-b45a-469e644c9ae4") },
                    { new Guid("6ba9a10b-c1df-4ad0-94dd-c7f1a84a0a28"), 50L, new DateTime(2025, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("02261ce9-14ba-478b-b522-2cc28790ecf7") },
                    { new Guid("6cb00bb9-29a0-4a8b-ad8d-9e5f2f5f1f4a"), 50L, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3d033511-8700-4f2a-a6f2-e47ce51e2bf3") },
                    { new Guid("6df9fe8c-81f6-4012-9cd1-770db162194c"), 600L, new DateTime(2025, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b3b31e78-aeaf-468e-baca-3367045ae65b") },
                    { new Guid("7220f6cf-915e-4e5e-a038-ca30824f5819"), 20L, new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("820daebd-f027-4a39-bbcb-289b2d161933") },
                    { new Guid("7895034f-9c3e-4583-be3d-de3ded0ad5cc"), 1500L, new DateTime(2025, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b3af6df-8abe-42a1-82e0-ae861a9a33ed") },
                    { new Guid("78d9c3d5-7f48-47a0-9aec-af9d1da592bc"), 70L, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce0b9d6d-d470-4cc2-8d3e-5ad21aca29a4") },
                    { new Guid("798aa941-fcc3-4337-bd00-8b4ae7c5b7a3"), 250L, new DateTime(2025, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b9da575-54ea-4689-bae0-cfe923ac47b2") },
                    { new Guid("79b7b04f-135f-4c22-8c03-c36951b7ebce"), 300L, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6ae5a115-3361-4b6f-84cb-61fd53f18358") },
                    { new Guid("7c5e3fb9-a937-41e7-a783-cb8eb3c099aa"), 750L, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b924b2e9-f504-4bc6-a611-ce856b2b1fdd") },
                    { new Guid("7d944af6-f97b-4907-b0a3-e32624bc1da9"), 20L, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("820daebd-f027-4a39-bbcb-289b2d161933") },
                    { new Guid("7de6ee59-d547-4b16-a8a4-3ca184ef4cee"), 300L, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3cd3e963-5f1c-4026-8cac-f8b097d2be02") },
                    { new Guid("7f9a8913-7f3f-4bb0-9d70-a6e41df6a4ef"), 150L, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4af51eea-e862-4caf-8ce5-9ad6737dbd7b") },
                    { new Guid("8180b6f9-c0b0-4145-a99c-81ad7d78375a"), 100L, new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5fd4afed-3409-4e18-8118-d0bcf847f11f") },
                    { new Guid("83290696-5e39-4f2b-9fac-daa092452f03"), 100L, new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f20e1cd9-84e1-4fc0-be9d-0b830d1be20b") },
                    { new Guid("845d05ac-9021-4d5b-98a3-f847480204e6"), 100L, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7d6760c-92d3-4130-b4d6-5ad459880399") },
                    { new Guid("88cdf2aa-af1b-48e1-a8d3-706aaebe25bf"), 100L, new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e21e180c-29e3-412a-99f3-b7254a6c6a1b") },
                    { new Guid("8949a8d2-fe81-429e-8646-c4741b1cf8d8"), 500L, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f20e1cd9-84e1-4fc0-be9d-0b830d1be20b") },
                    { new Guid("89e1888d-977c-4f8a-aa6f-7bbe5b6c249e"), 300L, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("afd56f2e-2660-4363-9321-645d93fa0520") },
                    { new Guid("9012c5a2-50db-4b0a-a542-d00f350e0858"), 40L, new DateTime(2025, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc488c25-5e5d-4ae1-9cca-7842effad853") },
                    { new Guid("964a41ef-194e-4df6-88ca-4f215de12c5c"), 1500L, new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b3af6df-8abe-42a1-82e0-ae861a9a33ed") },
                    { new Guid("96d4e692-c511-4d3d-97a8-2d45e49d67db"), 60L, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("663171ac-1ac1-461d-b45a-469e644c9ae4") },
                    { new Guid("9d56b370-dc8a-427c-bbbb-697e1cb846a8"), 300L, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6ae5a115-3361-4b6f-84cb-61fd53f18358") },
                    { new Guid("a0ac6ed0-425e-4afc-9cf2-fb5c46a8d690"), 20L, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("820daebd-f027-4a39-bbcb-289b2d161933") },
                    { new Guid("a649dea4-79bc-4f2d-bec9-9046b4e5638f"), 70L, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce0b9d6d-d470-4cc2-8d3e-5ad21aca29a4") },
                    { new Guid("a686b4a8-70d5-48be-89b5-7e1b7fabe0cc"), 500L, new DateTime(2025, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("adcbf657-efee-4666-a179-e5a105a1b99d") },
                    { new Guid("a6aff005-135d-49d3-8fad-48da11781fb8"), 150L, new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4af51eea-e862-4caf-8ce5-9ad6737dbd7b") },
                    { new Guid("a7276103-8168-4f79-98f5-81f8bd87b626"), 2000L, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e95da595-58b3-4726-97b7-d752323d594e") },
                    { new Guid("a7fe2858-ea78-46e2-a57f-c16cdb1d3e8b"), 500L, new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b9bf0cdb-2390-4f19-9955-db8bad50574f") },
                    { new Guid("a903f194-9377-4329-9158-ead5073a837d"), 300L, new DateTime(2025, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("afd56f2e-2660-4363-9321-645d93fa0520") },
                    { new Guid("abedd12b-bc63-4045-8209-4775f1cd36eb"), 400L, new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d849a3fd-5e3a-4365-92df-79e59b732247") },
                    { new Guid("ad7a768d-48d7-4205-a867-4c8a22793d2e"), 40L, new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc488c25-5e5d-4ae1-9cca-7842effad853") },
                    { new Guid("add52289-1be1-481c-845a-c6b041f3737c"), 1500L, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8179f7e-9789-4be3-a1c2-5c536c5d384b") },
                    { new Guid("b492ea09-2c11-4933-8eb6-e51442b390d7"), 500L, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("adcbf657-efee-4666-a179-e5a105a1b99d") },
                    { new Guid("b59cf982-b578-45a9-a23b-6b45d2bd7692"), 60L, new DateTime(2025, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("663171ac-1ac1-461d-b45a-469e644c9ae4") },
                    { new Guid("b6725f2b-1a51-4725-ba39-00cd383cddd4"), 100L, new DateTime(2025, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5fd4afed-3409-4e18-8118-d0bcf847f11f") },
                    { new Guid("b80550d8-6fc3-455a-8cee-c3494bc61b77"), 1500L, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d8179f7e-9789-4be3-a1c2-5c536c5d384b") },
                    { new Guid("ba18b0e2-f166-4bb8-bc1d-48354b409b85"), 200L, new DateTime(2025, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("eb00cc66-2104-4bc4-9d6b-fc20f2cdc935") },
                    { new Guid("bb64640b-9caa-4561-ade6-4411d8669369"), 120L, new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("07833ef4-9b71-4457-92f1-8cd3ea331630") },
                    { new Guid("bc670c6d-6bc8-4636-b6aa-191a888d08ed"), 100L, new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e21e180c-29e3-412a-99f3-b7254a6c6a1b") },
                    { new Guid("bfcb2175-4b9e-4518-8508-adfc30b31e1b"), 100L, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7d6760c-92d3-4130-b4d6-5ad459880399") },
                    { new Guid("c4fb9e32-8e3c-4e04-b2e8-8a65b9e6b790"), 2000L, new DateTime(2025, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e95da595-58b3-4726-97b7-d752323d594e") },
                    { new Guid("c55d9f3c-887e-4ce5-9058-e6d28d357fa5"), 70L, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ce0b9d6d-d470-4cc2-8d3e-5ad21aca29a4") },
                    { new Guid("c57af14d-06b2-47c0-8d43-3f33af46881f"), 40L, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cc488c25-5e5d-4ae1-9cca-7842effad853") },
                    { new Guid("c57eae65-99d3-45cc-96e3-85d430cb28e7"), 600L, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b3b31e78-aeaf-468e-baca-3367045ae65b") },
                    { new Guid("c849eab5-1af0-4c40-b3fa-68cd7c46bfb0"), 50L, new DateTime(2025, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3d033511-8700-4f2a-a6f2-e47ce51e2bf3") },
                    { new Guid("cb4fb4fe-092f-4f6a-8ccd-068f8b69abbc"), 500L, new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b9bf0cdb-2390-4f19-9955-db8bad50574f") },
                    { new Guid("cd6231f8-8446-4655-b0a8-3626ace08224"), 500L, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f20e1cd9-84e1-4fc0-be9d-0b830d1be20b") },
                    { new Guid("ce9a4ba0-d603-4f07-bf55-aa5019dddc8d"), 1500L, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4b3af6df-8abe-42a1-82e0-ae861a9a33ed") },
                    { new Guid("de48d422-feb0-4dd3-a4ca-5e85e4f23bfc"), 100L, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e21e180c-29e3-412a-99f3-b7254a6c6a1b") },
                    { new Guid("e149ab0a-887c-4a0f-b344-ebcf878376fa"), 120L, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("07833ef4-9b71-4457-92f1-8cd3ea331630") },
                    { new Guid("e55f6c51-07c5-4fd6-8a4c-b01ba99146dd"), 300L, new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e1941e45-3981-454d-af77-46be20eb8f90") },
                    { new Guid("e67638bc-c719-4c96-9817-fa933522f1e9"), 300L, new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3cd3e963-5f1c-4026-8cac-f8b097d2be02") },
                    { new Guid("e9ddf285-8fd4-4d66-8a46-dae1d7648820"), 100L, new DateTime(2025, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e21e180c-29e3-412a-99f3-b7254a6c6a1b") },
                    { new Guid("ed909415-0823-4a3d-9113-6ce38ffccdd9"), 250L, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b9da575-54ea-4689-bae0-cfe923ac47b2") },
                    { new Guid("ee8e2b8b-2284-42e7-8291-dd0516e54135"), 50L, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("02261ce9-14ba-478b-b522-2cc28790ecf7") },
                    { new Guid("f0978cee-bf2a-4c34-b561-bbe11a448696"), 500L, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("f20e1cd9-84e1-4fc0-be9d-0b830d1be20b") },
                    { new Guid("f1ed0d67-df89-4713-b579-267c19fe9b14"), 60L, new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("663171ac-1ac1-461d-b45a-469e644c9ae4") },
                    { new Guid("f40357b5-4cfa-48ea-a221-b7b1476ebcf9"), 200L, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("76dda505-b8db-4980-8156-ce3056018b97") },
                    { new Guid("f7120ee1-8f4b-49c5-876f-b212e283e95d"), 50L, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3d033511-8700-4f2a-a6f2-e47ce51e2bf3") },
                    { new Guid("fa521fcc-3fc5-4952-9a88-3eddb8e40d5d"), 200L, new DateTime(2025, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("76dda505-b8db-4980-8156-ce3056018b97") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2da1dfa4-5d4d-45eb-895c-1c82b5971b85"), new Guid("00039684-7db3-46ff-a0f5-b744f225c30e") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2da1dfa4-5d4d-45eb-895c-1c82b5971b85"), new Guid("06a12d9c-20a2-4f39-8c13-68e0bdddbadb") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("db3e695c-2f84-47ec-8a36-8e2c51b7a53f"), new Guid("0c2fb4ea-d631-4ce7-9f02-2f4c011c2160") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("db3e695c-2f84-47ec-8a36-8e2c51b7a53f"), new Guid("1749fadd-b32e-430d-80d4-68b041218bd3") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2da1dfa4-5d4d-45eb-895c-1c82b5971b85"), new Guid("47b38d98-ee54-409b-bf0b-2821ca8a20b0") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2da1dfa4-5d4d-45eb-895c-1c82b5971b85"), new Guid("6085ec7e-1cd3-4302-a51e-0a216c738b79") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2da1dfa4-5d4d-45eb-895c-1c82b5971b85"), new Guid("b9d052fd-c677-4722-85ff-0a2a5aad4af1") });

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("0067dff5-a986-43f4-8868-ac9b16f2a606"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("01f3819a-7ba0-419f-95f0-0ac3417b79d4"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("02cda2d7-4b3e-4ef9-a842-69ed5ec00513"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("06bc9f56-a0af-4f33-9ec2-f8a51b293b3c"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("09eb8091-6a30-4455-a845-ae36868da876"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("0da8a758-6b04-4a19-8cca-899c0c69e168"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("0f3952ab-f050-45d6-a28b-2a371881f9da"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("10ab94e4-7d92-4c40-bae9-201eca72dce5"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("12892252-a531-4c15-80ea-2a4b7b4862e3"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("18c66de8-0ef7-4ecc-98b2-e4e0b2c79deb"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("18cb485c-03ea-4def-a07b-d7ca43621a4f"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("18f2a06f-9155-47ac-8a94-51ee0a6f5c55"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("1c926c88-a80c-4850-a341-56cab0bc259f"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("1e49d023-ff93-460c-9701-bbdba9499956"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("232c889e-917a-4224-8e11-c420326ba1bc"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("2aa80a14-7db2-4d10-9735-f4b6e41c9b4c"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("2b451831-90df-4fc3-91a2-471855873ba6"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("2c547dc3-9c98-4206-abe7-83610daa04d4"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("2e310c71-f84f-4fbf-94b4-b637e255714a"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("2ecb9915-51d2-48ed-a796-8b46f250274b"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("2ee651a3-c5fd-4ddc-8d1d-8d05c2aeb72e"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("39ec7582-af93-419b-9996-f9fadf1c98af"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("404a2a3c-4862-4dbe-a6e4-8a9891e94406"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("431411c3-7aea-438f-b6f8-4be16a0a0d38"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("43b9ab73-31bd-468b-87e7-ccf6c13cf2ba"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("443acc27-6474-476d-b8eb-5ea42ddac004"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("45abda13-29a3-48af-ac99-67df7de3aaeb"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("46ca599b-0a4a-417b-bc15-863426782ec1"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("491af7ec-1020-4fbd-8986-54d8bbd83b26"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("491bb2df-bb14-43a7-93a7-b8cba9d8a486"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("4b8a4859-6712-4ee9-91b1-1502d20e8a55"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("4b9d9ac3-2d50-42ce-bea4-530dd276b061"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("53f6f158-150b-4236-b990-b532ac7e8fc2"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("53f8ff92-eb4f-477c-8958-57242e4f86d6"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("548050b8-0f48-49e4-af12-5b2e5c78d3a1"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("54d692ac-36c7-47fd-b006-ee80ccee1f23"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("5540ed12-0723-4860-8c7b-dc6d6be1476b"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("600f4589-9337-402f-8c18-c755e9717ff2"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("634462d1-a699-4e0c-b5e1-cd60a69d9c83"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("6564de83-6c2b-4830-ae07-a81820de0283"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("685c6761-473a-44e1-aafb-431eb7ff4daa"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("69acb819-94f8-4c83-98f2-74d9cced9982"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("6ba9a10b-c1df-4ad0-94dd-c7f1a84a0a28"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("6cb00bb9-29a0-4a8b-ad8d-9e5f2f5f1f4a"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("6df9fe8c-81f6-4012-9cd1-770db162194c"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("7220f6cf-915e-4e5e-a038-ca30824f5819"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("7895034f-9c3e-4583-be3d-de3ded0ad5cc"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("78d9c3d5-7f48-47a0-9aec-af9d1da592bc"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("798aa941-fcc3-4337-bd00-8b4ae7c5b7a3"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("79b7b04f-135f-4c22-8c03-c36951b7ebce"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("7c5e3fb9-a937-41e7-a783-cb8eb3c099aa"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("7d944af6-f97b-4907-b0a3-e32624bc1da9"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("7de6ee59-d547-4b16-a8a4-3ca184ef4cee"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("7f9a8913-7f3f-4bb0-9d70-a6e41df6a4ef"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("8180b6f9-c0b0-4145-a99c-81ad7d78375a"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("83290696-5e39-4f2b-9fac-daa092452f03"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("845d05ac-9021-4d5b-98a3-f847480204e6"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("88cdf2aa-af1b-48e1-a8d3-706aaebe25bf"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("8949a8d2-fe81-429e-8646-c4741b1cf8d8"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("89e1888d-977c-4f8a-aa6f-7bbe5b6c249e"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("9012c5a2-50db-4b0a-a542-d00f350e0858"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("964a41ef-194e-4df6-88ca-4f215de12c5c"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("96d4e692-c511-4d3d-97a8-2d45e49d67db"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("9d56b370-dc8a-427c-bbbb-697e1cb846a8"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("a0ac6ed0-425e-4afc-9cf2-fb5c46a8d690"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("a649dea4-79bc-4f2d-bec9-9046b4e5638f"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("a686b4a8-70d5-48be-89b5-7e1b7fabe0cc"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("a6aff005-135d-49d3-8fad-48da11781fb8"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("a7276103-8168-4f79-98f5-81f8bd87b626"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("a7fe2858-ea78-46e2-a57f-c16cdb1d3e8b"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("a903f194-9377-4329-9158-ead5073a837d"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("abedd12b-bc63-4045-8209-4775f1cd36eb"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("ad7a768d-48d7-4205-a867-4c8a22793d2e"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("add52289-1be1-481c-845a-c6b041f3737c"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("b492ea09-2c11-4933-8eb6-e51442b390d7"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("b59cf982-b578-45a9-a23b-6b45d2bd7692"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("b6725f2b-1a51-4725-ba39-00cd383cddd4"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("b80550d8-6fc3-455a-8cee-c3494bc61b77"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("ba18b0e2-f166-4bb8-bc1d-48354b409b85"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("bb64640b-9caa-4561-ade6-4411d8669369"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("bc670c6d-6bc8-4636-b6aa-191a888d08ed"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("bfcb2175-4b9e-4518-8508-adfc30b31e1b"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("c4fb9e32-8e3c-4e04-b2e8-8a65b9e6b790"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("c55d9f3c-887e-4ce5-9058-e6d28d357fa5"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("c57af14d-06b2-47c0-8d43-3f33af46881f"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("c57eae65-99d3-45cc-96e3-85d430cb28e7"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("c849eab5-1af0-4c40-b3fa-68cd7c46bfb0"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("cb4fb4fe-092f-4f6a-8ccd-068f8b69abbc"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("cd6231f8-8446-4655-b0a8-3626ace08224"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("ce9a4ba0-d603-4f07-bf55-aa5019dddc8d"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("de48d422-feb0-4dd3-a4ca-5e85e4f23bfc"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("e149ab0a-887c-4a0f-b344-ebcf878376fa"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("e55f6c51-07c5-4fd6-8a4c-b01ba99146dd"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("e67638bc-c719-4c96-9817-fa933522f1e9"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("e9ddf285-8fd4-4d66-8a46-dae1d7648820"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("ed909415-0823-4a3d-9113-6ce38ffccdd9"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("ee8e2b8b-2284-42e7-8291-dd0516e54135"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("f0978cee-bf2a-4c34-b561-bbe11a448696"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("f1ed0d67-df89-4713-b579-267c19fe9b14"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("f40357b5-4cfa-48ea-a221-b7b1476ebcf9"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("f7120ee1-8f4b-49c5-876f-b212e283e95d"));

            migrationBuilder.DeleteData(
                table: "FinanceOperations",
                keyColumn: "Id",
                keyValue: new Guid("fa521fcc-3fc5-4952-9a88-3eddb8e40d5d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2da1dfa4-5d4d-45eb-895c-1c82b5971b85"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("db3e695c-2f84-47ec-8a36-8e2c51b7a53f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0c2fb4ea-d631-4ce7-9f02-2f4c011c2160"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1749fadd-b32e-430d-80d4-68b041218bd3"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("02261ce9-14ba-478b-b522-2cc28790ecf7"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("07833ef4-9b71-4457-92f1-8cd3ea331630"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("0ebd2a28-9726-4f28-b5a9-707410ef2ad2"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("2b9da575-54ea-4689-bae0-cfe923ac47b2"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("3cd3e963-5f1c-4026-8cac-f8b097d2be02"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("3d033511-8700-4f2a-a6f2-e47ce51e2bf3"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("4af51eea-e862-4caf-8ce5-9ad6737dbd7b"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("4b3af6df-8abe-42a1-82e0-ae861a9a33ed"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("5fd4afed-3409-4e18-8118-d0bcf847f11f"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("629021c3-fe72-447a-b80a-33670d2f8bbd"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("663171ac-1ac1-461d-b45a-469e644c9ae4"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("6ae5a115-3361-4b6f-84cb-61fd53f18358"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("76dda505-b8db-4980-8156-ce3056018b97"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("820daebd-f027-4a39-bbcb-289b2d161933"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("adcbf657-efee-4666-a179-e5a105a1b99d"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("afd56f2e-2660-4363-9321-645d93fa0520"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b3b31e78-aeaf-468e-baca-3367045ae65b"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b924b2e9-f504-4bc6-a611-ce856b2b1fdd"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("b9bf0cdb-2390-4f19-9955-db8bad50574f"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("cc488c25-5e5d-4ae1-9cca-7842effad853"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("ce0b9d6d-d470-4cc2-8d3e-5ad21aca29a4"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("d8179f7e-9789-4be3-a1c2-5c536c5d384b"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("d849a3fd-5e3a-4365-92df-79e59b732247"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("e1941e45-3981-454d-af77-46be20eb8f90"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("e21e180c-29e3-412a-99f3-b7254a6c6a1b"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("e7d6760c-92d3-4130-b4d6-5ad459880399"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("e95da595-58b3-4726-97b7-d752323d594e"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("eb00cc66-2104-4bc4-9d6b-fc20f2cdc935"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("f20e1cd9-84e1-4fc0-be9d-0b830d1be20b"));

            migrationBuilder.DeleteData(
                table: "FinanceOperationTypes",
                keyColumn: "Id",
                keyValue: new Guid("f51e1eb6-539a-4e71-9e12-4d8c50fd92b2"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("2cdd231c-4fc1-47ef-be64-c93e2b6aa842"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("2dd4c61c-b85b-48d7-a746-da3f67900aaf"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("537e8323-bdba-41f2-a141-5a3f024978ea"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("9d536894-4aca-4df0-bdf4-8096fd142de9"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("ccb6d53b-ae14-44a4-ab75-525b838786fe"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("d3d06754-3f13-4cd1-ae8b-4bc95db7490d"));

            migrationBuilder.DeleteData(
                table: "Wallets",
                keyColumn: "Id",
                keyValue: new Guid("d8d6f6da-cd32-4c0c-9f16-d9c362f2f4c1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("00039684-7db3-46ff-a0f5-b744f225c30e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("06a12d9c-20a2-4f39-8c13-68e0bdddbadb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("47b38d98-ee54-409b-bf0b-2821ca8a20b0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6085ec7e-1cd3-4302-a51e-0a216c738b79"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b9d052fd-c677-4722-85ff-0a2a5aad4af1"));
        }
    }
}
