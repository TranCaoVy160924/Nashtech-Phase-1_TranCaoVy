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

        public async Task<ProductModel> UpdateProductAsync(ProductModel patchProduct)
        {
            Product product =
                await _appDbContext.Products
                .Include(p => p.Category)
                .ThenInclude(c => c.Products)
                .Where(p => p.ProductId == patchProduct.ProductId)
                .FirstOrDefaultAsync();

            try
            {
                product.ProductName = patchProduct.ProductName;
                product.Description = patchProduct.Description;
                product.ProductPicture = TransformImage(patchProduct.ProductPicture);
                product.NumberInStorage = patchProduct.NumberInStorage;
                product.Price = patchProduct.Price;
                product.UpdateDate = DateTime.Today;
                product.Category =
                    await _appDbContext.Categories
                    .Where(c => c.CategoryId == patchProduct.CategoryId)
                    .FirstOrDefaultAsync();

                _appDbContext.SaveChanges();

                return _productMapper.MapSingleObject(product);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductModel> AddProductAsync(ProductModel newProduct)
        {
            Category category =
                await _appDbContext.Categories
                    .Include(c => c.Products)
                    .Where(c => c.CategoryId == newProduct.CategoryId)
                    .FirstOrDefaultAsync();

            Product product = new Product
            {
                ProductName = newProduct.ProductName,
                Description = newProduct.Description,
                ProductPicture = TransformImage(newProduct.ProductPicture),
                NumberInStorage = newProduct.NumberInStorage,
                Price = newProduct.Price,
                CreateDate = DateTime.Today,
                UpdateDate = DateTime.Today,
                Category = category,
                Orders = new List<Order>(),
                ProductReviews = new List<ProductReview>()
            };

            try
            {
                category.Products.Add(product);

                _appDbContext.Products.Add(product);
                _appDbContext.SaveChanges();

                return _productMapper.MapSingleObject(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Image transform helper
        private static string TransformImage(string image)
        {
            string front = "http://res.cloudinary.com/dddvmxs3h/image/upload/";
            int seperatePosition = front.Length;
            string end = image.Substring(seperatePosition);
            string final = front + "w_150,h_150/" + end;

            return final;
        }
    }
}
