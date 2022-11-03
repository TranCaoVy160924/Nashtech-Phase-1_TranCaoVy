using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.ShareDTO.Business
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductPicture { get; set; }
        public int AgregateUserRate { get; set; }
        public int NumberInStorage { get; set; }
        public double Price { get; set; }
        public string? CreateDate { get; set; }
        public string? UpdateDate { get; set; }

        public int CategoryId { get; set; }
        public List<ProductReviewModel>? Reviews { get; set; }
    }
}
