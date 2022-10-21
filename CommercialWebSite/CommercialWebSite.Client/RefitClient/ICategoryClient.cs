using CommercialWebSite.ShareDTO.Business;
using Refit;

namespace CommercialWebSite.Client.RefitClient
{
    public interface ICategoryClient
    {
        [Get("/Category")]
        Task<List<CategoryModel>> GetAllProductAsync();

        [Get("/Category/Feature")]
        Task<List<CategoryModel>> GetFeatureProductAsync();
    }
}
