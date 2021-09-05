using BCrypt.Net;
using System;
using BC = BCrypt.Net.BCrypt;

namespace Infrastructure.CrossCutting.Core
{
    public static class Crypto
    {
        public static class Password
        {
            private static readonly string PasswordSalt = BC.GenerateSalt(Convert.ToInt32(InternalConfiguration.AppSettings["Crypto:Salt"]));
            private static readonly bool PasswordEnhanceEntropy = Convert.ToBoolean(InternalConfiguration.AppSettings["Crypto:EnhanceEntropy"]);
            private static readonly HashType PasswordHashType = HashType.SHA256;

            public static string Hash(string password)
            {
                return BC.HashPassword(password, PasswordSalt, PasswordEnhanceEntropy, PasswordHashType);
            }

            public static bool Verify(string password, string passwordHash)
            {
                return BC.Verify(password, passwordHash, PasswordEnhanceEntropy, PasswordHashType);
            }
        }
    }
}
