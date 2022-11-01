using CommercialWebSite.ShareDTO.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.Data.DataModel;

namespace CommercialWebSite.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationRepository<UserAccount> _authRepository;

        // Common response
        private static StatusResponse ExistedUserError = new StatusResponse
        {
            Status = "Error",
            Message = "User already exists!"
        };
        private static StatusResponse CreateUserFailed = new StatusResponse
        {
            Status = "Error",
            Message = "User creation failed! "
                + "Please check user details and try again."
        };
        private static StatusResponse CreateUserSucceeded = new StatusResponse
        {
            Status = "Success",
            Message = "User created successfully!"
        };

        public AuthenticateController(
            UserManager<UserAccount> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IAuthenticationRepository<UserAccount> authenticationRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _authRepository = authenticationRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestModel model)
        {
            try
            {
                var authClaim = await _authRepository
                .AuthenticateLoginAsync(model.Username, model.Password);
                
                if (authClaim == null)
                {
                    throw new NullReferenceException();
                }
                
                var token = GetToken(authClaim);

                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                });
            }
            catch(NullReferenceException)
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestModel model)
        {
            string username = model.Username;
            string email = model.Email;
            string password = model.Password;

            if (await _authRepository.IsExistedAsync(username))
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ExistedUserError);

            try
            {
                UserAccount user = await _authRepository
                .RegisterNewUserAsync(username, email, password);
            }
            catch (NullReferenceException)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    CreateUserFailed);
            }

            return Ok(CreateUserSucceeded);
        }

        [HttpPatch]
        [Route("register-admin/{id}")]
        public async Task<IActionResult> RegisterAdmin(string id)
        {
            try
            {
                UserAccount userAccount =  await _authRepository.MakeAdmin(id);

                if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                await _authRepository.AddRoleToUserAsync(userAccount, UserRoles.Admin);
                await _authRepository.AddRoleToUserAsync(userAccount, UserRoles.User);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ExistedUserError);
            }

            return Ok(CreateUserSucceeded);
        }


        // helper method
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
