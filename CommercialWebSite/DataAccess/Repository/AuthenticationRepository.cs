using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthHelper.Auth;
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

        public async Task<List<Claim>>? AuthenticateLogin(LoginModel model)
        {
            var user = await FindUserByNameAsync(model.Username);
            if (await IsValidLoginAsync(user, model.Password))
            {
                var authClaims = await GetUserClaimAsync(user);

                return authClaims;
            }
            return null;
        }

        // Helper function
        private async Task<IdentityUser>? FindUserByNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user;
        }

        private async Task<Boolean> IsValidLoginAsync(IdentityUser user, string password)
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
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return authClaims;
        }
    }
}
