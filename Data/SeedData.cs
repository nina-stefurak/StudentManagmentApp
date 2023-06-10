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

        public static void AddProjectData(ModelBuilder modelBuilder)
        {
            //Add Teams -Mirage - Nexus - Echo

            modelBuilder.Entity<Team>().HasData(new Team
            {
                TeamId = 1,
                Name = "Mirage"

            });
            modelBuilder.Entity<Team>().HasData(new Team
            {
                TeamId = 2,
                Name = "Nexus"

            });
            modelBuilder.Entity<Team>().HasData(new Team
            {
                TeamId = 3,
                Name = "Echo"

            });
            //Projects
            //Team Stars
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 1,
                Title = "Mirage app",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia.",
                Requirements = "Understanding of Algorithms and Data Structures",
                ProgrammingLanguages = "C#, JS",
                TechnologyStack = "MongoDB, ASP.NET, SQL",//MongoDB,ASP.NET,Microsoft SQL Server
                DifficultyLevel = "Medium",//Low, medium, High, 
                PlannedEndDate = DateTime.Parse("10 Jun 2023"),
                ActualEndDate = null,
                RepositoryLink = null,
                Status = "Create",//Created, Completed lineup, Started, Finished stage, Added feature, Tested, Finished
                TeamId = 1,
                Visibility = "Public"

            });
            //Team Nexus
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 2,
                Title = "Nexus app",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia.",
                Requirements = "Understanding of Algorithms and Data Structures",
                ProgrammingLanguages = "C#, JS",
                TechnologyStack = "ASP.NET, SQL",//MongoDB,ASP.NET,Microsoft SQL Server
                DifficultyLevel = "Low",//Low, medium, High, 
                PlannedEndDate = DateTime.Parse("15 Jun 2023"),
                ActualEndDate = null,
                RepositoryLink = null,
                Status = "Started",//Created, Completed lineup, Started, Finished stage, Added feature, Tested, Finished
                TeamId = 2,
                Visibility = "Public"

            });
            //Team Echo
            modelBuilder.Entity<Project>().HasData(new Project
            {
                Id = 3,
                Title = "Echo app",
                Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia.",
                Requirements = "Understanding of Algorithms and Data Structures",
                ProgrammingLanguages = "JS",
                TechnologyStack = "Angular",//MongoDB,ASP.NET,Microsoft SQL Server
                DifficultyLevel = "High",//Low, medium, High, 
                PlannedEndDate = DateTime.Parse("20 Jun 2023"),
                ActualEndDate = null,
                RepositoryLink = null,
                Status = "Create",//Created, Completed lineup, Started, Finished stage, Added feature, Tested, Finished
                TeamId = 3,
                Visibility = "Public"

            });
        }

    }
}
