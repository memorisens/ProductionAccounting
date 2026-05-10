using System;
using System.Security.Cryptography;
using System.Text;

namespace ProductionAccounting
{
    public static class PasswordHelper
    {
        private const int SaltSize = 16;

        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return BitConverter.ToString(saltBytes).Replace("-", "").ToLower();
        }

        public static string HashPassword(string password, string salt)
        {
            string saltedPassword = salt + password;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        public static bool VerifyPassword(string password, string salt, string storedHash)
        {
            string computedHash = HashPassword(password, salt);
            return computedHash == storedHash;
        }

        public static (string salt, string hash) CreateHashedPassword(string password)
        {
            string salt = GenerateSalt();
            string hash = HashPassword(password, salt);
            return (salt, hash);
        }
    }
}