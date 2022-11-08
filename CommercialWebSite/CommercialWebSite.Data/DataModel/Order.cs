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

        // Unchecked out order is in cart
        public Boolean IsCheckedOut { get; set; }
        public bool IsActive { get; set; }

        public virtual UserAccount Buyer { get; set; }

        public virtual Product Product { get; set; }
    }
}
