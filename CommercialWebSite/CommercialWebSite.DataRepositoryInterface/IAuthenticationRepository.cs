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
    public interface IAuthenticationRepository<T>
    { 
        Task<List<Claim>>? AuthenticateLoginAsync(string username, string password);

        Task<Boolean> IsExistedAsync(string username);

        Task<T> RegisterNewUserAsync(
            string username, string email, string password);

        Task InitialUserRoleAsync(string role);

        Task AddRoleToUserAsync(T user, string role);
    }
}
