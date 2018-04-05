using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QC.Model
{
    public class Comment
    {
        [Key]
        public Guid UID { get; set; }
        [Required]
        public Quest Quest { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public string Message { get; set; }
        public ICollection<Log> Logs { get; }

        public Comment()
        {
            UID = Guid.NewGuid();
            Logs = new HashSet<Log>();
        }

        public Comment(Quest quest, User user, string message)
        {
            UID = Guid.NewGuid();
            Quest = quest;
            User = user;
            Message = message;
            Logs.Add(new Log(user, "Created comment"));
            User.IncreaseExperience(Action.Type.ADD_COMMENT);
        }

        public Comment(Guid uid, Quest quest, User user, string message, List<Log> changelog)
        {
            UID = uid;
            Quest = quest;
            User = user;
            Message = message;
            Logs = changelog;
        }
    }
}
