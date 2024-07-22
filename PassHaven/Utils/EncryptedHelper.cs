using CryptoHelper;
using System.Text;

namespace PassHaven.Utils;

public class EncryptedHelper
{

    // Hash a password
    public string HashPassword(string password)
    {
        return Crypto.HashPassword(password);
    }

    // Verify the password hash against the given password
    public bool VerifyPassword(string hash, string password)
    {
        return Crypto.VerifyHashedPassword(hash, password);
    }

    public static string RandomPasswordGenerator(int length, bool inclideSpecialCharacters = true)
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        if (inclideSpecialCharacters)
        {
            chars += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
        }
        StringBuilder stringBuilder = new();
        Random random = new();
        for (int i = 0; i < length; i++)
        {
            _ = stringBuilder.Append(chars[random.Next(chars.Length)]);
        }
        return stringBuilder.ToString();
    }
}
