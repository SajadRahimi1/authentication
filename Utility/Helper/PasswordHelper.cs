using System.Security.Cryptography;
using System.Text;
using DevOne.Security.Cryptography.BCrypt;

namespace Utility.Helper;

public class PasswordEncoder
{
    public static string EncodePassword(string password)
    {
       var salt = BCryptHelper.GenerateSalt();
        var hash = BCryptHelper.HashPassword(password, salt);
        return hash;
    }
    
    public static bool VerifyPassword(string password, string hash)
    {
       return BCryptHelper.CheckPassword(password, hash);
    }
}