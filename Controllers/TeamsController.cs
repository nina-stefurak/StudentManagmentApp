using Microsoft.AspNetCore.Mvc;
using StudentProjectManager.Models;
using StudentProjectManager.Repository;
using System.Threading.Tasks;

namespace StudentProjectManager.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly TeamRepository _teamRepository;

        public TeamsController(TeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        // GET api/teams
        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _teamRepository.GetAllTeamsAsync();
            return Ok(teams);
        }

        // GET api/teams/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(string id)
        {
            var team = await _teamRepository.GetTeamByIdAsync(id);
            if (team != null)
            {
                return Ok(team);
            }
            return NotFound(new { Message = "Team not found" });
        }

        // POST api/teams
        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] Team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (team == null)
            {
                return BadRequest(new { Message = "Invalid team data" });
            }
            await _teamRepository.CreateTeamAsync(team);
            return CreatedAtAction(nameof(GetTeamById), new { id = team.Id }, team);
        }

        // PUT api/teams/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(string id, [FromBody] Team team)
        {
            if (team == null)
            {
                return BadRequest(new { Message = "Invalid team data" });
            }
            var existingTeam = await _teamRepository.GetTeamByIdAsync(id);
            if (existingTeam == null)
            {
                return NotFound(new { Message = "Team not found" });
            }
            await _teamRepository.UpdateTeamAsync(id, team);
            return NoContent();
        }

        // DELETE api/teams/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(string id)
        {
            var team = await _teamRepository.GetTeamByIdAsync(id);
            if (team == null)
            {
                return NotFound(new { Message = "Team not found" });
            }
            await _teamRepository.DeleteTeamAsync(id);
            return NoContent();
        }
    }
}
