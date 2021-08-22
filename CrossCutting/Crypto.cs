using BCrypt.Net;
using BC = BCrypt.Net.BCrypt;

namespace CrossCutting
{
    public static class Crypto
    {
        public static class Password
        {
            private static readonly string Salt = BC.GenerateSalt(10);
            private static readonly bool EnhanceEntropy = false;
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
