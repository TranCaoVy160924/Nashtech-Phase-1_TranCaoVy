using DataAccess.DataModel;
using DataRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OnlineShopRepository: IOnlineShopRepository
    {
        public int haha()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            //int id = dbContext.OnlineShops.FirstOrDefault().UserAccount;
            return 1;
        }
    }
}
