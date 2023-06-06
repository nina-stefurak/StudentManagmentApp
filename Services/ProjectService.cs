using Microsoft.Identity.Client;
using StudentManagmentApp.Data;
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
        public async Task<List<ProjectModel>> GetProjects()
        {
			try
			{
                var project = await this.studentManagmentDbContext.Projects.Convert(studentManagmentDbContext);
                return project;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
