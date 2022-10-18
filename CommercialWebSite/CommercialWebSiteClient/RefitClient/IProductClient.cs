using Refit;
using ShareModelsDTO.Business;

namespace CommercialWebSiteClient.RefitClient
{
    public interface IProductClient
    {
        [Get("/Product")]
        Task<List<ProductModel>> GetAllProductAsync();
    }
}
