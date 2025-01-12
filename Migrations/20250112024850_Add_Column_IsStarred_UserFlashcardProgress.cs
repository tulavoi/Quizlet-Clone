using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartCards.Migrations
{
    /// <inheritdoc />
    public partial class Add_Column_IsStarred_UserFlashcardProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a4e4b19d-d661-4b6d-82c9-666e0281b22d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ef23c874-dfe0-4b53-bd39-3f256ecc7e57");

            migrationBuilder.DropColumn(
                name: "IsMark",
                table: "Flashcards");

            migrationBuilder.AddColumn<bool>(
                name: "IsStarred",
                table: "UserFlashcardProgress",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6849), new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6850) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6852), new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6852) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6854), new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6855) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6857), new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6857) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6859), new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6860) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6862), new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6863) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6864), new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6865) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6867), new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6867) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6869), new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6869) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6872), new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6872) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6874), new DateTime(2025, 1, 12, 9, 48, 49, 618, DateTimeKind.Local).AddTicks(6874) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68156ea4-b056-4d7e-a29f-2ac3812b9d63", null, "User", "USER" },
                    { "adc7a3f9-5b40-473d-867b-a7ebf063fc17", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "68156ea4-b056-4d7e-a29f-2ac3812b9d63");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "adc7a3f9-5b40-473d-867b-a7ebf063fc17");

            migrationBuilder.DropColumn(
                name: "IsStarred",
                table: "UserFlashcardProgress");

            migrationBuilder.AddColumn<bool>(
                name: "IsMark",
                table: "Flashcards",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(298), new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(299) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(301), new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(301) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(303), new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(303) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(305), new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(305) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(307), new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(307) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(309), new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(309) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(310), new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(311) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(312), new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(313) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(344), new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(345) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(346), new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(347) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(348), new DateTime(2025, 1, 10, 14, 59, 33, 968, DateTimeKind.Local).AddTicks(349) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a4e4b19d-d661-4b6d-82c9-666e0281b22d", null, "Admin", "ADMIN" },
                    { "ef23c874-dfe0-4b53-bd39-3f256ecc7e57", null, "User", "USER" }
                });
        }
    }
}
