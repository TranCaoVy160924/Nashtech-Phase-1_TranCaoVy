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
        }


        // Implement interface method
        public async Task<List<CategoryModel>> GetAllCategoryAsync()
        {
            _appDbContext = new ApplicationDbContext();
            var categories = await _appDbContext.Categories.ToListAsync();

            return _categoryMapper.MapCollection(categories);
        }

        public async Task<List<CategoryModel>> GetFeatureCategoryAsync()
        {
            _appDbContext = new ApplicationDbContext();
            var categories = await _appDbContext.Categories
                .Include(c => c.Products)
                .OrderByDescending(c => c.Products.Count())
                .Take(4).ToListAsync();

            return _categoryMapper.MapCollection(categories);
        }
    }
}
