using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace QC.Model
{
    public class User
    {
        [Key]
        public Guid UID { get; set; }
        [Required]
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Bio { get; set; }
        public int Experience { get; set; }
        [Required]
        public string Email { get; set; }
        public Image Photo { get; set; }
        [Required]
        public Password Password { get; set; }
        [Required]
        public DateTime SignedUp { get; set; }
        [Required]
        public DateTime SignedIn { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<Log> Logs { get; set; }

        public User()
        {
            UID = Guid.NewGuid();
            Games = new HashSet<Game>();
            Logs = new HashSet<Log>();
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
                Username = username;
                Email = email;
                Password = new Password(password);
                SignedUp = DateTime.Now;
                Logs.Add(new Log(this, "Created user", "User " + this.ToString() + " was created."));
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

            Debug.WriteLine("Increasing " + Username + "'s experience with " + amount + ".");
            return Experience -= amount;
        }

        public void AddGame(Game game)
        {
            if (Games.Contains(game))
                Debug.WriteLine("Game '" + game.Title + "' was already in user " + this.ToString() + "'s game list.");
            else
            {
                Games.Add(game);
                Debug.WriteLine("Game '" + game.Title + "' was added to user " + this.ToString() + ".");
            }
        }

        public void RemoveGame(Game game)
        {
            if (!Games.Contains(game))
                Debug.WriteLine("Game '" + game.Title + "' do not exist in user " + this.ToString() + "'s game list.");
            else
            {
                Games.Remove(game);
                Debug.WriteLine("Game '" + game.Title + "' was removed from user " + this.ToString() + ".");
            }
        }

        public void AddPhoto(Byte[] photoInBytes)
        {
            Photo = new Image(photoInBytes, "Profile photo of user " + this.ToString() + ".");
        }

        public void SignIn()
        {
            SignedIn = DateTime.Now;
            Logs.Add(new Log(this, "Signed in", "User " + this.ToString() + " signed in."));
        }

        override public string ToString()
        {
            return Username;
        }

        public string FullName { get => $"{Firstname} {Lastname}"; }

        public string PasswordString { get => $"{Password.Iterations}{Convert.ToBase64String(Password.Salt)}{Password.Hash}"; }

        public bool IsValid { get => !string.IsNullOrWhiteSpace(Firstname) && !string.IsNullOrWhiteSpace(Lastname); }

    }
}
