using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.Data.DataModel
{
    public class Order
    {
        public int OrderId { get; set; }
        public int NumOfGood { get; set; }
        public double TotalPrice { get; set; }
        // Unchecked out order is in cart
        public Boolean IsCheckedOut { get; set; }
        public int UserRating { get; set; }
        public string Review { get; set; }

        public virtual UserAccount Buyer { get; set; }

        public virtual Product Product { get; set; }
    }
}
