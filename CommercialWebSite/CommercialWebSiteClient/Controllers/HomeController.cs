using ClientSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CommercialWebSiteClient.RefitClient;
using Refit;
using AuthModels.Auth;
using Newtonsoft.Json;
using CommercialWebSiteClient.Models;

namespace ClientSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string baseUrl = "https://localhost:7281";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var session = Request.HttpContext.Session;
            string jwtToken = session.GetString("JwtAuthToken");
            if (jwtToken != null)
            {
                _logger.LogInformation("Auth token: " + jwtToken);
                IWeatherForecastClient client = RestService.For<IWeatherForecastClient>(baseUrl, new RefitSettings()
                {
                    AuthorizationHeaderValueGetter = () =>
                        Task.FromResult(jwtToken)
                });

                List<WeatherForecastModel> weather = await client.GetWeatherForecastAsync();

                _logger.LogInformation("Weather: " + weather);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}