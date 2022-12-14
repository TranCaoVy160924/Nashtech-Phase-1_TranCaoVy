using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CommercialWebSite.Data.AutoMapperHelper;
using CommercialWebSite.Data.DataModel;
using CommercialWebSite.DataRepositoryInterface;
using CommercialWebSite.ShareDTO.Business;
using Microsoft.EntityFrameworkCore;

namespace CommercialWebSite.Data.Repository
{
    public class UserAccountRepository: IUserAccountRepository
    {
        private ApplicationDbContext _appDbContext;
        private MapperHelper<UserAccount, UserAccountModel> _userMapper;
        private MapperHelper<ProductReview, ProductReviewModel> _reviewMapper;
        private IMapperProvider _mapperProvider;

        public UserAccountRepository(
            ApplicationDbContext appDbContext,
            IMapperProvider mapperProvider)
        {
            _mapperProvider = mapperProvider;
            _appDbContext = appDbContext;
            _reviewMapper = _mapperProvider.CreateReviewMapper();
            _userMapper = _mapperProvider.CreateUserAccountMapper();
        }

        public async Task<UserAccountModel> GetUserById(string id)
        {
            UserAccount user =
                await _appDbContext.UserAccounts
                .Include(u => u.ProductReviews)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            return _userMapper.MapSingleObject(user);
        }
    }
}
