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
            if (Validation.IsValidEmail(email) != Validation.Email.VALID)
                return;
            else if (Validation.IsValidPassword(password) != Validation.Password.VALID)
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

        override public string ToString()
        {
            return Username;
        }
    }
}
