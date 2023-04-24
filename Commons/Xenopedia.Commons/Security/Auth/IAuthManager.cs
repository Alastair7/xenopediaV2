namespace Xenopedia.Commons.Security.Auth
{
    public interface IAuthManager
    {
        string GenerateToken(string username, string password);
    }
}
