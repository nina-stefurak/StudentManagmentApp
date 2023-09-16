
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentProjectManager.Controllers;
using StudentProjectManager.Models;
using StudentProjectManager.Repository;
using Xunit;

namespace StudentProjectManagerTests
{
    public class TeamsControllerTests
    {
        private readonly TeamsController _controller;
        private readonly Mock<TeamRepository> _mockTeamRepository;

        public TeamsControllerTests()
        {
            _mockTeamRepository = new Mock<TeamRepository>();
            _controller = new TeamsController(_mockTeamRepository.Object);
        }

        [Fact]
        public async Task GetAllTeamsAsync_ShouldReturnOkResult_WithListOfTeams()
        {
            // Arrange
            var teams = new List<Team> { new Team { Id = "1", Name = "Team1" }, new Team { Id = "2", Name = "Team2" } };
            _mockTeamRepository.Setup(repo => repo.GetAllTeamsAsync()).ReturnsAsync(teams);

            // Act
            var result = await _controller.GetAllTeams();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnTeams = Assert.IsType<List<Team>>(okResult.Value);
            Assert.Equal(2, returnTeams.Count);
        }

        [Fact]
        public async Task GetTeamByIdAsync_ShouldReturnOkResult_WithTeam()
        {
            // Arrange
            var teamId = "1";
            var team = new Team { Id = teamId, Name = "Team1" };
            _mockTeamRepository.Setup(repo => repo.GetTeamByIdAsync(teamId)).ReturnsAsync(team);

            // Act
            var result = await _controller.GetTeamById(teamId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnTeam = Assert.IsType<Team>(okResult.Value);
            Assert.Equal(teamId, returnTeam.Id);
        }

        [Fact]
        public async Task GetTeamByIdAsync_ShouldReturnNotFound_WhenTeamDoesNotExist()
        {
            // Arrange
            var teamId = "non_existing_id";
            _mockTeamRepository.Setup(repo => repo.GetTeamByIdAsync(teamId)).ReturnsAsync((Team)null);

            // Act
            var result = await _controller.GetTeamById(teamId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }


        [Fact]
        public async Task CreateTeamAsync_ShouldReturnCreatedAtAction_WhenModelStateIsValid()
        {
            // Arrange
            var team = new Team { Id = "1", Name = "Team1" };
            _mockTeamRepository.Setup(repo => repo.CreateTeamAsync(team));

            // Act
            var result = await _controller.CreateTeam(team);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnTeam = Assert.IsType<Team>(createdAtActionResult.Value);
            Assert.Equal("GetTeamById", createdAtActionResult.ActionName);
            Assert.Equal(team.Id, returnTeam.Id);
        }

        [Fact]
        public async Task CreateTeamAsync_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Name", "Required");
            var team = new Team { Id = "1", Name = "" };

            // Act
            var result = await _controller.CreateTeam(team);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateTeamAsync_ShouldReturnNoContent_WhenTeamExists()
        {
            // Arrange
            var teamId = "1";
            var team = new Team { Id = teamId, Name = "Team1" };
            _mockTeamRepository.Setup(repo => repo.GetTeamByIdAsync(teamId)).ReturnsAsync(team);
            _mockTeamRepository.Setup(repo => repo.UpdateTeamAsync(teamId, team)).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateTeam(teamId, team);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateTeamAsync_ShouldReturnNotFound_WhenTeamDoesNotExist()
        {
            // Arrange
            var teamId = "non_existing_id";
            var teamToUpdate = new Team { Id = teamId, Name = "Team Name" };
            _mockTeamRepository.Setup(repo => repo.GetTeamByIdAsync(teamId)).ReturnsAsync((Team)null);

            // Act
            var result = await _controller.UpdateTeam(teamId, teamToUpdate);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }


        [Fact]
        public async Task DeleteTeamAsync_ShouldReturnNoContent_WhenTeamExists()
        {
            // Arrange
            var teamId = "1";
            var team = new Team { Id = teamId, Name = "Team1" };
            _mockTeamRepository.Setup(repo => repo.GetTeamByIdAsync(teamId)).ReturnsAsync(team);
            _mockTeamRepository.Setup(repo => repo.DeleteTeamAsync(teamId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteTeam(teamId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteTeamAsync_ShouldReturnNotFound_WhenTeamDoesNotExist()
        {
            // Arrange
            var teamId = "non_existing_id";
            _mockTeamRepository.Setup(repo => repo.GetTeamByIdAsync(teamId)).ReturnsAsync((Team)null);

            // Act
            var result = await _controller.DeleteTeam(teamId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

    }
}
