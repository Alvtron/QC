using System;
using System.Collections.Generic;
using System.Text;

namespace QuestCompanion.Model
{
    public class Log
    {
        public Guid UID { get; set; }
        public User User { get; set; }
        public string Type { get; set; }
        public string Information { get; set; }
        public DateTime Date { get; set; }

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
