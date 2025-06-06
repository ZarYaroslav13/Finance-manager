using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserPreferencesIdTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("51f56c96-1b11-4ea7-882b-c708e9ed2f6d"));

            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("5eaac367-0358-44c2-a6a6-86d283a21c7c"));

            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("75c1b007-ae73-4332-a74c-693c40c1dc23"));

            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("96a5f51c-436e-46ea-a07d-451b6b620c61"));

            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("ca1172ae-492d-4551-88f8-b3f23316b457"));

            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("d432c173-ac20-4017-99dc-24f71266e19f"));

            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("e19ea988-0611-40b4-aaaa-77216a985eb0"));

            migrationBuilder.InsertData(
                table: "UserPreferences",
                columns: new[] { "Id", "DarkMode", "LanguageCode", "RightToLeft", "UserId" },
                values: new object[,]
                {
                    { new Guid("00039684-7db3-46ff-a0f5-b744f225c30e"), false, "it-IT", false, new Guid("00039684-7db3-46ff-a0f5-b744f225c30e") },
                    { new Guid("06a12d9c-20a2-4f39-8c13-68e0bdddbadb"), true, "en-US", false, new Guid("06a12d9c-20a2-4f39-8c13-68e0bdddbadb") },
                    { new Guid("0c2fb4ea-d631-4ce7-9f02-2f4c011c2160"), false, "km_KH", true, new Guid("0c2fb4ea-d631-4ce7-9f02-2f4c011c2160") },
                    { new Guid("1749fadd-b32e-430d-80d4-68b041218bd3"), false, "de-DE", false, new Guid("1749fadd-b32e-430d-80d4-68b041218bd3") },
                    { new Guid("47b38d98-ee54-409b-bf0b-2821ca8a20b0"), false, "en-US", false, new Guid("47b38d98-ee54-409b-bf0b-2821ca8a20b0") },
                    { new Guid("6085ec7e-1cd3-4302-a51e-0a216c738b79"), true, "uk-UA", false, new Guid("6085ec7e-1cd3-4302-a51e-0a216c738b79") },
                    { new Guid("b9d052fd-c677-4722-85ff-0a2a5aad4af1"), true, "fr-FR", false, new Guid("b9d052fd-c677-4722-85ff-0a2a5aad4af1") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("00039684-7db3-46ff-a0f5-b744f225c30e"));

            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("06a12d9c-20a2-4f39-8c13-68e0bdddbadb"));

            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("0c2fb4ea-d631-4ce7-9f02-2f4c011c2160"));

            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("1749fadd-b32e-430d-80d4-68b041218bd3"));

            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("47b38d98-ee54-409b-bf0b-2821ca8a20b0"));

            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("6085ec7e-1cd3-4302-a51e-0a216c738b79"));

            migrationBuilder.DeleteData(
                table: "UserPreferences",
                keyColumn: "Id",
                keyValue: new Guid("b9d052fd-c677-4722-85ff-0a2a5aad4af1"));

            migrationBuilder.InsertData(
                table: "UserPreferences",
                columns: new[] { "Id", "DarkMode", "LanguageCode", "RightToLeft", "UserId" },
                values: new object[,]
                {
                    { new Guid("51f56c96-1b11-4ea7-882b-c708e9ed2f6d"), false, "km_KH", true, new Guid("0c2fb4ea-d631-4ce7-9f02-2f4c011c2160") },
                    { new Guid("5eaac367-0358-44c2-a6a6-86d283a21c7c"), false, "de-DE", false, new Guid("1749fadd-b32e-430d-80d4-68b041218bd3") },
                    { new Guid("75c1b007-ae73-4332-a74c-693c40c1dc23"), true, "en-US", false, new Guid("06a12d9c-20a2-4f39-8c13-68e0bdddbadb") },
                    { new Guid("96a5f51c-436e-46ea-a07d-451b6b620c61"), true, "uk-UA", false, new Guid("6085ec7e-1cd3-4302-a51e-0a216c738b79") },
                    { new Guid("ca1172ae-492d-4551-88f8-b3f23316b457"), false, "en-US", false, new Guid("47b38d98-ee54-409b-bf0b-2821ca8a20b0") },
                    { new Guid("d432c173-ac20-4017-99dc-24f71266e19f"), true, "fr-FR", false, new Guid("b9d052fd-c677-4722-85ff-0a2a5aad4af1") },
                    { new Guid("e19ea988-0611-40b4-aaaa-77216a985eb0"), false, "it-IT", false, new Guid("00039684-7db3-46ff-a0f5-b744f225c30e") }
                });
        }
    }
}
