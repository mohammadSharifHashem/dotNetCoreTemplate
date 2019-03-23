using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CommonLib.Helpers
{
    public class TokenHelper
    {
        public static string GenerateUserAccessToken(long userId)
        {
            string text = userId + DateTime.Now.ToString();
            string PasswordHash = "PRTP@SS";
            string SaltKey = "!@S@LT#$";
            string VIKey = "@1B2c3D4e5F6g7H8";

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(text);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };

            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes, Base64FormattingOptions.None);
        }

    }
}
