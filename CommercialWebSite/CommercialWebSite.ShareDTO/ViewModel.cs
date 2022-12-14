using CommercialWebSite.ShareDTO.Auth;
using CommercialWebSite.ShareDTO.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialWebSite.ShareDTO
{
    public class ViewModel
    {
        public LoginRequestModel LoginRequestModel { get; set; }
        public RegisterRequestModel RegisterRequestModel { get; set; }
        public List<ProductModel> ProductModels { get; set; }
        public ProductModel ProductDetail { get; set; }
        public FilterProductModel FilterProductModel { get; set; }
        public ProductReviewModel ProductReviewInputModel { get; set; }
        public List<ProductReviewModel> ProductReviewModels { get; set; }
        public int Page { get; set; }
        public OrderModel NewOrder { get; set; }
    }
}
