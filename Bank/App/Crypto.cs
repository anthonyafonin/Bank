using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bank.AppNS
{
    public static class Crypto
    {
        /// <summary>
        /// Generates random 32 byte salt and hashes password with appended salt
        /// </summary>
        /// <param name="password">Plaintext password</param>
        /// <returns>Hashed Password</returns>
        public static string GetHashSalt(string password)
        {
            // generate random salt
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            random.GetNonZeroBytes(salt);

            // generate hash from password and salt
            var bytes = new UTF8Encoding().GetBytes(password + salt);
            byte[] hashBytes;
            using (var algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}
