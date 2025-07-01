using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizletClone.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionTypeToUserLearningProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5aa25022-8915-4a93-98e1-e6cc2c9fb3a3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "633e15ac-84fd-4b33-93d6-fe9c62ae3d6d");

            migrationBuilder.AddColumn<int>(
                name: "QuestionType",
                table: "UserLearningProgresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8440f7b9-91ff-4ae6-83ba-930ee4eeb0bb", null, "User", "USER" },
                    { "ed7289ba-f633-49ca-9a6d-ebd3e3e2c263", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8440f7b9-91ff-4ae6-83ba-930ee4eeb0bb");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ed7289ba-f633-49ca-9a6d-ebd3e3e2c263");

            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "UserLearningProgresses");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5aa25022-8915-4a93-98e1-e6cc2c9fb3a3", null, "Admin", "ADMIN" },
                    { "633e15ac-84fd-4b33-93d6-fe9c62ae3d6d", null, "User", "USER" }
                });
        }
    }
}
