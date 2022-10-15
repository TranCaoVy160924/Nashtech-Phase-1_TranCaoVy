using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataRepositoryInterface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Repository
{
    public class AuthenticationRepository: IAuthenticationRepository
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IConfiguration _configuration;

        // Implement interface function
        public void SetManager(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SetConfig(IConfiguration configuration)
        {
            _configuration = configuration;
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

        public async Task<IdentityUser>? RegisterNewUserAsync(
            string username, string email, string password)
        {
            IdentityUser user = new()
            {
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = username
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

        public async Task AddRoleToUserAsync(IdentityUser user, string role)
        {
            if (await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.AddToRoleAsync(user, role);
            }
        }

        // Helper function
        private async Task<IdentityUser>? FindUserByNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user;
        }

        private async Task<Boolean> IsValidLoginAsync(
            IdentityUser user, string password)
        {
            Boolean isValid = user != null 
                && await _userManager.CheckPasswordAsync(user, password);
            return isValid;
        }

        private async Task<List<Claim>> GetUserClaimAsync(IdentityUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
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
