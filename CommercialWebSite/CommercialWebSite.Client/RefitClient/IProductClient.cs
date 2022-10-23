using Refit;
using CommercialWebSite.ShareDTO.Business;
using CommercialWebSite.ShareDTO;

namespace CommercialWebSite.Client.RefitClient
{
    public interface IProductClient
    {
        [Get("/Product")]
        Task<List<ProductModel>> GetAllProductAsync();

        [Get("/Product/Feature")]
        Task<List<ProductModel>> GetFeatureProductAsync();

        [Get("/Product/{id}")]
        Task<ProductModel>? GetProductByIdAsync(int id);

        [Get("/Product/ByCat/{catId}")]
        Task<List<ProductModel>> GetProductByCategoryAsync(int catId);

        [Get("/Product/ByName/{prodName}")]
        Task<List<ProductModel>> GetProductByNameAsync(string prodName);

        [Get("/Product/Filter")]
        Task<List<ProductModel>> FilterProductAsync([Body] FilterProductModel filter);
    }
}
