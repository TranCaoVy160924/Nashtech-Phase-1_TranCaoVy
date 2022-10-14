using AuthHelper.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataRepositoryInterface
{
    public interface IAuthenticationRepository
    {
        void SetManager(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager);

        void SetConfig(IConfiguration configuration);

        Task<List<Claim>>? AuthenticateLogin(LoginModel model);
    }
}
