using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartCards.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_UserCourseProgress_Edit_PK_UserFlashcardProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFlashcardProgress_Flashcards_FlashcardId",
                table: "UserFlashcardProgress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFlashcardProgress",
                table: "UserFlashcardProgress");

            migrationBuilder.DropIndex(
                name: "IX_UserFlashcardProgress_UserId",
                table: "UserFlashcardProgress");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "68156ea4-b056-4d7e-a29f-2ac3812b9d63");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "adc7a3f9-5b40-473d-867b-a7ebf063fc17");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserFlashcardProgress");

            migrationBuilder.AddColumn<bool>(
                name: "isShuffle",
                table: "UserFlashcardProgress",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFlashcardProgress",
                table: "UserFlashcardProgress",
                columns: new[] { "UserId", "FlashcardId" });

            migrationBuilder.CreateTable(
                name: "UserCourseProgress",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    IsShuffle = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourseProgress", x => new { x.UserId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_UserCourseProgress_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
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
                values: new object[] { new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5450), new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5450) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5452), new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5453) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5455), new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5455) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5457), new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5457) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5458), new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5459) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5460), new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5461) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5462), new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5463) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5464), new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5464) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5466), new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5466) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5468), new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5468) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5469), new DateTime(2025, 1, 18, 15, 30, 30, 987, DateTimeKind.Local).AddTicks(5470) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ca8dbcd-180c-4c64-bd1d-ea4f6461c705", null, "User", "USER" },
                    { "f6a9ff81-4c6d-4949-90f0-c696845dc6fb", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseProgress_CourseId",
                table: "UserCourseProgress",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFlashcardProgress_Flashcards_FlashcardId",
                table: "UserFlashcardProgress",
                column: "FlashcardId",
                principalTable: "Flashcards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFlashcardProgress_Flashcards_FlashcardId",
                table: "UserFlashcardProgress");

            migrationBuilder.DropTable(
                name: "UserCourseProgress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFlashcardProgress",
                table: "UserFlashcardProgress");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6ca8dbcd-180c-4c64-bd1d-ea4f6461c705");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f6a9ff81-4c6d-4949-90f0-c696845dc6fb");

            migrationBuilder.DropColumn(
                name: "isShuffle",
                table: "UserFlashcardProgress");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserFlashcardProgress",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFlashcardProgress",
                table: "UserFlashcardProgress",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_UserFlashcardProgress_UserId",
                table: "UserFlashcardProgress",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFlashcardProgress_Flashcards_FlashcardId",
                table: "UserFlashcardProgress",
                column: "FlashcardId",
                principalTable: "Flashcards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
