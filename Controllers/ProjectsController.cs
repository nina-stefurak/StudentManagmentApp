using Microsoft.AspNetCore.Mvc;
using StudentProjectManager.Models;
using StudentProjectManager.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentProjectManager.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectRepository _projectRepository;

        public ProjectsController(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET api/projects
        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _projectRepository.GetAllProjectsAsync();
            if (projects == null || !projects.Any())
            {
                return NoContent(); // Returns a 204 No Content response
            }
            return Ok(projects); // Returns a 200 OK response with the list of projects
        }


        // GET api/projects/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(string id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project != null)
            {
                return Ok(project);
            }
            return NotFound(new { Message = "Project not found" });
        }

        // POST api/projects
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest(new { Message = "Invalid project data" });
            }
            await _projectRepository.CreateProjectAsync(project);
            return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
        }

        // PUT api/projects/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(string id, [FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest(new { Message = "Invalid project data" });
            }
            var existingProject = await _projectRepository.GetProjectByIdAsync(id);
            if (existingProject == null)
            {
                return NotFound(new { Message = "Project not found" });
            }
            await _projectRepository.UpdateProjectAsync(id, project);
            return NoContent();
        }

        // DELETE api/projects/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound(new { Message = "Project not found" });
            }
            await _projectRepository.DeleteProjectAsync(id);
            return NoContent();
        }
    }
}
