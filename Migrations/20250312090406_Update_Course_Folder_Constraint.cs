using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartCards.Migrations
{
    /// <inheritdoc />
    public partial class Update_Course_Folder_Constraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseFolder",
                table: "CourseFolder");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ed75613b-975e-49b5-9c8d-05b85e2c52f3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f3058121-3827-48ed-b026-026afcb683e5");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CourseFolder",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseFolder",
                table: "CourseFolder",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5147), new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5161) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5164), new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5164) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5165), new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5165) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5166), new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5166) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5167), new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5168) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5168), new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5169) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5169), new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5170) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5171), new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5171) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5172), new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5172) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5173), new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5173) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5174), new DateTime(2025, 3, 12, 16, 4, 5, 958, DateTimeKind.Local).AddTicks(5174) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c3c4bd2-3727-4047-9e14-9d0731d59f2e", null, "Admin", "ADMIN" },
                    { "dbd6d154-ca9e-4ccd-be91-32788960dbb2", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseFolder_FolderId",
                table: "CourseFolder",
                column: "FolderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseFolder",
                table: "CourseFolder");

            migrationBuilder.DropIndex(
                name: "IX_CourseFolder_FolderId",
                table: "CourseFolder");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1c3c4bd2-3727-4047-9e14-9d0731d59f2e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dbd6d154-ca9e-4ccd-be91-32788960dbb2");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseFolder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseFolder",
                table: "CourseFolder",
                columns: new[] { "FolderId", "CourseId" });

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ed75613b-975e-49b5-9c8d-05b85e2c52f3", null, "Admin", "ADMIN" },
                    { "f3058121-3827-48ed-b026-026afcb683e5", null, "User", "USER" }
                });
        }
    }
}
