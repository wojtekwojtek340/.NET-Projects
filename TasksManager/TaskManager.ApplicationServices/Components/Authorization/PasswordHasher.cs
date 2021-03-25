using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskManager.ApplicationServices.Components.Authorization;

namespace TaskManager.ApplicationServices.Components.Authorization
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashToCheck(string password, string hashedSalt)
        {
            var base64Encode = System.Convert.FromBase64String(hashedSalt);
            var encodedSalt = System.Text.Encoding.UTF8.GetString(base64Encode);

            var saltString = encodedSalt.Split("|");
            byte[] salt = new byte[16];

            for (int i = 0; i < 16; i++)
            {
                salt[i] = Byte.Parse(saltString.ElementAt(i));
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;

        }

        public string[] Hash(string password)
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string saltString = "";
            salt.ToList().ForEach(x => saltString += x.ToString() + "|");

            var base64Code = System.Text.Encoding.UTF8.GetBytes(saltString);
            string hashedSalt = Convert.ToBase64String(base64Code);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            string[] response = { hashed, hashedSalt };

            return response;
        }


    }
}
