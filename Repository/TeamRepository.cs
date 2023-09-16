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

        public TeamRepository() { }

        public virtual async Task CreateTeam(Team team)
        {
            await _teams.InsertOneAsync(team);
        }

        public virtual async Task<Team> GetTeamById(string teamId)
        {
            var team = await _teams.Find(t => t.Id == teamId).FirstOrDefaultAsync();
            var members = _userManager.Users.Where(u => team.MemberUserIds.Contains(u.Id)).ToList();
            team.GetCapabilities(members);
            team.GetPositions(members);
            return team;
        }

        public virtual async Task<List<Team>> GetAllTeamsAsync()
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

        public virtual async Task UpdateTeam(Team team)
        {
            var filter = Builders<Team>.Filter.Eq(t => t.Id, team.Id);
            await _teams.ReplaceOneAsync(filter, team);
        }

        public virtual async Task DeleteTeam(string teamId)
        {
            await _teams.DeleteOneAsync(t => t.Id == teamId);
        }

        public virtual async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return _userManager.Users.ToList();
        }

        public virtual async Task<bool> CreateTeamAsync(Team team)
        {
            try
            {
                await _teams.InsertOneAsync(team);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual async Task<bool> DeleteTeamAsync(string id)
        {
            try
            {
                var result = await _teams.DeleteOneAsync(t => t.Id == id);
                return result.IsAcknowledged;
            }
            catch
            {
                return false;
            }
        }

        public virtual async Task<Team> GetTeamByIdAsync(string id)
        {
            try
            {
                return await _teams.Find(t => t.Id == id).FirstOrDefaultAsync();
            }
            catch
            {
                return null;
            }
        }

        public virtual async Task<bool> UpdateTeamAsync(string id, Team team)
        {
            try
            {
                var result = await _teams.ReplaceOneAsync(t => t.Id == id, team);
                return result.IsAcknowledged;
            }
            catch
            {
                return false;
            }
        }


    }

}
