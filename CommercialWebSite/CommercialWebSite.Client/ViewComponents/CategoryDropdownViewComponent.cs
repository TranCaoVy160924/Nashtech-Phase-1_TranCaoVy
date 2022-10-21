using CommercialWebSite.Client.RefitClient;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace CommercialWebSite.Client.Views.Shared.Components.FeatureCategory
{
    public class CategoryDropdownViewComponent: ViewComponent
    {
        private readonly ILogger<CategoryDropdownViewComponent> _logger;
        private static readonly string baseUrl = "https://localhost:7281";

        public CategoryDropdownViewComponent(ILogger<CategoryDropdownViewComponent> logger)
        {
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ICategoryClient categoryClient = RestService.For<ICategoryClient>(baseUrl);
            var model = await categoryClient.GetAllCategoryAsync();

            return await Task.FromResult((IViewComponentResult)View("CategoryDropdown", model));
        }
    }
}
