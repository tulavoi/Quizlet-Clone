using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizletClone.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_UserFlashcardProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "23dabafa-fe42-4991-bd21-2706a5b9b5e6");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3e30e206-a412-496d-ad26-6c1c198b8dbe");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "UserFlashcardProgress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlashcardId = table.Column<int>(type: "int", nullable: false),
                    IsLearned = table.Column<bool>(type: "bit", nullable: false),
                    LastReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFlashcardProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFlashcardProgress_Flashcards_FlashcardId",
                        column: x => x.FlashcardId,
                        principalTable: "Flashcards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserFlashcardProgress_Users_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_UserFlashcardProgress_FlashcardId",
                table: "UserFlashcardProgress",
                column: "FlashcardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFlashcardProgress_UserId",
                table: "UserFlashcardProgress",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFlashcardProgress");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a4e4b19d-d661-4b6d-82c9-666e0281b22d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ef23c874-dfe0-4b53-bd39-3f256ecc7e57");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7201), new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7201) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7205), new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7205) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7207), new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7210), new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7212), new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7213) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7215), new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7215) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7217), new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7218) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7220), new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7222), new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7222) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7224), new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7225) });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7227), new DateTime(2025, 1, 2, 11, 39, 37, 303, DateTimeKind.Local).AddTicks(7227) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "23dabafa-fe42-4991-bd21-2706a5b9b5e6", null, "User", "USER" },
                    { "3e30e206-a412-496d-ad26-6c1c198b8dbe", null, "Admin", "ADMIN" }
                });
        }
    }
}
