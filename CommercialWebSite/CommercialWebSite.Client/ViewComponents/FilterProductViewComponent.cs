using CommercialWebSite.Client.RefitClient;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace CommercialWebSite.Client.ViewComponents
{
    public class FilterProductViewComponent: ViewComponent
    {
        private readonly ILogger<FilterProductViewComponent> _logger;
        private static readonly string baseUrl = "https://localhost:7281";
        private readonly ICategoryClient _categoryClient;

        public FilterProductViewComponent(ILogger<FilterProductViewComponent> logger)
        {   
            _logger = logger;
            _categoryClient = RestService.For<ICategoryClient>(baseUrl);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryClient.GetAllCategoryAsync();
            ViewData["categories"] = categories;

            return await Task.FromResult((IViewComponentResult)View("FilterProduct"));
        }
    }
}
