using CommercialWebSite.ShareDTO.Auth;
using CommercialWebSite.Client.RefitClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CommercialWebSite.ShareDTO;
using System.Web;
using Refit;
using CommercialWebSite.Client.Helper;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace CommercialWebSite.Client.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthenticateClient _authClient;
        private readonly IOrderClient _orderClient;
        private readonly string baseUrl = "https://localhost:7281";

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
            _authClient = RestService.For<IAuthenticateClient>(baseUrl);
            _orderClient = RestService.For<IOrderClient>(baseUrl);
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
                    JwtManager jwtManager = new JwtManager(session);
                    string authHeader = jwtManager.GetAuthHeader();

                    var userId = jwtManager.GetUserId();

                    List<OrderModel> orders = await _orderClient
                        .GetByBuyerIdAsync(userId, authHeader);
                    session.SetString("Orders", JsonConvert.SerializeObject(orders));

                    // Http Login
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Sid, userId));
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrinciple);
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

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            var session = Request.HttpContext.Session;
            await _authClient.LogoutAsync(
                new JwtManager(session).GetAuthHeader());
            session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
