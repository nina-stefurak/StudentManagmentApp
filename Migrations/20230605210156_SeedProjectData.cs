using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagmentApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedProjectData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ActualEndDate", "Description", "DifficultyLevel", "PlannedEndDate", "ProgrammingLanguages", "RepositoryLink", "Requirements", "Status", "TeamId", "TechnologyStack", "Title" },
                values: new object[,]
                {
                    { 1, null, "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia.", "Medium", new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#, JS", null, "Understanding of Algorithms and Data Structures", "Created", 1, "MongoDB, ASP.NET, SQL", "Mirage app" },
                    { 2, null, "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia.", "Low", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "C#, JS", null, "Understanding of Algorithms and Data Structures", "Started", 2, "ASP.NET, SQL", "Nexus app" },
                    { 3, null, "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia.", "High", new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "JS", null, "Understanding of Algorithms and Data Structures", "Created", 3, "Angular", "Echo app" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mirage" },
                    { 2, "Nexus" },
                    { 3, "Echo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
