using AutoMapper;
using CommercialWebSite.Data.DataModel;
using CommercialWebSite.ShareDTO.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.Data.AutoMapperHelper
{
    public class MapperProvider : IMapperProvider
    {
        private MapperHelper<Product, ProductModel> _productMapper;
        private MapperHelper<ProductReview, ProductReviewModel> _reviewMapper;
        private MapperHelper<Category, CategoryModel> _categoryMapper;
        private MapperHelper<UserAccount, UserAccountModel> _userAccountMapper;

        public MapperHelper<Product, ProductModel> CreateProductMapper()
        {
            if (_reviewMapper == null)
            {
                CreateReviewMapper();
            }

            var productConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<Product, ProductModel>()
                .ForMember(
                    dest => dest.CategoryId,
                    act => act.MapFrom(src => src.Category.CategoryId)
                )
                .ForMember(
                    dest => dest.AgregateUserRate,
                    act => act.MapFrom(src => src.ProductReviews
                        .Select(r => r.ProductRating)
                        .DefaultIfEmpty()
                        .Average()))
                .ForMember(
                    dest => dest.Reviews,
                    act => act.MapFrom(src => 
                        _reviewMapper
                        .MapCollection(src.ProductReviews)
                        .ToList()))
                );
            _productMapper = new MapperHelper<Product, ProductModel>(productConfig);
            return _productMapper;
        }

        public MapperHelper<ProductReview, ProductReviewModel> CreateReviewMapper()
        {
            var reviewConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<ProductReview, ProductReviewModel>()
                .ForMember(
                    dest => dest.ProductId,
                    act => act.MapFrom(src => src.Product.ProductId)
                )
                .ForMember(
                    dest => dest.UserAccountId,
                    act => act.MapFrom(src => src.UserAccount.Id)
                ));
            _reviewMapper = new MapperHelper<ProductReview, ProductReviewModel>(reviewConfig);

            return _reviewMapper;
        }

        public MapperHelper<Category, CategoryModel> CreateCategoryMapper()
        {
            var categoryConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<Category, CategoryModel>()
                .ForMember(
                    dest => dest.ProductCount,
                    act => act.MapFrom(src => src.Products.Count)
                ));
            _categoryMapper = new MapperHelper<Category, CategoryModel>(categoryConfig);

            return _categoryMapper;
        }

        public MapperHelper<UserAccount, UserAccountModel> CreateUserAccountMapper()
        {
            if (_reviewMapper == null)
            {
                CreateReviewMapper();
            }

            var userAccountConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<UserAccount, UserAccountModel>()
                .ForMember(
                    dest => dest.Reviews,
                    act => act.MapFrom(src =>
                        _reviewMapper
                        .MapCollection(src.ProductReviews)
                        .ToList()))
                );
            _userAccountMapper = new MapperHelper<UserAccount, UserAccountModel>(userAccountConfig);
            return _userAccountMapper;
        }
    }
}
