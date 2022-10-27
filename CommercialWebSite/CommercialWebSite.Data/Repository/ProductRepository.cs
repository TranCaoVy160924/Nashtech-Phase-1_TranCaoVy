using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommercialWebSite.Data.DataModel;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CommercialWebSite.Data.AutoMapperHelper;
using CommercialWebSite.ShareDTO;

namespace CommercialWebSite.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _appDbContext;
        private MapperHelper<Product, ProductModel> _productMapper;
        private MapperHelper<ProductReview, ProductReviewModel> _reviewMapper;
        private IMapperProvider _mapperProvider;

        public ProductRepository(
            ApplicationDbContext appDbContext, 
            IMapperProvider mapperProvider)
        {
            _mapperProvider = mapperProvider;
            _reviewMapper = _mapperProvider.CreateReviewMapper();
            _productMapper = _mapperProvider.CreateProductMapper();
            _appDbContext = appDbContext;
        }

        // Implement Interface method
        public async Task<List<ProductModel>> GetAllProductAsync()
        {
            //_appDbContext = new ApplicationDbContext();
            List<Product> rawProducts =
                await _appDbContext.Products
                .Include(p => p.Category)
                .ToListAsync();

            return _productMapper.MapCollection(rawProducts).ToList();
        }

        public async Task<List<ProductModel>> GetFeatureProductAsync()
        {
            //_appDbContext = new ApplicationDbContext();
            List<Product> rawProducts =
                await _appDbContext.Products
                .Include(p => p.Category)
                .Take(8)
                .ToListAsync();

            return _productMapper.MapCollection(rawProducts).ToList();
        }

        public async Task<List<ProductModel>> GetProductByCategoryAsync(int categoryId)
        {
            //_appDbContext = new ApplicationDbContext();
            List<Product> rawProducts =
                await _appDbContext.Products
                .Include(p => p.Category)
                .Where(p => p.Category.CategoryId == categoryId)
                .ToListAsync();

            return _productMapper.MapCollection(rawProducts).ToList();
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            Product rawProduct =
                await _appDbContext.Products
                .Include(p => p.Category)
                .Include(p => p.ProductReviews)
                .ThenInclude(r => r.UserAccount)
                .Where(p => p.ProductId == id)
                .FirstOrDefaultAsync();

            return _productMapper.MapSingleObject(rawProduct);
        }

        public async Task<List<ProductModel>> GetProductByNameAsync(string prodName)
        {
            List<Product> rawProducts =
                await _appDbContext.Products
                .Include(p => p.Category)
                .Where(p => p.ProductName.Contains(prodName))
                .ToListAsync();

            return _productMapper.MapCollection(rawProducts).ToList();
        }

        public async Task<List<ProductModel>> FilterProductAsync(FilterProductModel filter)
        {
            List<Product> filteredRawProducts = new List<Product>();
            foreach (CategorySelectionModel categorySelection in filter.CategoriesSelection)
            {
                List<Product> rawProducts =
                    await _appDbContext.Products
                    .Include(p => p.Category)
                    .Where(p =>
                        p.Category.CategoryId == categorySelection.CategoryId &&
                        p.ProductName.Contains(filter.ProductName) &&
                        p.Price >= filter.MinPrice &&
                        p.Price <= filter.MaxPrice)
                    .ToListAsync();
                filteredRawProducts = filteredRawProducts.Concat(rawProducts).ToList();
            }

            return _productMapper.MapCollection(filteredRawProducts).ToList();
        }
    }
}
