using Microsoft.EntityFrameworkCore;
using StudentManagmentApp.Entities;

namespace StudentManagmentApp.Data
{
    public static class SeedData
    {
        public static void AddUsersData(ModelBuilder modelBuilder)
        {
            //Add users

            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones",
                Email = "bob.jones@oexl.com",
                Technologies = "React Native, MongoDB, Angular",
                ProgrammingLanguages = "JavaScript, python",
                SkillsRating = "4"

            });

            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 2,
                FirstName = "Jenny",
                LastName = "Marks",
                Email = "jenny.marks@oexl.com",
                Technologies = "MongoDB, SwiftUI, VueJS",
                ProgrammingLanguages = "Java, JavaScript",
                SkillsRating = "5"

            });
            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 3,
                FirstName = "Henry",
                LastName = "Andrews",
                Email = "henry.andrews@oexl.com",
                Technologies = "MongoDB, SwiftUI, .NET Maui",
                ProgrammingLanguages = "C#, Java, SQL",
                SkillsRating = "3"

            });
            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 4,
                FirstName = "John",
                LastName = "Jameson",
                Email = "john.jameson@oexl.com",
                Technologies = "React Native, MongoDB, Wrapping Up, VueJS, Angular",
                ProgrammingLanguages = "JavaScript, c++, php",
                SkillsRating = "4"

            });

            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 5,
                FirstName = "Noah",
                LastName = "Robinson",
                Email = "noah.robinson@oexl.com",
                Technologies = "SwiftUI, .NET Maui, AWS",
                ProgrammingLanguages = "C#, Java, JavaScript",
                SkillsRating = "2"

            });
            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 6,
                FirstName = "Elijah",
                LastName = "Hamilton",
                Email = "elijah.hamilton@oexl.com",
                Technologies = "React Native, VueJS, Angular",
                ProgrammingLanguages = "JavaScript, python,",
                SkillsRating = "4"

            });
            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 7,
                FirstName = "Jamie",
                LastName = "Fisher",
                Email = "jamie.fisher@oexl.com",
                Technologies = "SwiftUI, .NET, Angular",
                ProgrammingLanguages = "C#, Java, JavaScript",
                SkillsRating = "5"

            });


            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 8,
                FirstName = "Olivia",
                LastName = "Mills",
                Email = "olivia.mills@oexl.com",
                Technologies = ".NET Maui, Wrapping Up, AWS, Angular",
                ProgrammingLanguages = "C#, Java, JavaScript, SQL",
                SkillsRating = "4"

            });
            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 9,
                FirstName = "Benjamin",
                LastName = "Lucas",
                Email = "benjamin.lucas@oexl.com",
                Technologies = "Wrapping Up, AWS, VueJS, Angular",
                ProgrammingLanguages = "JavaScript, Ruby, pascal, c++",
                SkillsRating = "3"
            });

            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 10,
                FirstName = "Sarah",
                LastName = "Henderson",
                Email = "sarah.henderson@oexl.com",
                Technologies = "MongoDB, SwiftUI, .NET Maui, AWS",
                ProgrammingLanguages = "C#, python, php, SQL",
                SkillsRating = "5"

            });
         
            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 11,
                FirstName = "Emma",
                LastName = "Lee",
                Email = "emma.lee@oexl.com",
                Technologies = "React Native, VueJS, Angular",
                ProgrammingLanguages = "C#, Java, JavaScript, SQL",
                SkillsRating = "2"

            });
            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 12,
                FirstName = "Ava",
                LastName = "Williams",
                Email = "ava.williams@oexl.com",
                Technologies = "React Native, MongoDB, VueJS, Angular",
                ProgrammingLanguages = "C#, Java, JavaScript, Ruby",
                SkillsRating = "4"

            });
            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = 13,
                FirstName = "Angela",
                LastName = "Moore",
                Email = "angela.moore@oexl.com",
                Technologies = "React Native, MongoDB",
                ProgrammingLanguages = "C#, Java, python, php, SQL",
                SkillsRating = "3"

            });
        }
    }
}
