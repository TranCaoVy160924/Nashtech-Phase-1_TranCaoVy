using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.Data.DataModel
{
    public class UserAccount: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string UserAddress { get; set; }

        public virtual List<Order>? Orders { get; set; }
        public virtual List<ProductReview>? ProductReviews { get; set; }
    }
}
