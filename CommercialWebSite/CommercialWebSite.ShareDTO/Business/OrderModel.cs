using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.ShareDTO.Business
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int NumOfGood { get; set; }
        public double TotalPrice { get; set; }
        // Unchecked out order is in cart
        public Boolean IsCheckedOut { get; set; }
        public string BuyerId { get; set; }
        public int ProductId { get; set; }
    }
}
