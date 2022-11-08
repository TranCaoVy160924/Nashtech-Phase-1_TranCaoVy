namespace CommercialWebSite.API.AuthHelper
{
    public interface ITokenManager
    {
        bool IsValid(string token);
        void AddToken(string token);
        void DeleteToken(string token);
    }
}
