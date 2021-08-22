using BCrypt.Net;
using BC = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Configuration;
using System;

namespace CrossCutting
{
    public static class Crypto
    {
        private static readonly IConfiguration Configuration;

        public static class Password
        {
            private static readonly string Salt = BC.GenerateSalt(Convert.ToInt32(Configuration.GetSection("Crypto")["Salt"]));
            private static readonly bool EnhanceEntropy = Convert.ToBoolean(Configuration.GetSection("Crypto")["EnhanceEntropy"]);
            private static readonly HashType HashType = HashType.SHA256;

            public static string Hash(string password)
            {
                return BC.HashPassword(password, Salt, EnhanceEntropy, HashType);
            }

            public static bool Verify(string password, string passwordHash)
            {
                return BC.Verify(password, passwordHash, EnhanceEntropy, HashType);
            }
        }
    }
}
