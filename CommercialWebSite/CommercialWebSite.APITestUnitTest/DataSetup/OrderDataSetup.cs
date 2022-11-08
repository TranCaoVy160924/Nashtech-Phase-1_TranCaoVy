using CommercialWebSite.ShareDTO.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.APITestUnitTest.DataSetup
{
    public static class OrderDataSetup
    {
        public static List<OrderModel> Collection()
        {
            return new List<OrderModel>();
        }

        public static OrderModel SingleObject()
        {
            return new OrderModel
            {
                OrderId = 1,
                NumOfGood = 2,
                IsCheckedOut = true,
                BuyerId = "b74ddd14-6340-4840-95c2-db12554843e5",
                ProductId = 1,
            };
        }
    }
}
