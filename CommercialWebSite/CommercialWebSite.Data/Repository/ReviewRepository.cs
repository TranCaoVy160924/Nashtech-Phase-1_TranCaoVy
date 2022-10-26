using AutoMapper;
using CommercialWebSite.Data.AutoMapperHelper;
using CommercialWebSite.Data.DataModel;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.Data.Repository
{
    public class ReviewRepository: IReviewRepository
    {
        private ApplicationDbContext _appDbContext;
        private MapperHelper<ProductReview, ProductReviewModel> _reviewMapper;
        private IMapperProvider _mapperProvider;
        private UserManager<IdentityUser> _userManager;

        public ReviewRepository(
            ApplicationDbContext appDbContext,
            IMapperProvider mapperProvider,
            UserManager<IdentityUser> userManager)
        {
            _mapperProvider = mapperProvider;
            _appDbContext = appDbContext;
            _reviewMapper = _mapperProvider.CreateReviewMapper();
        }

        public async Task<Boolean> PostReviewAsync(ProductReviewModel reviewModel)
        {
            bool isSucceeded = true;

            Product reviewedProduct =
                await _appDbContext.Products
                .Where(p => p.ProductId == reviewModel.ProductId)
                .SingleOrDefaultAsync();

            UserAccount reviewer =
                await _appDbContext.UserAccounts
                .Where(u => u.UserName.Equals(reviewModel.UserName))
                .SingleOrDefaultAsync();

            ProductReview review = new ProductReview
            {
                ProductRating = reviewModel.ProductRating,
                Review = reviewModel.Review,
                Product = reviewedProduct,
                UserAccount = new UserAccount()
            };

            try
            {
                _appDbContext.Add(review);
                _appDbContext.SaveChanges();
            }
            catch (Exception)
            {
                isSucceeded = false;
            }

            return isSucceeded;
        }
    }
}
