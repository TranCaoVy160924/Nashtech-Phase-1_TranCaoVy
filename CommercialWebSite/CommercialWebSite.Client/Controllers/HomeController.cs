using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CommercialWebSite.Client.RefitClient;
using Refit;
using CommercialWebSite.ShareDTO;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;

namespace CommercialWebSite.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly string baseUrl = "https://localhost:7281";
        private readonly IProductClient _productClient;
        private readonly IReviewClient _reviewClient;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _productClient = RestService.For<IProductClient>(baseUrl);
            _reviewClient = RestService.For<IReviewClient>(baseUrl);
        }

        public async Task<IActionResult> Index()
        {
            var session = Request.HttpContext.Session;
            //string jwtToken = session.GetString("JwtAuthToken");
            //if (jwtToken != null)
            //{
            //    _logger.LogInformation("Auth token: " + jwtToken);
            //    IWeatherForecastClient client = RestService.For<IWeatherForecastClient>(baseUrl, new RefitSettings()
            //    {
            //        AuthorizationHeaderValueGetter = () =>
            //            Task.FromResult(jwtToken)
            //    });

            //    List<WeatherForecastModel> weather = await client.GetWeatherForecastAsync();

            //    _logger.LogInformation("Weather: " + weather);
            //}

            var products = await _productClient.GetFeatureProductAsync();

            ViewModel viewModel = new ViewModel();
            viewModel.ProductModels = products;

            return View(viewModel);
        }

        public async Task<IActionResult> Shop()
        {
            List<ProductModel> products;
            int page = 1;
            int pageCount = await _productClient.GetPageCount();
            try
            {
                products = JsonConvert
                    .DeserializeObject<List<ProductModel>>(
                    TempData["ProductModels"].ToString());

                page = JsonConvert
                    .DeserializeObject<int>(
                    TempData["Page"].ToString());
            }
            catch (NullReferenceException)
            {
                products = await _productClient.GetProductByPageAsync(1);
            }

            ViewModel respsonseViewModel = new ViewModel();
            respsonseViewModel.ProductModels = products;
            respsonseViewModel.Page = page;
            TempData["PageCount"] = pageCount;
            return View("Shop", respsonseViewModel);
        }

        public async Task<IActionResult> ShopByPage(int page)
        {
            List<ProductModel> products = await _productClient.GetProductByPageAsync(page);

            TempData["ProductModels"] = JsonConvert.SerializeObject(products);
            TempData["Page"] = JsonConvert.SerializeObject(page);
            return RedirectToAction("Shop");
        }

        public async Task<IActionResult> ProductDetail(int id)
        {
            var product = await _productClient.GetProductByIdAsync(id);

            ViewModel viewModel = new ViewModel();
            viewModel.ProductDetail = product;

            return View("ProductDetail", viewModel);
        }

        public async Task<IActionResult> SearchProductByCategory(string catId)
        {
            int categoryId = int.Parse(catId);
            List<ProductModel> products;
            if (categoryId == 0)
            {
                products = await _productClient.GetProductByPageAsync(1);
            }
            else
            {
                products = await _productClient.GetProductByCategoryAsync(categoryId);
            }

            TempData["ProductModels"] = JsonConvert.SerializeObject(products);
            TempData["Page"] = JsonConvert.SerializeObject(0);

            return RedirectToAction("Shop");
        }

        public async Task<IActionResult> SearchProductByName(string prodName)
        {
            List<ProductModel> products = new List<ProductModel>();
            if (prodName != null)
            {
                products =
                    await _productClient.GetProductByNameAsync(prodName);
            }

            TempData["ProductModels"] = JsonConvert.SerializeObject(products);
            TempData["Page"] = JsonConvert.SerializeObject(0);

            return RedirectToAction("Shop");
        }

        [HttpPost]
        public async Task<IActionResult> FilterProduct(ViewModel model)
        {
            FilterProductModel filter = model.FilterProductModel;
            List<ProductModel> products = new List<ProductModel>();
            try
            {
                // Check category
                // If none chosen, get all category
                if (filter.CategoriesSelection.Any(c => c.IsSelected))
                {
                    // If any chosen, get the one chosen
                    filter.CategoriesSelection =
                        filter.CategoriesSelection.Where(c => c.IsSelected).ToList();
                }

                // Check Product Name
                _logger.LogInformation("name: " + filter.ProductName);
                if (filter.ProductName == null)
                {
                    filter.ProductName = "";
                }
                filter.ProductName = filter.ProductName.Trim();

                // Check Price
                _logger.LogInformation("min: " + filter.MinPrice + ", max: " + filter.MaxPrice);
                if (filter.MaxPrice == null || filter.MaxPrice == 0)
                {
                    filter.MaxPrice = 100000;
                }
                if (filter.MinPrice == null)
                {
                    filter.MinPrice = 0;
                }

                // Call API
                products =
                    await _productClient.FilterProductAsync(filter);
            }
            catch (ApiException ex)
            {
                _logger.LogInformation(ex.Content);
            }

            TempData["ProductModels"] = JsonConvert.SerializeObject(products);
            TempData["Page"] = JsonConvert.SerializeObject(0);

            return RedirectToAction("Shop");
        }

        [HttpPost]
        public async Task<IActionResult> PostProductReview(ViewModel model)
        {
            ProductReviewModel reviewModel = model.ProductReviewInputModel;

            // Validate
            if (reviewModel.Review == null)
            {
                reviewModel.Review = "";
            }

            try
            {
                await _reviewClient.PostReviewAsync(reviewModel);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }

            return RedirectToAction("ProductDetail", new { id = reviewModel.ProductId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}