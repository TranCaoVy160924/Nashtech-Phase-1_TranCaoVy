using Refit;
using CommercialWebSite.ShareDTO.Business;

namespace CommercialWebSite.Client.RefitClient
{
    public interface IProductClient
    {
        [Get("/Product")]
        Task<List<ProductModel>> GetAllProductAsync();
    }
}
