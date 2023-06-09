﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagmentApp.Data;

#nullable disable

namespace StudentManagmentApp.Migrations
{
    [DbContext(typeof(StudentManagmentDbContext))]
    [Migration("20230607141345_UpdateTeams")]
    partial class UpdateTeams
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentManagmentApp.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ActualEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DifficultyLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PlannedEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProgrammingLanguages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RepositoryLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("TechnologyStack")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia.",
                            DifficultyLevel = "Medium",
                            PlannedEndDate = new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProgrammingLanguages = "C#, JS",
                            Requirements = "Understanding of Algorithms and Data Structures",
                            Status = "Created",
                            TeamId = 1,
                            TechnologyStack = "MongoDB, ASP.NET, SQL",
                            Title = "Mirage app"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia.",
                            DifficultyLevel = "Low",
                            PlannedEndDate = new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProgrammingLanguages = "C#, JS",
                            Requirements = "Understanding of Algorithms and Data Structures",
                            Status = "Started",
                            TeamId = 2,
                            TechnologyStack = "ASP.NET, SQL",
                            Title = "Nexus app"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lorem ipsum dolor sit amet. Qui esse quos est impedit ipsa et modi saepe in culpa quia.",
                            DifficultyLevel = "High",
                            PlannedEndDate = new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProgrammingLanguages = "JS",
                            Requirements = "Understanding of Algorithms and Data Structures",
                            Status = "Created",
                            TeamId = 3,
                            TechnologyStack = "Angular",
                            Title = "Echo app"
                        });
                });

            modelBuilder.Entity("StudentManagmentApp.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            Name = "Mirage"
                        },
                        new
                        {
                            TeamId = 2,
                            Name = "Nexus"
                        },
                        new
                        {
                            TeamId = 3,
                            Name = "Echo"
                        });
                });

            modelBuilder.Entity("StudentManagmentApp.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgrammingLanguages")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SkillsRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Technologies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "bob.jones@oexl.com",
                            FirstName = "Bob",
                            LastName = "Jones",
                            ProgrammingLanguages = "JavaScript, python",
                            SkillsRating = "4",
                            Technologies = "React Native, MongoDB, Angular"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jenny.marks@oexl.com",
                            FirstName = "Jenny",
                            LastName = "Marks",
                            ProgrammingLanguages = "Java, JavaScript",
                            SkillsRating = "5",
                            Technologies = "MongoDB, SwiftUI, VueJS"
                        },
                        new
                        {
                            Id = 3,
                            Email = "henry.andrews@oexl.com",
                            FirstName = "Henry",
                            LastName = "Andrews",
                            ProgrammingLanguages = "C#, Java, SQL",
                            SkillsRating = "3",
                            Technologies = "MongoDB, SwiftUI, .NET Maui"
                        },
                        new
                        {
                            Id = 4,
                            Email = "john.jameson@oexl.com",
                            FirstName = "John",
                            LastName = "Jameson",
                            ProgrammingLanguages = "JavaScript, c++, php",
                            SkillsRating = "4",
                            Technologies = "React Native, MongoDB, Wrapping Up, VueJS, Angular"
                        },
                        new
                        {
                            Id = 5,
                            Email = "noah.robinson@oexl.com",
                            FirstName = "Noah",
                            LastName = "Robinson",
                            ProgrammingLanguages = "C#, Java, JavaScript",
                            SkillsRating = "2",
                            Technologies = "SwiftUI, .NET Maui, AWS"
                        },
                        new
                        {
                            Id = 6,
                            Email = "elijah.hamilton@oexl.com",
                            FirstName = "Elijah",
                            LastName = "Hamilton",
                            ProgrammingLanguages = "JavaScript, python,",
                            SkillsRating = "4",
                            Technologies = "React Native, VueJS, Angular"
                        },
                        new
                        {
                            Id = 7,
                            Email = "jamie.fisher@oexl.com",
                            FirstName = "Jamie",
                            LastName = "Fisher",
                            ProgrammingLanguages = "C#, Java, JavaScript",
                            SkillsRating = "5",
                            Technologies = "SwiftUI, .NET, Angular"
                        },
                        new
                        {
                            Id = 8,
                            Email = "olivia.mills@oexl.com",
                            FirstName = "Olivia",
                            LastName = "Mills",
                            ProgrammingLanguages = "C#, Java, JavaScript, SQL",
                            SkillsRating = "4",
                            Technologies = ".NET Maui, Wrapping Up, AWS, Angular"
                        },
                        new
                        {
                            Id = 9,
                            Email = "benjamin.lucas@oexl.com",
                            FirstName = "Benjamin",
                            LastName = "Lucas",
                            ProgrammingLanguages = "JavaScript, Ruby, pascal, c++",
                            SkillsRating = "3",
                            Technologies = "Wrapping Up, AWS, VueJS, Angular"
                        },
                        new
                        {
                            Id = 10,
                            Email = "sarah.henderson@oexl.com",
                            FirstName = "Sarah",
                            LastName = "Henderson",
                            ProgrammingLanguages = "C#, python, php, SQL",
                            SkillsRating = "5",
                            Technologies = "MongoDB, SwiftUI, .NET Maui, AWS"
                        },
                        new
                        {
                            Id = 11,
                            Email = "emma.lee@oexl.com",
                            FirstName = "Emma",
                            LastName = "Lee",
                            ProgrammingLanguages = "C#, Java, JavaScript, SQL",
                            SkillsRating = "2",
                            Technologies = "React Native, VueJS, Angular"
                        },
                        new
                        {
                            Id = 12,
                            Email = "ava.williams@oexl.com",
                            FirstName = "Ava",
                            LastName = "Williams",
                            ProgrammingLanguages = "C#, Java, JavaScript, Ruby",
                            SkillsRating = "4",
                            Technologies = "React Native, MongoDB, VueJS, Angular"
                        },
                        new
                        {
                            Id = 13,
                            Email = "angela.moore@oexl.com",
                            FirstName = "Angela",
                            LastName = "Moore",
                            ProgrammingLanguages = "C#, Java, python, php, SQL",
                            SkillsRating = "3",
                            Technologies = "React Native, MongoDB"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
