using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.Data.DataModel
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryPicture { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual List<Product> Products { get; set; }
    }
}
