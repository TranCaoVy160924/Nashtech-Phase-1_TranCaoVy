//using CommercialWebSiteClient.Models;
using AuthModels.Auth;
using CommercialWebSiteClient.RefitClient;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace CommercialWebSiteClient.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly string baseUrl = "https://localhost:7281";

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequestModel model)
        {
            return View();
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
                    var authClient = RestService.For<IAuthenticateClient>(baseUrl);
                    await authClient.Register(model);
                    return View("Login");
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

            return View("Register");
        }
    }
}
