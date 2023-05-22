using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagmentApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "ProgrammingLanguages", "SkillsRating", "Technologies" },
                values: new object[,]
                {
                    { 1, "bob.jones@oexl.com", "Bob", "Jones", "JavaScript, python", "4", "React Native, MongoDB, Angular" },
                    { 2, "jenny.marks@oexl.com", "Jenny", "Marks", "Java, JavaScript", "5", "MongoDB, SwiftUI, VueJS" },
                    { 3, "henry.andrews@oexl.com", "Henry", "Andrews", "C#, Java, SQL", "3", "MongoDB, SwiftUI, .NET Maui" },
                    { 4, "john.jameson@oexl.com", "John", "Jameson", "JavaScript, c++, php", "4", "React Native, MongoDB, Wrapping Up, VueJS, Angular" },
                    { 5, "noah.robinson@oexl.com", "Noah", "Robinson", "C#, Java, JavaScript", "2", "SwiftUI, .NET Maui, AWS" },
                    { 6, "elijah.hamilton@oexl.com", "Elijah", "Hamilton", "JavaScript, python,", "4", "React Native, VueJS, Angular" },
                    { 7, "jamie.fisher@oexl.com", "Jamie", "Fisher", "C#, Java, JavaScript", "5", "SwiftUI, .NET, Angular" },
                    { 8, "olivia.mills@oexl.com", "Olivia", "Mills", "C#, Java, JavaScript, SQL", "4", ".NET Maui, Wrapping Up, AWS, Angular" },
                    { 9, "benjamin.lucas@oexl.com", "Benjamin", "Lucas", "JavaScript, Ruby, pascal, c++", "3", "Wrapping Up, AWS, VueJS, Angular" },
                    { 10, "sarah.henderson@oexl.com", "Sarah", "Henderson", "C#, python, php, SQL", "5", "MongoDB, SwiftUI, .NET Maui, AWS" },
                    { 11, "emma.lee@oexl.com", "Emma", "Lee", "C#, Java, JavaScript, SQL", "2", "React Native, VueJS, Angular" },
                    { 12, "ava.williams@oexl.com", "Ava", "Williams", "C#, Java, JavaScript, Ruby", "4", "React Native, MongoDB, VueJS, Angular" },
                    { 13, "angela.moore@oexl.com", "Angela", "Moore", "C#, Java, python, php, SQL", "3", "React Native, MongoDB" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
