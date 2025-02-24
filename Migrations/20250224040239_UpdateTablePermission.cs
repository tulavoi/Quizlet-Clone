using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartCards.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablePermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CoursePermissions",
                table: "CoursePermissions");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1119d6cd-b873-47fa-8037-4317657b255d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e1129a00-4d77-4dfa-93cb-bb0f92165007");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Permissions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Permissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoursePermissions",
                table: "CoursePermissions",
                column: "CourseId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CoursePermissions",
                table: "CoursePermissions");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "56389e97-cae8-44e6-b2aa-d6cf97d295ee");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a6cc1ac6-16ce-42b5-b5aa-a407ceccfdc2");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Permissions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Permissions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoursePermissions",
                table: "CoursePermissions",
                columns: new[] { "CourseId", "EditPermissionId", "ViewPermissionId" });

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3909), new DateTime(2025, 2, 12, 16, 44, 3, 826, DateTimeKind.Local).AddTicks(3909) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1119d6cd-b873-47fa-8037-4317657b255d", null, "Admin", "ADMIN" },
                    { "e1129a00-4d77-4dfa-93cb-bb0f92165007", null, "User", "USER" }
                });
        }
    }
}
