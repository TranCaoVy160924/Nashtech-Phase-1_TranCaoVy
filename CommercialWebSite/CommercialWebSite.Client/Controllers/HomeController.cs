using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CommercialWebSite.Client.RefitClient;
using Refit;
using CommercialWebSite.ShareDTO;
using Newtonsoft.Json;
using CommercialWebSite.Client.Helper;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;

namespace CommercialWebSite.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private static readonly string baseUrl = "https://localhost:7281";
        private IProductClient _productClient;
        private IReviewClient _reviewClient;

        public HomeController(
            ILogger<HomeController> logger, 
            IProductClient productClient,
            IReviewClient reviewClient)
        {
            _logger = logger;

            _productClient = productClient;
            _reviewClient = reviewClient;
        }

        public async Task<IActionResult> Index()
        {
            //CreateRefitClient();

            var session = Request.HttpContext.Session;

            var products = await _productClient.GetFeatureProductAsync();

            ViewModel viewModel = new ViewModel();
            viewModel.ProductModels = products;

            return View(viewModel);
        }

        public async Task<IActionResult> Shop()
        {
            //CreateRefitClient();

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
            //CreateRefitClient();

            List<ProductModel> products = await _productClient.GetProductByPageAsync(page);

            TempData["ProductModels"] = JsonConvert.SerializeObject(products);
            TempData["Page"] = JsonConvert.SerializeObject(page);
            return RedirectToAction("Shop");
        }

        public async Task<IActionResult> ProductDetail(int id)
        {
            //CreateRefitClient();

            var session = Request.HttpContext.Session;
            JwtManager jwtManager = new JwtManager(session);
            string authHeader = jwtManager.GetAuthHeader();
            bool isBuyer = false;

            if (jwtManager.IsAuthenticated)
            {
                string buyerId = jwtManager.GetUserId();
                isBuyer = await _productClient
                    .CheckBuyerAsync(buyerId, id, authHeader);
            }
            var product = await _productClient.GetProductByIdAsync(id);

            TempData["IsBuyer"] = isBuyer;
            ViewModel viewModel = new ViewModel();
            viewModel.ProductDetail = product;

            return View("ProductDetail", viewModel);
        }

        public async Task<IActionResult> SearchProductByCategory(string catId)
        {
            //CreateRefitClient();

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
            //CreateRefitClient();

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
            //CreateRefitClient();

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
        [Authorize]
        public async Task<IActionResult> PostProductReview(ViewModel model)
        {
            var session = Request.HttpContext.Session;
            JwtManager jwtManager = new JwtManager(session);
            string authHeader = jwtManager.GetAuthHeader();

            ProductReviewModel reviewModel = model.ProductReviewInputModel;
            bool isBuyer = await _productClient
                .CheckBuyerAsync(reviewModel.UserAccountId, 
                    reviewModel.ProductId, authHeader);
            if (isBuyer)
            {
                // Validate
                if (reviewModel.Review == null)
                {
                    reviewModel.Review = "";
                }

                try
                {
                    await _reviewClient.PostReviewAsync(reviewModel, authHeader);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                }
            }
            else
            {
                _logger.LogInformation("User havent bought this product yet!");
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