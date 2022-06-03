using DAL.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        public Task<ApplicationUser> FindUserByName(string username);

        public Task<bool> IsCorrectPassword(ApplicationUser user, string password);

        public Task<IList<string>> GetUserRoles(ApplicationUser user);

        public object GetTokenAndExpiration(IList<string> userRoles, string username);

        public Task<IdentityResult> CreateUser(ApplicationUser user, string password);

        public Task<bool> DoRoleExist(string roleName);

        public Task<IdentityResult> CreateRole(string roleName);

        public Task<IdentityResult> AddUserToRole(ApplicationUser user, string roleName);

        public Task<IdentityResult> RemoveUserFromRole(ApplicationUser user, string roleName);
    }
}
