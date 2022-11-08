using CommercialWebSite.API.AuthHelper;

namespace CommercialWebSite.API.Middleware
{
    public class TokenValidator
    {
        private readonly RequestDelegate _next;

        public TokenValidator(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITokenManager tokenManager)
        {
            context.Request.Headers.TryGetValue("Authorization", out var authHeader);
            try
            {
                string token = authHeader.ToString();
                if (tokenManager.IsValid(token))
                {
                    context.Items["isValidToken"] = true;
                }
                else
                {
                    context.Items["isValidToken"] = false;
                }
            }
            catch (Exception ex) { }
            await this._next(context);
        }
    }
}
