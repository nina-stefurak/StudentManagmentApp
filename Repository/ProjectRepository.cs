using MongoDB.Driver;
using StudentProjectManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentProjectManager.Repository
{
    public class ProjectRepository
    {
        private readonly IMongoCollection<Project> _projects;

        public ProjectRepository(IMongoDatabase database)
        {
            _projects = database.GetCollection<Project>("Projects");
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _projects.Find(proj => true).ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(string id)
        {
            return await _projects.Find<Project>(proj => proj.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateProjectAsync(Project project)
        {
            await _projects.InsertOneAsync(project);
        }

        public async Task UpdateProjectAsync(string id, Project project)
        {
            await _projects.ReplaceOneAsync(proj => proj.Id == id, project);
        }

        public async Task UpdateProject(Project project)
        {
            var filter = Builders<Project>.Filter.Eq(p => p.Id, project.Id);
            await _projects.ReplaceOneAsync(filter, project);
        }

        public async Task DeleteProjectAsync(string id)
        {
            await _projects.DeleteOneAsync(proj => proj.Id == id);
        }


    }
}
