﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
{
    public class UserAccount: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string ProfilePicture { get; set; }
        public string UserAddress { get; set; }

        public virtual OnlineShop? OnlineShop { get; set; }

        public virtual List<Receipt>? Receipts { get; set; }
    }
}
