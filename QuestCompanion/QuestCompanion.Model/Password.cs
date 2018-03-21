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
            const int SaltByteSize = 24;
            const int HashByteSize = 20;
            const int Pbkdf2Iterations = 1000;

            var cryptoProvider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SaltByteSize];
            cryptoProvider.GetBytes(salt);

            var hash = CreateHash(password, salt, Pbkdf2Iterations, HashByteSize);

            cryptoProvider.Dispose();

            Iterations = Pbkdf2Iterations;
            Salt = salt;
            Hash = Convert.ToBase64String(hash);
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
