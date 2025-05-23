using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedDemoDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "LastModifiedOn", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("00039684-7db3-46ff-a0f5-b744f225c30e"), 0, "0263fd1f-5bc0-4cf7-8ec1-59b884fcc308", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chris.brown@example.com", false, "Chris", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown", false, null, null, null, "AQAAAAIAAYagAAAAEM/jmHkD52rxvCZ2g6W9lBJYqW0Rrk2ji5h5jth5Q7ckj81c6o88LVY4C8EnH511dg==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null },
                    { new Guid("06a12d9c-20a2-4f39-8c13-68e0bdddbadb"), 0, "a8e33def-d2fe-48f3-aa94-8bfc2fd8978d", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", false, "John", new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", false, null, null, null, "AQAAAAIAAYagAAAAEBbUf+oc7GKVAu+U2AIQ80xeC0DcNaEQ3RHzBpwrATZJ8vxoQKv9Ry3hSehMuQEVJg==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null },
                    { new Guid("0c2fb4ea-d631-4ce7-9f02-2f4c011c2160"), 0, "faad7449-0d32-4118-a8a1-5b8c61b1e793", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "mr.admin.number1@gmail.com", false, "Admin", new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Your best", false, null, null, null, "AQAAAAIAAYagAAAAEGjjPjuYT6yTfv4F7aEZfIhCipzOlMsbwb20D/98IbpNt7VXWHrbAcGNCNbzsjVnpw==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null },
                    { new Guid("1749fadd-b32e-430d-80d4-68b041218bd3"), 0, "ede8f212-8609-4e19-97b4-28f15f3b140d", new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "mr.admin.number2@gmail.com", false, "Admin", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Your second best", false, null, null, null, "AQAAAAIAAYagAAAAEJFw6sYIeHdAwQk85aeqHgVroPlDqaXk124OzsF676KtxNOCVNtTqPV7TR3UfOKmlQ==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null },
                    { new Guid("47b38d98-ee54-409b-bf0b-2821ca8a20b0"), 0, "c87b2cba-9c79-4035-9d9b-2aad523730fb", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "emily.davis@example.com", false, "Emily", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Davis", false, null, null, null, "AQAAAAIAAYagAAAAEN2ToaNz88yFSjz8Ysbplv8TLYVbzXoCaV5qcfaoJ7rvF90UubKLzvlPXtkl4N5OSg==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null },
                    { new Guid("6085ec7e-1cd3-4302-a51e-0a216c738b79"), 0, "ecc7488b-86a3-43cb-84f7-48acb2d7a506", new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", false, "Jane", new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", false, null, null, null, "AQAAAAIAAYagAAAAEA28qiEF/afho11n/l9ZqCREuwfNazYJudmw05zy7w0MuKA4hNitOySl2pPno8foYw==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null },
                    { new Guid("b9d052fd-c677-4722-85ff-0a2a5aad4af1"), 0, "23eaba85-de84-4d97-b695-329b13c2ad51", new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael.johnson@example.com", false, "Michael", new DateTime(2025, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johnson", false, null, null, null, "AQAAAAIAAYagAAAAEKZfYPDDOePfx04ciFt85MnJ7dpXSNkfMy1ihgik0mH0wRqFRE007inIyoXSmIa5LA==", null, false, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: new Guid("0c2fb4ea-d631-4ce7-9f02-2f4c011c2160"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1749fadd-b32e-430d-80d4-68b041218bd3"));

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
