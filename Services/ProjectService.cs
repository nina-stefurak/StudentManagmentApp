using Microsoft.EntityFrameworkCore;
using StudentManagmentApp.Data;
using StudentManagmentApp.Entities;
using StudentManagmentApp.Extensions;
using StudentManagmentApp.Models;
using StudentManagmentApp.Services.Contracts;

namespace StudentManagmentApp.Services
{
    public class ProjectService : IProjectService
    {
        private readonly StudentManagmentDbContext studentManagmentDbContext;
        public ProjectService(StudentManagmentDbContext studentManagmentDbContext)
        {
            this.studentManagmentDbContext = studentManagmentDbContext;
        }

        public async Task<Project> AddProject(ProjectModel projectModel)
        {
            try
            {
                Project projectToAdd = projectModel.Convert();

                var result = await this.studentManagmentDbContext.Project.AddAsync(projectToAdd);

                await this.studentManagmentDbContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task DeleteProject(int id)
        {
            try
            {
                var project = await this.studentManagmentDbContext.Project.FindAsync(id);
                if (project != null)
                {
                    this.studentManagmentDbContext.Project.Remove(project);
                    await this.studentManagmentDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<ProjectModel>> GetProjects()
        {
			try
			{
                return await this.studentManagmentDbContext.Project.Convert();
			}
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<List<Team>> GetTeams()
        {
            try
            {
                return await this.studentManagmentDbContext.Teams.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateProject(ProjectModel projectModel)
        {
            try
            {
                var projectToUpdate = await this.studentManagmentDbContext.Project.FindAsync(projectModel.Id);

                if (projectToUpdate != null)
                {
                    projectToUpdate.Title = projectModel.Title;
                    projectToUpdate.Description = projectModel.Description;
                    projectToUpdate.Requirements = projectModel.Requirements;
                    projectToUpdate.ProgrammingLanguages = projectModel.ProgrammingLanguages;
                    projectToUpdate.TechnologyStack = projectModel.TechnologyStack;
                    projectToUpdate.DifficultyLevel = projectModel.DifficultyLevel;
                    projectToUpdate.PlannedEndDate = projectModel.PlannedEndDate;
                    projectToUpdate.ActualEndDate = projectModel.ActualEndDate;
                    projectToUpdate.RepositoryLink = projectModel.RepositoryLink;
                    projectToUpdate.Status = projectModel.Status;
                    projectToUpdate.TeamId = projectModel.TeamId;
                    projectToUpdate.Visibility = projectModel.Visibility;

                    await this.studentManagmentDbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
