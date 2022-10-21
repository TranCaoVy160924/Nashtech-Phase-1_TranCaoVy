using CommercialWebSite.ShareDTO.Business;
using Refit;

namespace CommercialWebSite.Client.RefitClient
{
    public interface ICategoryClient
    {
        [Get("/Category")]
        Task<List<CategoryModel>> GetAllCategoryAsync();

        [Get("/Category/Feature")]
        Task<List<CategoryModel>> GetFeatureCategoryAsync();
    }
}
