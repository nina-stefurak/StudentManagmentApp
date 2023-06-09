using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public static async Task<List<ProjectModel>> Convert(this IQueryable<Project> project)//returns a list of project model objects
        {
            return await (from proj in project
                          select new ProjectModel
                          {
                              Id = proj.Id,
                              Title = proj.Title,
                              Description = proj.Description,
                              Requirements = proj.Requirements,
                              ProgrammingLanguages = proj.ProgrammingLanguages,
                              TechnologyStack = proj.TechnologyStack,
                              DifficultyLevel = proj.DifficultyLevel,
                              PlannedEndDate = proj.PlannedEndDate,
                              ActualEndDate = proj.ActualEndDate,
                              RepositoryLink = proj.RepositoryLink,
                              Status = proj.Status,
                              TeamId = proj.TeamId,
                              Visibility = proj.Visibility

                          }).ToListAsync();
        }

        public static Project Convert(this ProjectModel projectModel)
        {
            return new Project
            {
                //Id = projectModel.Id,
                Title = projectModel.Title,
                Description = projectModel.Description,
                Requirements = projectModel.Requirements,
                ProgrammingLanguages = projectModel.ProgrammingLanguages,
                TechnologyStack = projectModel.TechnologyStack,
                DifficultyLevel = projectModel.DifficultyLevel,
                PlannedEndDate = projectModel.PlannedEndDate,
                ActualEndDate = projectModel.ActualEndDate,
                RepositoryLink = projectModel.RepositoryLink,
                Status = projectModel.Status,
                TeamId = projectModel.TeamId,
                Visibility = projectModel.Visibility
            };
        }
    }
}
