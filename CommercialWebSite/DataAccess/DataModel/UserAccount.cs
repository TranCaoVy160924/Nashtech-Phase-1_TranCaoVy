using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
{
    public class UserAccount: IdentityUser
    {
        public virtual int OnlineShopId { get; set; }
        public virtual OnlineShop OnlineShop { get; set; }
    }
}
