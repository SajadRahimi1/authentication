﻿using System.Security.Cryptography;
using System.Text;

namespace Utility.Helper;

public class PasswordEncoder
{
    public static int keySize = 64;
    public static int  iterations = 158000;
    public static string EncodePasswordToBase64(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(keySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(Encoding.UTF8.GetBytes(password), salt, iterations,
            HashAlgorithmName.SHA512, keySize);
        return Convert.ToHexString(hash);
    }
    
    public static bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA512, keySize);
        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    }
}