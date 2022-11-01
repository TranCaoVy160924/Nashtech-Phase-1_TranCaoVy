using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.ShareDTO.Business
{
    public class UserAccountModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public DateTime Birthday { get; set; }
        public string ProfilePicture { get; set; }
        public string UserAddress { get; set; }

        public string Role { get; set; }

        //public virtual List<Order>? Orders { get; set; }
        public List<ProductReviewModel>? Reviews { get; set; }
    }
}
