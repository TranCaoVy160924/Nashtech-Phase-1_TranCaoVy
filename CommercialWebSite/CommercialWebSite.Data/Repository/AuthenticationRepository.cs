using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CommercialWebSite.Data.DataModel;
using CommercialWebSite.DataRepositoryInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace CommercialWebSite.Data.Repository
{
    public class AuthenticationRepository: IAuthenticationRepository<UserAccount>
    {
        private UserManager<UserAccount> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        // Implement interface function
        public AuthenticationRepository(
            UserManager<UserAccount> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<Claim>>? AuthenticateLoginAsync(
            string username, string password)
        {
            var user = await FindUserByNameAsync(username);
            if (await IsValidLoginAsync(user, password))
            {
                var authClaims = await GetUserClaimAsync(user);

                return authClaims;
            }
            return null;
        }

        public async Task<Boolean> IsExistedAsync(string username)
        {
            var user = await _userManager
                .FindByNameAsync(username);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public async Task<UserAccount>? RegisterNewUserAsync(
            string username, string email, string password)
        {
            UserAccount user = new()
            {
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = username,
                FirstName = "asdsa",
                LastName = "dsfdsfsd",
                Birthday = DateTime.Today,
                UserAddress = "dsfdsfa"
            };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return user;
            }

            return null;
        }

        public async Task InitialUserRoleAsync(string role)
        {
            System.Console.WriteLine(role);
            if (!await _roleManager.RoleExistsAsync(role))
                await _roleManager.CreateAsync(new IdentityRole(role));
        }

        public async Task AddRoleToUserAsync(UserAccount user, string role)
        {
            if (await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.AddToRoleAsync(user, role);
            }
        }

        // Helper function
        private async Task<UserAccount>? FindUserByNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user;
        }

        private async Task<Boolean> IsValidLoginAsync(
            UserAccount user, string password)
        {
            Boolean isValid = user != null 
                && await _userManager.CheckPasswordAsync(user, password);
            return isValid;
        }

        private async Task<List<Claim>> GetUserClaimAsync(UserAccount user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Sid, user.Id),
                    new Claim(
                        JwtRegisteredClaimNames.Jti, 
                        Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return authClaims;
        }
    }
}
