using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
{
    public class OnlineShop
    {
        public int OnlineShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}
