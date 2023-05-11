using Microsoft.AspNetCore.Identity;
using Security.Models;
using Security.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Security.Stores
{
    public class RoleStore<TRole, TKey, TUserRole, TRoleClaim>
        : IRoleStore<TRole>
        where TRole : DynamicIdentityRole<TKey, TUserRole, TRoleClaim>
        where TKey : IEquatable<TKey>
        where TUserRole : DynamicIdentityUserRole<TKey>
        where TRoleClaim : DynamicIdentityRoleClaim<TKey>
    {
        private readonly IIdentityRoleService _roleService;
        public RoleStore(IIdentityRoleService roleService

                               )
        {
            _roleService = roleService;
        }

        public async Task<IdentityResult> CreateAsync(TRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            try
            {
                var result = await _roleService.RoleService.InsertAsync<int>(role as DynamicIdentityRole);
                return result > 0 ? IdentityResult.Success : IdentityResult.Failed();
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed();
            }
        }

        public async Task<IdentityResult> DeleteAsync(TRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            try
            {
                var result = await _roleService.RoleService.DeleteAsync(role.Id);
                return result > 0 ? IdentityResult.Success : IdentityResult.Failed();
            }
            catch (Exception ex)
            {

                return IdentityResult.Failed();
            }
        }

        public void Dispose()
        {

        }

        public async Task<TRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrEmpty(roleId))
                throw new ArgumentNullException(nameof(roleId));

            try
            {
                var result = await _roleService.RoleService.GetAsync(roleId);
                return result as TRole;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (string.IsNullOrEmpty(normalizedRoleName))
                throw new ArgumentNullException(nameof(normalizedRoleName));

            try
            {
                var result = await _roleService.RoleService.GetAsync("Where NormalizedName=@Name", new { Name = normalizedRoleName });
                return result as TRole;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public Task<string> GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            return Task.FromResult(role.Name);
        }

        public Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            if (role.Id.Equals(default(TKey)))
                return null;

            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(TRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(TRole role, string normalizedName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            return Task.FromResult(0);
        }

        public Task SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            role.Name = roleName;

            return Task.FromResult(0);
        }

        public async Task<IdentityResult> UpdateAsync(TRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (role == null)
                throw new ArgumentNullException(nameof(role));

            try
            {
                var result = await _roleService.RoleService.UpdateAsync(role);
                return result ? IdentityResult.Success : IdentityResult.Failed();
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed();
            }
        }
    }

}
