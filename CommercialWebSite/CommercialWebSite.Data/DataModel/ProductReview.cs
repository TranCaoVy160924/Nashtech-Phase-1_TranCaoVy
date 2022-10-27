using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.Data.DataModel
{
    public class ProductReview
    {
        public int ProductReviewId { get; set; }
        public int ProductRating { get; set; }
        public string? Review { get; set; }
        public DateTime? PostedDate { get; set; }

        public Product Product { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
