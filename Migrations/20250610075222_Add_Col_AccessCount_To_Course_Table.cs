using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizletClone.Migrations
{
    /// <inheritdoc />
    public partial class Add_Col_AccessCount_To_Course_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "98326afa-0330-4a40-b4f5-85263f45c440");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "eb888ac0-36ef-47c2-b13d-ec1184d8ea0a");

            migrationBuilder.AddColumn<int>(
                name: "AccessCount",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42c177ff-dfcf-47e7-a45e-2e0ecfe5847f", null, "User", "USER" },
                    { "e508fc3e-4fa9-445b-adcf-6cb09271b640", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "42c177ff-dfcf-47e7-a45e-2e0ecfe5847f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e508fc3e-4fa9-445b-adcf-6cb09271b640");

            migrationBuilder.DropColumn(
                name: "AccessCount",
                table: "Courses");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "98326afa-0330-4a40-b4f5-85263f45c440", null, "Admin", "ADMIN" },
                    { "eb888ac0-36ef-47c2-b13d-ec1184d8ea0a", null, "User", "USER" }
                });
        }
    }
}
