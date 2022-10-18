using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataModel;
using DataRepositoryInterface;
using ShareModelsDTO.Business;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class ProductRepository: IProductRepository
    {
        private ApplicationDbContext _appDbContext;
        private IMapper _mapper;

        public ProductRepository()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Product, ProductModel>()
                .ForMember(
                    dest => dest.CategoryId,
                    act => act.MapFrom(src => src.Category.CategoryId)
                ));
            _mapper = new Mapper(config);
        }


        // Implement Interface method
        public async Task<List<ProductModel>> GetAllProductAsync()
        {
            ApplicationDbContext _appDbContext = new ApplicationDbContext();
            List<Product> rawProducts = 
                await _appDbContext.Products
                .Include(p => p.Category)
                .ToListAsync();

            return ConvertProductCollection(rawProducts).ToList();
        }

        public async Task<List<ProductModel>> GetProductByCategoryAsync(int categoryId)
        {
            ApplicationDbContext _appDbContext = new ApplicationDbContext();
            List<Product> rawProducts =
                await _appDbContext.Products
                .Include(p => p.Category)
                .Where(p => p.Category.CategoryId == categoryId)
                .ToListAsync();

            return ConvertProductCollection(rawProducts).ToList();
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            ApplicationDbContext _appDbContext = new ApplicationDbContext();
            Product rawProduct = 
                await _appDbContext.Products
                .Include(p => p.Category)
                .Where(p => p.ProductId == id)
                .FirstAsync();

            return ConvertProduct(rawProduct);
        }

        // Helper method
        private IEnumerable<ProductModel> ConvertProductCollection(IEnumerable<Product> rawProducts)
        {
            List<ProductModel> products =
                rawProducts.Select(p => _mapper.Map<ProductModel>(p)).ToList();
            return products;
        }

        private ProductModel ConvertProduct(Product rawProduct)
        {
            ProductModel product = _mapper.Map<ProductModel>(rawProduct);
            return product;
        }
    }
}
