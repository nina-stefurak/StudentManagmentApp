using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using StudentProjectManager.Models.auth;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudentProjectManager.Repository.Auth
{
    public class CustomRoleStore : IRoleStore<ApplicationRole>
    {
        private readonly IMongoCollection<ApplicationRole> _rolesCollection;

        public CustomRoleStore(IMongoDatabase database)
        {
            _rolesCollection = database.GetCollection<ApplicationRole>("Roles");
        }

        public async Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            await _rolesCollection.InsertOneAsync(role, cancellationToken: cancellationToken);
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            var result = await _rolesCollection.ReplaceOneAsync(r => r.Id == role.Id, role, cancellationToken: cancellationToken);
            return result.IsAcknowledged ? IdentityResult.Success : IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            var result = await _rolesCollection.DeleteOneAsync(r => r.Id == role.Id, cancellationToken);
            return result.IsAcknowledged ? IdentityResult.Success : IdentityResult.Failed();
        }

        public async Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return await _rolesCollection.Find(r => r.Id == roleId).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return await _rolesCollection.Find(r => r.NormalizedName == normalizedRoleName).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            // This method is straightforward - just return the role's ID
            return Task.FromResult(role.Id);
        }

        public Task<string> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            // This method is straightforward - just return the role's name
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken)
        {
            // This method is straightforward - just set the role's name
            role.Name = roleName;
            return Task.CompletedTask;
        }

        public Task<string> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            // This method is straightforward - just return the role's normalized name
            return Task.FromResult(role.NormalizedName);
        }

        public Task SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken)
        {
            // This method is straightforward - just set the role's normalized name
            role.NormalizedName = normalizedName;
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // No need to dispose of anything here, as MongoDB driver handles connection pooling
        }
    }
}
