using System;
using System.Security.Cryptography;
using System.Text;

namespace GudangPintarGui.Utils
{
    public static class PasswordHelper
    {
        // SHA256 Hashing - Secure Coding Standard
        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password tidak boleh kosong");

            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(inputPassword))
                return false;

            var inputHash = HashPassword(inputPassword);
            return inputHash == storedHash;
        }
    }
}