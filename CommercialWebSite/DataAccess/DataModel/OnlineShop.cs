using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
{
    public class OnlineShop
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }

        public string OwnerId { get; set; }
        public virtual UserAccount Owner { get; set; }

        public virtual List<Good>? Goods { get; set; }
    }
}
