using Microsoft.EntityFrameworkCore;
using StudentManagmentApp.Entities;

namespace StudentManagmentApp.Data
{
    public class StudentManagmentDbContext : DbContext
    {
        public StudentManagmentDbContext(DbContextOptions<StudentManagmentDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData.AddUsersData(modelBuilder);

            SeedData.AddProjectData(modelBuilder);
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}
