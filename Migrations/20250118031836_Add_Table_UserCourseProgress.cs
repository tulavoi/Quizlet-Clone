using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartCards.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_UserCourseProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "68156ea4-b056-4d7e-a29f-2ac3812b9d63");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "adc7a3f9-5b40-473d-867b-a7ebf063fc17");

            migrationBuilder.AddColumn<bool>(
                name: "isShuffle",
                table: "UserFlashcardProgress",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserCourseProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    IsShuffle = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourseProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCourseProgress_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserCourseProgress_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7557), new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7557) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7559), new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7560) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7561), new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7562) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7563), new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7564) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7565), new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7566) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7567), new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7568) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7570), new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7570) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7572), new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7572) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7574), new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7574) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7576), new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7576) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7578), new DateTime(2025, 1, 18, 10, 18, 36, 63, DateTimeKind.Local).AddTicks(7578) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c9284070-967e-46cf-a69c-971de267c338", null, "Admin", "ADMIN" },
                    { "ff564b8b-5e59-4990-91db-23bd170f81ca", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseProgress_CourseId",
                table: "UserCourseProgress",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseProgress_UserId",
                table: "UserCourseProgress",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCourseProgress");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c9284070-967e-46cf-a69c-971de267c338");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ff564b8b-5e59-4990-91db-23bd170f81ca");

            migrationBuilder.DropColumn(
                name: "isShuffle",
                table: "UserFlashcardProgress");

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
    }
}
