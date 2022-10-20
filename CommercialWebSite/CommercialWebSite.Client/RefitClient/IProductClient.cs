using Refit;
using CommercialWebSite.ShareDTO.Business;

namespace CommercialWebSite.Client.RefitClient
{
    public interface IProductClient
    {
        [Get("/Product")]
        Task<List<ProductModel>> GetAllProductAsync();

        [Get("/Product/Feature")]
        Task<List<ProductModel>> GetFeatureProductAsync();

        [Get("/Product/{id}")]
        Task<ProductModel> GetProductByIdAsync(int id);
    }
}
