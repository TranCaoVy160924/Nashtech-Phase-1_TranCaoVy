using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.ShareDTO.Business
{
    public class ProductReviewModel
    {
        [Required(ErrorMessage = "Rating is required")]
        public int ProductRating { get; set; }
        public string? Review { get; set; }
        public DateTime? PostedDate { get; set; }

        public int ProductId { get; set; }
        public string UserAccountId { get; set; }
        public string UserName { get; set; }
    }
}
