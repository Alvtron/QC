using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public class Log
    {
        public Guid UID { get; private set; }
        public User User { get; set; }
        public string Type { get; set; }
        public string Information { get; set; }
        public DateTime Date { get; private set; }

        public Log(Guid uid, User user, string type, string information, DateTime date)
        {
            UID = uid;
            User = user;
            Type = type;
            Information = information;
            Date = date;
        }

        public Log(User user, string type = "Unknown", string information = null)
        {
            UID = Guid.NewGuid();
            Type = type;
            User = user;
            Information = information;
            Date = DateTime.Now;
        } 
    }
}
