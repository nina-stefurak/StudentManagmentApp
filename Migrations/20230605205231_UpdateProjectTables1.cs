using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagmentApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProjectTables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProgrammingLanguages",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgrammingLanguages",
                table: "Projects");
        }
    }
}
