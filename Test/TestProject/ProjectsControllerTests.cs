
using Xunit;
using Moq;
using StudentProjectManager.Controllers;
using StudentProjectManager.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using StudentProjectManager.Repository;

namespace StudentProjectManagerTests
{
    public class ProjectsControllerTests
    {
        private readonly Mock<ProjectRepository> _mockProjectRepository;
        private readonly ProjectsController _controller;

        public ProjectsControllerTests()
        {
            _mockProjectRepository = new Mock<ProjectRepository>();
            _controller = new ProjectsController(_mockProjectRepository.Object);
        }

        [Fact]
        public async Task GetProjectByIdAsync_ShouldReturnProject_WhenProjectExists()
        {
            // Arrange
            var projectId = "1";
            var project = new Project
            {
                Id = projectId,
                Name = "Test Project"
            };
            _mockProjectRepository.Setup(repo => repo.GetProjectByIdAsync(projectId)).ReturnsAsync(project);

            // Act
            var result = await _controller.GetProjectById(projectId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Project>(okResult.Value);
            Assert.Equal(projectId, returnValue.Id);
        }


        [Fact]
        public async Task GetProjectByIdAsync_ShouldReturnNotFound_WhenProjectDoesNotExist()
        {
            // Arrange
            var projectId = "2";
            _mockProjectRepository.Setup(repo => repo.GetProjectByIdAsync(projectId)).ReturnsAsync((Project)null);

            // Act
            var result = await _controller.GetProjectById(projectId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task GetAllProjectsAsync_ShouldReturnProjects()
        {
            // Arrange
            var projects = new List<Project>
        {
            new Project { Id = "1", Name = "Project1" },
            new Project { Id = "2", Name = "Project2" }
        };
            _mockProjectRepository.Setup(repo => repo.GetAllProjectsAsync()).ReturnsAsync(projects);

            // Act
            var result = await _controller.GetAllProjects();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Project>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetAllProjectsAsync_ShouldReturnListOfProjects_WhenProjectsExist()
        {
            // Arrange
            var projects = new List<Project>
    {
        new Project { Id = "1", Name = "Project1" },
        new Project { Id = "2", Name = "Project2" }
    };
            _mockProjectRepository.Setup(repo => repo.GetAllProjectsAsync()).ReturnsAsync(projects);

            // Act
            var result = await _controller.GetAllProjects();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Project>>(okResult.Value);
            Assert.Equal(projects.Count, returnValue.Count);
        }

        [Fact]
        public async Task GetAllProjectsAsync_ShouldReturnNoContent_WhenNoProjectsExist()
        {
            // Arrange
            _mockProjectRepository.Setup(repo => repo.GetAllProjectsAsync()).ReturnsAsync(new List<Project>());

            // Act
            var result = await _controller.GetAllProjects();

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task CreateProjectAsync_ShouldReturnCreatedAtAction_WhenModelStateIsValid()
        {
            // Arrange
            var project = new Project { Id = "1", Name = "Project1" };
            _mockProjectRepository.Setup(repo => repo.CreateProjectAsync(project));

            // Act
            var result = await _controller.CreateProject(project);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
    }
}
