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
        private IMapperProvider _mapperProvider;

        public CategoryRepository(
            ApplicationDbContext appDbContext,
            IMapperProvider mapperProvider)
        {
            _mapperProvider = mapperProvider;
            _categoryMapper =_mapperProvider.CreateCategoryMapper();
            _appDbContext = new ApplicationDbContext();
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
