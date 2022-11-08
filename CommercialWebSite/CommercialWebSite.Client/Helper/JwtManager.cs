using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;

namespace CommercialWebSite.Client.Helper
{
    public class JwtManager
    {
        public Boolean IsAuthenticated { get; set; }
        private readonly ISession _session;
        private readonly JwtSecurityToken _secureToken;
        public string JwtTokenString { get; set; } = "";

        public JwtManager(ISession session)
        {
            _session = session;

            try
            {
                JwtTokenString = _session.GetString("JwtAuthToken");

                var handler = new JwtSecurityTokenHandler();
                _secureToken = handler.ReadJwtToken(JwtTokenString);
                IsAuthenticated = true;
            }
            catch(Exception)
            {
                IsAuthenticated = false;
            }
        }

        public string GetUserId()
        {
            if(IsAuthenticated)
            {
                string userId = _secureToken.Claims
                .Where(c => c.Type == ClaimTypes.Sid)
                .SingleOrDefault().Value.ToString();

                return userId;
            }
            else
            {
                return "";
            }
        }

        public string GetUsername()
        {
            if (IsAuthenticated)
            {
                string username = _secureToken.Claims
                .Where(c => c.Type == ClaimTypes.Name)
                .SingleOrDefault().Value.ToString();

                return username;
            }
            else
            {
                return "";
            }
        }

        public string GetAuthHeader()
        {
            return $"Bearer {JwtTokenString}";
        }
    }
}
