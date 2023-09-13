using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using StudentProjectManager.Models.auth;
using StudentProjectManager.Models;

namespace StudentProjectManager.Repository
{
    public class TeamRepository
    {
        private readonly IMongoCollection<Team> _teams;
        private readonly UserManager<ApplicationUser> _userManager;

        public TeamRepository(IMongoDatabase database, UserManager<ApplicationUser> userManager)
        {
            _teams = database.GetCollection<Team>("Teams");
            _userManager = userManager;
        }

        public async Task CreateTeam(Team team)
        {
            await _teams.InsertOneAsync(team);
        }

        public async Task<Team> GetTeamById(string teamId)
        {
            var team = await _teams.Find(t => t.Id == teamId).FirstOrDefaultAsync();
            var members = _userManager.Users.Where(u => team.MemberUserIds.Contains(u.Id)).ToList();
            team.GetCapabilities(members);
            team.GetPositions(members);
            return team;
        }

        public async Task<List<Team>> GetAllTeamsAsync()
        {
            var teams = await _teams.Find(t => true).ToListAsync();

            foreach (var team in teams)
            {
                var members = _userManager.Users.Where(u => team.MemberUserIds.Contains(u.Id)).ToList();
                team.GetCapabilities(members);
                team.GetPositions(members);
            }

            return teams;
        }

        public async Task UpdateTeam(Team team)
        {
            var filter = Builders<Team>.Filter.Eq(t => t.Id, team.Id);
            await _teams.ReplaceOneAsync(filter, team);
        }

        public async Task DeleteTeam(string teamId)
        {
            await _teams.DeleteOneAsync(t => t.Id == teamId);
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return _userManager.Users.ToList();
        }

    }

}
