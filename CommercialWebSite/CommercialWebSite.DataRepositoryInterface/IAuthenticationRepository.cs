using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.DataRepositoryInterface
{
    public interface IAuthenticationRepository
    {
        void SetManager(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager);

        void SetConfig(IConfiguration configuration);

        Task<List<Claim>>? AuthenticateLoginAsync(string username, string password);

        Task<Boolean> IsExistedAsync(string username);

        Task<IdentityUser> RegisterNewUserAsync(
            string username, string email, string password);

        Task InitialUserRoleAsync(string role);

        Task AddRoleToUserAsync(IdentityUser user, string role);
    }
}
