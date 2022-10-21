using CommercialWebSite.Client.RefitClient;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace CommercialWebSite.Client.Views.Shared.ViewComponents
{
    public class FeatureCategoryViewComponent: ViewComponent
    {
        private readonly ILogger<FeatureCategoryViewComponent> _logger;
        private static readonly string baseUrl = "https://localhost:7281";

        public FeatureCategoryViewComponent(ILogger<FeatureCategoryViewComponent> logger)
        {
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ICategoryClient categoryClient = RestService.For<ICategoryClient>(baseUrl);
            var model = await categoryClient.GetFeatureCategoryAsync();

            return await Task.FromResult((IViewComponentResult)View("FeatureCategory", model));
        }
    }
}

