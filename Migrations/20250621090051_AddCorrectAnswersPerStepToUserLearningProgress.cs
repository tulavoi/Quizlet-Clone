using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizletClone.Migrations
{
    /// <inheritdoc />
    public partial class AddCorrectAnswersPerStepToUserLearningProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "42c177ff-dfcf-47e7-a45e-2e0ecfe5847f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e508fc3e-4fa9-445b-adcf-6cb09271b640");

            migrationBuilder.AddColumn<string>(
                name: "CorrectAnswersPerStep",
                table: "UserLearningProgresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5aa25022-8915-4a93-98e1-e6cc2c9fb3a3", null, "Admin", "ADMIN" },
                    { "633e15ac-84fd-4b33-93d6-fe9c62ae3d6d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5aa25022-8915-4a93-98e1-e6cc2c9fb3a3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "633e15ac-84fd-4b33-93d6-fe9c62ae3d6d");

            migrationBuilder.DropColumn(
                name: "CorrectAnswersPerStep",
                table: "UserLearningProgresses");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42c177ff-dfcf-47e7-a45e-2e0ecfe5847f", null, "User", "USER" },
                    { "e508fc3e-4fa9-445b-adcf-6cb09271b640", null, "Admin", "ADMIN" }
                });
        }
    }
}
