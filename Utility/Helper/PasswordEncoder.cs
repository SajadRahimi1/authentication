namespace Utility.Helper;

public class PasswordEncoder
{
    public static string EncodePasswordToBase64(string password)
    {
        try
        {
            var encData_byte = new byte[password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
            var encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Encode" + ex.Message);
        }
    }
    
    public string DecodeFrom64(string encodedData)
    {
        var encoder = new System.Text.UTF8Encoding();
        var utf8Decode = encoder.GetDecoder();
        var todecode_byte = Convert.FromBase64String(encodedData);
        var charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        var  decoded_char = new char[charCount];
        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        var result = new String(decoded_char);
        return result;
    }
}