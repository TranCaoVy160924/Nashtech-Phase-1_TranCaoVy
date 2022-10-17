using AuthModels.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataRepositoryInterface;
using Refit;

namespace CommercialWebSiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationRepository _authRepository;

        // Common response
        private static Response ExistedUserError = new Response
        {
            Status = "Error",
            Message = "User already exists!"
        };
        private static Response CreateUserFailed = new Response
        {
            Status = "Error",
            Message = "User creation failed! "
                + "Please check user details and try again."
        };
        private static Response CreateUserSucceeded = new Response
        {
            Status = "Success",
            Message = "User created successfully!"
        };

        public AuthenticateController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IAuthenticationRepository authenticationRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _authRepository = authenticationRepository;

            _authRepository.SetManager(_userManager, _roleManager);
            _authRepository.SetConfig(_configuration);
        }

        [HttpPost]
        [Post("/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var authClaim = await _authRepository
                .AuthenticateLoginAsync(model.Username, model.Password);

            if (authClaim != null)
            {
                var token = GetToken(authClaim);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            string username = model.Username;
            string email = model.Email;
            string password = model.Password;

            if (await _authRepository.IsExistedAsync(username))
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ExistedUserError);

            IdentityUser user = await _authRepository
                .RegisterNewUserAsync(username, email, password);
            if (user == null)
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    CreateUserFailed);

            return Ok(CreateUserSucceeded);
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterRequestModel model)
        {
            string username = model.Username;
            string email = model.Email;
            string password = model.Password;

            if (await _authRepository.IsExistedAsync(username))
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ExistedUserError);

            IdentityUser user = await _authRepository
                .RegisterNewUserAsync(username, email, password);
            if (user == null)
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    CreateUserFailed);

            await _authRepository.InitialUserRoleAsync(UserRoles.Admin);
            await _authRepository.InitialUserRoleAsync(UserRoles.User);

            await _authRepository.AddRoleToUserAsync(user, UserRoles.Admin);
            await _authRepository.AddRoleToUserAsync(user, UserRoles.User);

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
