using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartCards.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseProgress_Courses_CourseId",
                table: "UserCourseProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseProgress_Users_UserId",
                table: "UserCourseProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFlashcardProgress_Flashcards_FlashcardId",
                table: "UserFlashcardProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFlashcardProgress_Users_UserId",
                table: "UserFlashcardProgress");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6ca8dbcd-180c-4c64-bd1d-ea4f6461c705");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f6a9ff81-4c6d-4949-90f0-c696845dc6fb");

            migrationBuilder.RenameColumn(
                name: "isShuffle",
                table: "UserFlashcardProgress",
                newName: "IsViewed");

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(342), new DateTime(2025, 2, 12, 16, 7, 26, 912, DateTimeKind.Local).AddTicks(342) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f3547e3-0747-49b1-aebb-2761ec279ff2", null, "User", "USER" },
                    { "88e45a21-37aa-497a-8460-edabe9246c15", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseProgress_Courses_CourseId",
                table: "UserCourseProgress",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseProgress_Users_UserId",
                table: "UserCourseProgress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFlashcardProgress_Flashcards_FlashcardId",
                table: "UserFlashcardProgress",
                column: "FlashcardId",
                principalTable: "Flashcards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFlashcardProgress_Users_UserId",
                table: "UserFlashcardProgress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseProgress_Courses_CourseId",
                table: "UserCourseProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseProgress_Users_UserId",
                table: "UserCourseProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFlashcardProgress_Flashcards_FlashcardId",
                table: "UserFlashcardProgress");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFlashcardProgress_Users_UserId",
                table: "UserFlashcardProgress");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0f3547e3-0747-49b1-aebb-2761ec279ff2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "88e45a21-37aa-497a-8460-edabe9246c15");

            migrationBuilder.RenameColumn(
                name: "IsViewed",
                table: "UserFlashcardProgress",
                newName: "isShuffle");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseProgress_Courses_CourseId",
                table: "UserCourseProgress",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseProgress_Users_UserId",
                table: "UserCourseProgress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFlashcardProgress_Flashcards_FlashcardId",
                table: "UserFlashcardProgress",
                column: "FlashcardId",
                principalTable: "Flashcards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFlashcardProgress_Users_UserId",
                table: "UserFlashcardProgress",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
