using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace QuestCompanion.Model
{
    public class Password
    {
        public int Iterations { get; set; }
        public byte[] Salt { get; set; }
        public string Hash { get; set; }

        public Password(string password)
        {
            CreateNewPassword(password);
        }

        private void CreateNewPassword(string password)
        {
            const int SaltSize = 24;
            const int HashSize = 20;
            const int Pbkdf2Iterations = 1000;

            // Create salt with 24 bytes large
            var cryptoProvider = new RNGCryptoServiceProvider();
            Salt = new byte[SaltSize];
            cryptoProvider.GetBytes(Salt);

            // Create hash with salt and iterations, 20 bytes large
            var hash = CreateHash(password, Salt, Pbkdf2Iterations, HashSize);
            Iterations = Pbkdf2Iterations;
            Hash = Convert.ToBase64String(hash);

            // Release resources
            cryptoProvider.Dispose();
        }

        public bool ValidatePassword(string password)
        {
            var newHash = CreateHash(password, Salt, Iterations, Convert.FromBase64String(Hash).Length);

            return Convert.ToBase64String(newHash).Equals(Hash);
        }

        private static byte[] CreateHash(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;

            var newHash = pbkdf2.GetBytes(outputBytes);

            pbkdf2.Dispose();

            return newHash;
        }

        public void Print()
        {
            Console.WriteLine(Iterations + ":" + Convert.ToBase64String(Salt) + ":" + Hash);
        }
    }
}
