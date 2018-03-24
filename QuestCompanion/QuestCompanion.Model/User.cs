using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Bio { get; set; }
        public uint Exp { get; set; }
        public string Email { get; set; }
        public Byte[] Photo { get; set; }
        public Password Password { get; set; }
        public DateTime SignedUp { get; set; }
        public DateTime SignedIn { get; set; }
        public List<Game> Games { get; set; }
        public List<Log> Activity { get; set; }

        
    }
}
