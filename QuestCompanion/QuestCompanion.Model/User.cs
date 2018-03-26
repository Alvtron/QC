using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QuestCompanion.Model
{
    public class User
    {
        public Guid UID { get; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Bio { get; set; }
        public int Experience { get; set; }
        public string Email { get; set; }
        public Byte[] Photo { get; set; }
        public Password Password { get; set; }
        public DateTime SignedUp { get; set; }
        public DateTime SignedIn { get; set; }
        public List<Game> Games { get; set; }
        public List<Log> Activity { get; set; }

        public User(string username, string email, string password)
        {
            if (!IsValidEmail(email))
                return;
            else if (!IsValidPassword(password))
                return;
            else
            {
                UID = Guid.NewGuid();
                Username = username;
                Email = email;
                Password = new Password(password);
            }
        }

        public int IncreaseExperience(Action.Type action)
        {
            return Experience += (int)action;
        }

        public int DecreaseExperience(int amount)
        {
            if (amount < 0) return -1;

            Console.WriteLine("Increasing " + Username + "'s experience with " + amount + ".");
            return Experience -= amount;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            const int MIN_LENGTH = 8, MAX_LENGTH = 100;
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(password))
            {
                Console.WriteLine("Password should contain at least one lowercase letter");
                return false;
            }
            else if (!hasUpperChar.IsMatch(password))
            {
                Console.WriteLine("Password should contain at least one uppercase letter");
                return false;
            }
            else if (password.Length < MIN_LENGTH)
            {
                Console.WriteLine("Password should not be less than 8 characters");
                return false;
            }
            else if (password.Length > MAX_LENGTH)
            {
                Console.WriteLine("Password should not be more than 100 characters");
                return false;
            }
            else if (!hasNumber.IsMatch(password))
            {
                Console.WriteLine("Password should contain at least one numeric value");
                return false;
            }
            else if (!hasSymbols.IsMatch(password))
            {
                Console.WriteLine("Password should contain at least one special case characters");
                return false;
            }

            else return true;
        }

        override public string ToString()
        {
            return Username;
        }
    }
}
