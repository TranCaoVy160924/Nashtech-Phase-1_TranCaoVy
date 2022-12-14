using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.Data.DataModel
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductPicture { get; set; }
        public int NumberInStorage { get; set; }
        public double Price { get; set; }
        public string CreateDate { get; set; }
        public string UpdateDate { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual Category Category { get; set; }

        public virtual List<Order>? Orders { get; set; }
        public virtual List<ProductReview>? ProductReviews { get; set; }
    }
}
