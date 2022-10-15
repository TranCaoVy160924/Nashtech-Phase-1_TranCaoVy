using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
{
    public class Good
    {
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public string GoodType { get; set; }
        public string Description { get; set; }
        public string GoodPicture { get; set; }
        public int UserRate { get; set; }
        public int NumberInStorage { get; set; }
        public double Price { get; set; }

        //public int OnlineShopId { get; set; }
        public virtual OnlineShop OnlineShop { get; set; }

        public virtual List<Receipt>? Receipts { get; set; }
    }
}
