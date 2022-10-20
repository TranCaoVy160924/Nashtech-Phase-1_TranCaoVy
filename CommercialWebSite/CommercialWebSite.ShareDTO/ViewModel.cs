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
    }
}
