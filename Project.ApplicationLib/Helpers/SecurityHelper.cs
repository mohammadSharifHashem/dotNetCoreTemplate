using System;
using SimpleCrypto;

namespace CommonLib.Helpers
{
    public class SecurityHelper
    {
        /// <summary>
        /// DESCRIPTION: Encrypt password with Salt to provide maximum security
        /// </summary>
        /// <remarks>
        /// Create By: SMT
        /// </remarks>
        /// <param name="password"></param>
        public static string CreatePasswordHash(string password, out string passwordSalt)
        {
            ICryptoService cryptoService = new PBKDF2();

            //save this hash to the database
            string hashedPassword = cryptoService.Compute(password);

            //save this salt to the database
            passwordSalt = cryptoService.Salt;

            return hashedPassword;
        }

        public static string EncryptPassword(string password, string salt)
        {
            ICryptoService cryptoService = new PBKDF2();
            return cryptoService.Compute(password, salt);
        }

        public static string EncryptString(string StringToEncrypt, out string salt)
        {
            return CreatePasswordHash(StringToEncrypt, out salt);
        }
    }
}
