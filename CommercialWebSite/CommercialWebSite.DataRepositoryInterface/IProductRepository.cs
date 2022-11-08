using CommercialWebSite.ShareDTO;
using CommercialWebSite.ShareDTO.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.DataRepositoryInterface
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllAsync();
        Task<int> GetPageCountAsync();
        Task<List<ProductModel>> GetProductByPageAsync(int page);
        Task<List<ProductModel>> GetFeatureProductAsync();
        Task<List<ProductModel>> GetProductByCategoryAsync(int categoryId);
        Task<ProductModel> GetProductByIdAsync(int id);
        Task<List<ProductModel>> GetProductByNameAsync(string prodName);
        Task<List<ProductModel>> FilterProductAsync(FilterProductModel filter);
        Task<ProductModel> UpdateProductAsync(ProductModel patchProduct);
        Task<ProductModel> AddProductAsync(ProductModel newProduct);
        Task DeleteProductAsync(int id);
        Task<bool> CheckBuyerAsync(string buyerId, int productId);
    }
}
