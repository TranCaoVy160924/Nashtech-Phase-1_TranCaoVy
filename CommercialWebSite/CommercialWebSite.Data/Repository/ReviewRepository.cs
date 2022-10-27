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
        private UserManager<UserAccount> _userManager;

        public ReviewRepository(
            ApplicationDbContext appDbContext,
            IMapperProvider mapperProvider,
            UserManager<UserAccount> userManager)
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
                .FirstOrDefaultAsync();

            UserAccount reviewer =
                await _appDbContext.UserAccounts
                .Where(u => u.UserName.Equals(reviewModel.UserName))
                .FirstOrDefaultAsync();

            ProductReview review = new ProductReview
            {
                ProductRating = reviewModel.ProductRating,
                Review = reviewModel.Review,
                PostedDate = DateTime.Today,
                Product = reviewedProduct,
                UserAccount = reviewer
            };
            
            try
            {
                if (reviewedProduct.ProductReviews == null)
                {
                    reviewedProduct.ProductReviews = new List<ProductReview>();
                }
                reviewedProduct.ProductReviews.Add(review);

                if (reviewer.ProductReviews == null)
                {
                    reviewer.ProductReviews = new List<ProductReview>();
                }
                reviewer.ProductReviews.Add(review);


                _appDbContext.ProductReviews.Add(review);
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
