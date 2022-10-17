using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthModels.Auth
{
    public class JwtResponseToken
    {
        public string Token { get; set; }
        public string Expiration { get; set; }
    }
}
