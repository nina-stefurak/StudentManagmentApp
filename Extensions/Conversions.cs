using Microsoft.EntityFrameworkCore;
using StudentManagmentApp.Data;
using StudentManagmentApp.Entities;
using StudentManagmentApp.Models;

namespace StudentManagmentApp.Extensions
{
    public static class Conversions
    {
        public static async Task<List<UsersModel>> Convert(this IQueryable<Users> users)//returns a list of users model objects
        {
            return await (from u in users 
                          select new UsersModel
                        {
                              Id = u.Id,
                              FirstName = u.FirstName,
                              LastName = u.LastName,
                              Email = u.Email,
                              Technologies = u.Technologies,
                              ProgrammingLanguages = u.ProgrammingLanguages,
                              SkillsRating = u.SkillsRating,

                        }).ToListAsync();
        }
        public static Users Convert(this UsersModel usersModel)
        {
            return new Users
            {
                FirstName = usersModel.FirstName,
                LastName = usersModel.LastName,
                Email = usersModel.Email,
                Technologies = usersModel.Technologies,
                ProgrammingLanguages = usersModel.ProgrammingLanguages,
                SkillsRating = usersModel.SkillsRating,
            };

        }

        public static async Task<List<ProjectModel>> Convert(this IQueryable<Project> Projects,
                                                             StudentManagmentDbContext context)
        {
            return await (from proj in Projects
                          join projTeam in context.Teams
                          on proj.TeamId equals projTeam.Id
                          select new ProjectModel
                          {
                              Id = proj.Id,
                              Title = proj.Title,
                              Description = proj.Description,
                              Requirements = proj.Requirements,
                              ProgrammingLanguages=proj.ProgrammingLanguages,
                              TechnologyStack = proj.TechnologyStack,
                              DifficultyLevel = proj.DifficultyLevel,
                              PlannedEndDate = proj.PlannedEndDate,
                              ActualEndDate = proj.ActualEndDate,
                              RepositoryLink = proj.RepositoryLink,
                              Status = proj.Status,
                              TeamId = proj.TeamId,
                              TeamName = projTeam.Name
                          }).ToListAsync();
        }
    }
}
