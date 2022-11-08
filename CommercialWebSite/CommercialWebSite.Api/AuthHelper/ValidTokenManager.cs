namespace CommercialWebSite.API.AuthHelper
{
    public class ValidTokenManager: ITokenManager
    {
        public static List<string> ValidToken;

        public bool IsValid(string token)
        {
            return ValidToken.Contains(token);
        }

        public void AddToken(string token)
        {
            if(ValidToken == null)
            {
                ValidToken = new List<string>();
            }
            if(!ValidToken.Contains(token))
            {
                ValidToken.Add(token);
            }
        }

        public void DeleteToken(string token)
        {
            if (ValidToken != null)
            {
                ValidToken.Remove(token);
            }
        }
    }
}
