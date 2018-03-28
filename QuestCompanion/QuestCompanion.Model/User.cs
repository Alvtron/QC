using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Windows.Storage;

namespace QuestCompanion.Model
{
    public class User
    {
        public Guid UID { get; private set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Bio { get; set; }
        public int Experience { get; private set; }
        public string Email { get; set; }
        public QCImage Photo { get; private set; }
        public Password Password { get; private set; }
        public DateTime SignedUp { get; private set; }
        public DateTime SignedIn { get; private set; }
        public List<Game> Games { get; private set; }
        public List<Log> Activity { get; private set; }

        public User(Guid uid, string username, string firstname, string lastname, DateTime birthday, string gender, string country, string bio, int experience, string email, QCImage photo, Password password, DateTime signedUp, DateTime signedIn, List<Game> games, List<Log> activity)
        {
            UID = uid;
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Firstname = firstname ?? throw new ArgumentNullException(nameof(firstname));
            Lastname = lastname ?? throw new ArgumentNullException(nameof(lastname));
            Birthday = birthday;
            Gender = gender ?? throw new ArgumentNullException(nameof(gender));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            Bio = bio ?? throw new ArgumentNullException(nameof(bio));
            Experience = experience;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Photo = photo ?? throw new ArgumentNullException(nameof(photo));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            SignedUp = signedUp;
            SignedIn = signedIn;
            Games = games ?? throw new ArgumentNullException(nameof(games));
            Activity = activity ?? throw new ArgumentNullException(nameof(activity));
        }

        public Validation.User CreateNewUser(string username, string email, string password)
        {
            if (Validation.ValidateUsername(username) != Validation.Username.VALID)
                return Validation.User.INVALID_USERNAME;
            if (Validation.ValidateEmail(email) != Validation.Email.VALID)
                return Validation.User.INVALID_EMAIL;
            else if (Validation.ValidatePassword(password) != Validation.Password.VALID)
                return Validation.User.INVALID_PASSWORD;
            else
            {
                UID = Guid.NewGuid();
                Username = username;
                Email = email;
                Password = new Password(password);
                SignedUp = DateTime.Now;
                Activity.Add(new Log(this, "Created user", "User " + this.ToString() + " was created."));
                return Validation.User.USER_CREATED;
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

        public void AddGame(Game game)
        {
            if (Games.Contains(game))
                Console.WriteLine("Game '" + game.Title + "' was already in user " + this.ToString() + "'s game list.");
            else
            {
                Games.Add(game);
                Console.WriteLine("Game '" + game.Title + "' was added to user " + this.ToString() + ".");
            }
        }

        public void RemoveGame(Game game)
        {
            if (!Games.Contains(game))
                Console.WriteLine("Game '" + game.Title + "' do not exist in user " + this.ToString() + "'s game list.");
            else
            {
                Games.Remove(game);
                Console.WriteLine("Game '" + game.Title + "' was removed from user " + this.ToString() + ".");
            }
        }

        public void AddPhoto(Byte[] photoInBytes)
        {
            Photo = new QCImage(photoInBytes, "Profile photo of user " + this.ToString() + ".");
        }

        public void SignIn()
        {
            SignedIn = DateTime.Now;
            Activity.Add(new Log(this, "Signed in", "User " + this.ToString() + " signed in."));
        }

        override public string ToString()
        {
            return Username;
        }
    }
}
