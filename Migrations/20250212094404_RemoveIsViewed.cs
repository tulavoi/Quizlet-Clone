using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizletClone.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsViewed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0f3547e3-0747-49b1-aebb-2761ec279ff2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "88e45a21-37aa-497a-8460-edabe9246c15");

            migrationBuilder.DropColumn(
                name: "IsViewed",
                table: "UserFlashcardProgress");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3889), new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3889) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3891), new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3891) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3893), new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3893) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3895), new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3895) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3897), new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3897) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3899), new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3899) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3901), new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3901) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3903), new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3903) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3905), new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3905) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3907), new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3907) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3909), "Vietnamese", new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3909) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1119d6cd-b873-47fa-8037-4317657b255d", null, "Admin", "ADMIN" },
                    { "e1129a00-4d77-4dfa-93cb-bb0f92165007", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1119d6cd-b873-47fa-8037-4317657b255d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e1129a00-4d77-4dfa-93cb-bb0f92165007");

            migrationBuilder.AddColumn<bool>(
                name: "IsViewed",
                table: "UserFlashcardProgress",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(321), new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(322) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(324), new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(324) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(326), new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(326) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(328), new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(328) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(330), new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(331) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(332), new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(332) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(334), new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(334) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(336), new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(336) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(338), new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(338) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(340), new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(340) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(342), "Việt Nam", new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(342) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f3547e3-0747-49b1-aebb-2761ec279ff2", null, "User", "USER" },
                    { "88e45a21-37aa-497a-8460-edabe9246c15", null, "Admin", "ADMIN" }
                });
        }
    }
}
