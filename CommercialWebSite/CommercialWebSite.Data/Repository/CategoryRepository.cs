using AutoMapper;
using CommercialWebSite.Data.AutoMapperHelper;
using CommercialWebSite.Data.DataModel;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.EntityFrameworkCore;
using CommercialWebSite.DataRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.Data.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _appDbContext;
        private MapperHelper<Category, CategoryModel> _categoryMapper;

        public CategoryRepository()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Category, CategoryModel>()
                .ForMember(
                    dest => dest.ProductCount,
                    act => act.MapFrom(src => src.Products.Count)
                ));
            _categoryMapper = new MapperHelper<Category, CategoryModel>(config);
            _appDbContext = new ApplicationDbContext();
        }

        // Constructor for testing
        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Category, CategoryModel>()
                .ForMember(
                    dest => dest.ProductCount,
                    act => act.MapFrom(src => src.Products.Count)
                ));
            _categoryMapper = new MapperHelper<Category, CategoryModel>(config);
            _appDbContext = applicationDbContext;
        }

        // Implement interface method
        public async Task<List<CategoryModel>> GetAllCategoryAsync()
        {
            var categories = await _appDbContext.Categories.ToListAsync();

            return _categoryMapper.MapCollection(categories).ToList();
        }

        public async Task<List<CategoryModel>> GetFeatureCategoryAsync()
        {
            var categories = await _appDbContext.Categories
                .Include(c => c.Products)
                .OrderByDescending(c => c.Products.Count())
                .Take(4).ToListAsync();

            return _categoryMapper.MapCollection(categories).ToList();
        }
    }
}
