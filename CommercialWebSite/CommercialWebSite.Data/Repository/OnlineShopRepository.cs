using CommercialWebSite.Data.DataModel;
using CommercialWebSite.DataRepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.Data.Repository
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
