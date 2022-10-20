using CommercialWebSite.ShareDTO.Auth;
using CommercialWebSite.Client.RefitClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CommercialWebSite.ShareDTO;

namespace CommercialWebSite.Client.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthenticateClient _authClient;
        private readonly string baseUrl = "https://localhost:7281";

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
            _authClient = RestService.For<IAuthenticateClient>(baseUrl);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var session = Request.HttpContext.Session;

                    // Get and decrypt jwt token
                    JwtResponseToken responseToken = JsonConvert.DeserializeObject<JwtResponseToken>(await _authClient.Login(model));
                    var handler = new JwtSecurityTokenHandler();
                    JwtSecurityToken secureToken = handler.ReadJwtToken(responseToken.Token);

                    string userId = secureToken.Claims.Where(c => c.Type == ClaimTypes.Sid).SingleOrDefault().Value.ToString();

                    _logger.LogInformation("Raw token: " + responseToken.Token.ToString());
                    _logger.LogInformation("Secure token: " + secureToken);
                    _logger.LogInformation("User Id: " + userId);

                    // Add token to session
                    session.SetString("JwtAuthToken", responseToken.Token);
                }
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex.Message);
                TempData["LoginErrorMessage"] = "Password or Username is invalid";
            }

            ViewModel viewModel = new ViewModel
            {
                LoginRequestModel = model
            };

            return RedirectToAction("Index", "Home", viewModel);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _authClient.Register(model);
                }
            }
            catch (ApiException ex)
            {
                if (ex.Content.Contains("User already exists!")) 
                { 
                    TempData["ErrorMessage"] = "User already exists!";
                }
                if (ex.Content.Contains("User creation failed"))
                {
                    TempData["ErrorMessage"] = "Password must contain letter, capital letter, number and special character";
                }
                _logger.LogError(ex.Content);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]

        public IActionResult Logout()
        {
            var session = Request.HttpContext.Session;
            session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
