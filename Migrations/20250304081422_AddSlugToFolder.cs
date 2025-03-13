using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizletClone.Migrations
{
    /// <inheritdoc />
    public partial class AddSlugToFolder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "56389e97-cae8-44e6-b2aa-d6cf97d295ee");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a6cc1ac6-16ce-42b5-b5aa-a407ceccfdc2");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Folders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1316), new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1316) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1318), new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1319) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1320), new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1321) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1322), new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1322) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1324), new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1324) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1326), new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1326) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1328), new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1328) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1330), new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1330) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1331), new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1332) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1388), new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1389) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1391), new DateTime(2025, 3, 4, 15, 14, 21, 329, DateTimeKind.Local).AddTicks(1391) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: 3);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ed75613b-975e-49b5-9c8d-05b85e2c52f3", null, "Admin", "ADMIN" },
                    { "f3058121-3827-48ed-b026-026afcb683e5", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ed75613b-975e-49b5-9c8d-05b85e2c52f3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f3058121-3827-48ed-b026-026afcb683e5");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Folders");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(555), new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(555) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(557), new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(558) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(559), new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(559) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(561), new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(561) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(562), new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(563) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(564), new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(564) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(566), new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(566) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(568), new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(568) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(569), new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(571), new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(571) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(573), new DateTime(2025, 2, 24, 11, 2, 38, 762, DateTimeKind.Local).AddTicks(573) });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: 2);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "56389e97-cae8-44e6-b2aa-d6cf97d295ee", null, "User", "USER" },
                    { "a6cc1ac6-16ce-42b5-b5aa-a407ceccfdc2", null, "Admin", "ADMIN" }
                });
        }
    }
}
