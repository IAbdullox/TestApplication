﻿using System.Security.Cryptography;
using System.Text;

namespace Infrastucture.Authentication
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int KeySize = 32;
        private const int IterationsCount = 10_000;
        public string Encrypt(string password, string salt)
        {
            using (var algoritm = new Rfc2898DeriveBytes(
                password: password,
                salt: Encoding.UTF8.GetBytes(salt),
                iterations: IterationsCount,
                hashAlgorithm: HashAlgorithmName.SHA3_256))
            {
                return Convert.ToBase64String(algoritm.GetBytes(KeySize));
            }
        }
        public bool Verify(string hash, string password, string salt)
        {
            return hash == Encrypt(password, salt);
        }
        public static string GenerateSalt(int size = 16)
        {
            var saltBytes = new byte[size];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }
    }
}