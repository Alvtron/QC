using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QC.Model
{
    public class Log
    {
        [Key]
        public Guid UID { get; private set; }
        [Required]
        public User User { get; set; }
        [Required]
        public string Type { get; set; }
        public string Information { get; set; }
        [Required]
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
