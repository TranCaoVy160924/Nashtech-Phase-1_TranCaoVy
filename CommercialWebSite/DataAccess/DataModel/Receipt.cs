using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public int NumOfGood { get; set; }
        public double TotalPrice { get; set; }
        public Boolean IsCheckedOut { get; set; }

        //public string BuyerId { get; set; }
        public virtual UserAccount Buyer { get; set; }

        //public int GoodId { get; set; }
        public virtual Good Good { get; set; }
    }
}
