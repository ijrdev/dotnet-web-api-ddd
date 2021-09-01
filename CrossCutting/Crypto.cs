using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using BC = BCrypt.Net.BCrypt;

namespace Infrastructure.CrossCutting.Core
{
    public static class Crypto
    {
        private static readonly IConfiguration _iConfiguration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        public static class Password
        {
            private static readonly string PasswordSalt = BC.GenerateSalt(Convert.ToInt32(_iConfiguration["Crypto:Salt"]));
            private static readonly bool PasswordEnhanceEntropy = Convert.ToBoolean(_iConfiguration["Crypto:EnhanceEntropy"]);
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
