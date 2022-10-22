using CommercialWebSite.ShareDTO.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.ShareDTO
{
    public class FilterProductModel
    {
        public List<CategorySelectionModel>? CategoriesSelection { get; set; }

        public double? MinPrice { get; set; }

        public double? MaxPrice  { get; set; }

        public string? ProductName { get; set; }
    }

    public class CategorySelectionModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsSelected { get; set; }
    }
}
