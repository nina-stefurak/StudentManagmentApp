using StudentManagmentApp.Models;

namespace StudentManagmentApp.Services.Contracts
{
    public class IProjectService
    {
        Task<List<ProjectModel>> GetProjects();
    }
}
