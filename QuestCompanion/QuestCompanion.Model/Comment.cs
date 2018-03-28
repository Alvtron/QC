using System;
using System.Collections.Generic;

namespace QuestCompanion.Model
{
    public class Comment
    {
        public Guid UID { get; set; }
        public Quest Quest { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
        public List<Log> Changelog { get; }


        public Comment(Guid uid, Quest quest, User user, string message, List<Log> changelog)
        {
            UID = uid;
            Quest = quest;
            User = user;
            Message = message;
            Changelog = changelog;
        }

        public Comment(Quest quest, User user, string message)
        {
            UID = Guid.NewGuid();
            Quest = quest;
            User = user;
            Message = message;
            Changelog.Add(new Log(user, "Created comment"));
            User.IncreaseExperience(Action.Type.ADD_COMMENT);
        }
    }
}
