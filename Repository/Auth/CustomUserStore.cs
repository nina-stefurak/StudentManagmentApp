using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using StudentProjectManager.Models.auth;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentProjectManager.Repository.Auth
{


    public class CustomUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>, IUserRoleStore<ApplicationUser>, IQueryableUserStore<ApplicationUser>
    {
        private readonly IMongoCollection<ApplicationUser> _usersCollection;

        public CustomUserStore(IMongoDatabase database)
        {
            _usersCollection = database.GetCollection<ApplicationUser>("Users");
        }

        public IQueryable<ApplicationUser> Users => _usersCollection.AsQueryable();

        public async Task AddToRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filter = Builders<ApplicationUser>.Filter.Eq(u => u.Id, user.Id);
            var update = Builders<ApplicationUser>.Update.AddToSet(u => u.Roles, roleName);

            await _usersCollection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        }

        public async Task RemoveFromRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filter = Builders<ApplicationUser>.Filter.Eq(u => u.Id, user.Id);
            var update = Builders<ApplicationUser>.Update.Pull(u => u.Roles, roleName);

            await _usersCollection.UpdateOneAsync(filter, update, cancellationToken: cancellationToken);
        }

        public async Task<IList<string>> GetRolesAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filter = Builders<ApplicationUser>.Filter.Eq(u => u.Id, user.Id);
            var userFromDb = await _usersCollection.Find(filter).FirstOrDefaultAsync(cancellationToken);

            return userFromDb?.Roles ?? new List<string>();
        }

        public async Task<bool> IsInRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentNullException(nameof(roleName));
            }

            // Ensure that the Roles property is not null before attempting to use it
            if (user.Roles == null)
            {
                return false;
            }

            var filter = Builders<ApplicationUser>.Filter.Eq(u => u.Id, user.Id);
            var userFromDb = await _usersCollection.Find(filter).FirstOrDefaultAsync(cancellationToken);

            return userFromDb?.Roles.Contains(roleName) ?? false;
        }

        public async Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var filter = Builders<ApplicationUser>.Filter.AnyEq(u => u.Roles, roleName);
            var usersInRole = await _usersCollection.Find(filter).ToListAsync(cancellationToken);

            return usersInRole;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            await _usersCollection.InsertOneAsync(user, cancellationToken: cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var result = await _usersCollection.ReplaceOneAsync(u => u.Id == user.Id, user, cancellationToken: cancellationToken);
            return result.IsAcknowledged ? IdentityResult.Success : IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var result = await _usersCollection.DeleteOneAsync(u => u.Id == user.Id, cancellationToken);
            return result.IsAcknowledged ? IdentityResult.Success : IdentityResult.Failed();
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await _usersCollection.Find(u => u.Id == userId).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await _usersCollection.Find(u => u.NormalizedUserName == normalizedUserName).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            // This method is straightforward - just return the user's ID
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            // This method is straightforward - just return the user's user name
            return Task.FromResult(user.UserName);
        }

        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            // This method is straightforward - just set the user's user name
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            // This method is straightforward - just return the user's normalized user name
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            // This method is straightforward - just set the user's normalized user name
            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            // This method is straightforward - just return the user's password hash
            return Task.FromResult(user.PasswordHash);
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            // This method is straightforward - just set the user's password hash
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // No need to dispose of anything here, as MongoDB driver handles connection pooling
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
