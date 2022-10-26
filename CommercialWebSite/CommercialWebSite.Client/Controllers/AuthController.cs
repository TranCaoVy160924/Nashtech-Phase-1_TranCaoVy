using CommercialWebSite.ShareDTO.Auth;
using CommercialWebSite.Client.RefitClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CommercialWebSite.ShareDTO;
using System.Web;

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
                    JwtResponseToken responseToken = 
                        JsonConvert.DeserializeObject<JwtResponseToken>(
                            await _authClient.Login(model)
                        );

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
                else
                {
                    TempData["RegisterErrorMessage"] = "All field is required in correct format";
                }
            }
            catch (ApiException ex)
            {
                if (ex.Content.Contains("User already exists!"))
                {
                    TempData["RegisterErrorMessage"] = "User already exists!";
                }
                if (ex.Content.Contains("User creation failed"))
                {
                    TempData["RegisterErrorMessage"] = "Password must contain letter, capital letter, number and special character";
                }
                _logger.LogError(ex.Content);
            }

            ViewModel viewModel = new ViewModel
            {
                RegisterRequestModel = model
            };

            return RedirectToAction("Index", "Home", viewModel);
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
