using StudentManagmentApp.Entities;
using StudentManagmentApp.Models;

namespace StudentManagmentApp.Services.Contracts
{
    public interface IProjectService
    {
        Task<List<ProjectModel>> GetProjects();
        Task<List<Team>> GetTeams();
        Task<Project> AddProject(ProjectModel projectModel);
        Task UpdateProject(ProjectModel projectModel);
        Task DeleteProject(int id);
    }
}
